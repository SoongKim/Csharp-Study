using Microsoft.AspNetCore.Mvc;
using System;
using Project.Controllers;
using System.DirectoryServices;
using Project.Models;
using MySql.Data.MySqlClient;
using System.DirectoryServices.AccountManagement;
using Org.BouncyCastle.Asn1.X509;

namespace Project.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ADUserController : ControllerBase
    {
        public string domainInfo = "kopoproject";
        public string domainInfoSecond = "dev";

        [HttpPost("total")]
        public async Task<IActionResult> totalUserInfo()
        {
            List<UserPrincipal> _userList = new List<UserPrincipal>();

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, string.Format("{0}.{1}", domainInfo, domainInfoSecond), string.Format("OU=Group,DC={0},DC={1}", domainInfo, domainInfoSecond)))
            {
                using (DirectorySearcher searcher = new DirectorySearcher(new DirectoryEntry(string.Format("LDAP://OU=Group,DC={0},DC={1}", domainInfo, domainInfoSecond))))
                {
                    searcher.Filter = "(&(objectClass=organizationalUnit)(!(name=Group)))";
                    foreach (SearchResult result in searcher.FindAll())
                    {
                        string ouName = result.Properties["name"][0].ToString();
                        // "Group" OU 자체를 건너뜁니다.
                        if (ouName == "Group")
                        {
                            continue;
                        }

                        // 각 OU에 대한 PrincipalContext 생성
                        PrincipalContext ouContext = new PrincipalContext(ContextType.Domain, string.Format("{0}.{1}", domainInfo, domainInfoSecond)
                            , string.Format("OU={0},OU=Group,DC={1},DC={2}", ouName, domainInfo, domainInfoSecond));
                        
                        UserPrincipal user = new UserPrincipal(ouContext);
                            
                        PrincipalSearcher principalsearcher = new PrincipalSearcher(user);
                            
                        foreach (var userResult in principalsearcher.FindAll())
                        {
                            if (userResult is UserPrincipal userPrincipal)
                            {
                                _userList.Add(userPrincipal);
                            }
                        }
                        
                    }
                }
            }
            return Ok(_userList);
        }

        #region >> 유저 생성
        [HttpPost("usercreate")]
        public async Task<IActionResult> UserCreate([FromBody] AddsUserInsertModel addsM)
        {
            try
            {
                var groupOU = await findGroupName(addsM.userOu);
                string userGroupOU = groupOU;

                Console.WriteLine(userGroupOU);
                //Console.WriteLine(string.Format("LDAP://OU={0},OU=Group,DC=kopoproject,DC=dev", userGroupOU));
                //Console.WriteLine(string.Format("LDAP://CN={0},OU={1},OU=Group,DC=kopoproject,DC=dev", addsM.userName, userGroupOU));

                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, string.Format("{0}.{1}", domainInfo, domainInfoSecond)
                    , string.Format("OU={0},OU=Group,DC={1},DC={2}", userGroupOU, domainInfo, domainInfoSecond)))
                {
                    UserPrincipal user = new UserPrincipal(context);
                    user.SamAccountName = addsM.userName;
                    user.UserPrincipalName = string.Format("{0}@{1}.{2}", addsM.userId, domainInfo, domainInfoSecond);
                    user.DisplayName = addsM.userName;
                    user.EmailAddress = addsM.userEmailAddress;

                    string _givenName = addsM.userName.Split(' ')[0];
                    string _surName = addsM.userName.Split(' ')[1];

                    user.GivenName = _givenName;
                    user.Surname = _surName;
                    user.SetPassword(addsM.userPassword);
                    user.Enabled = true;
                    user.Save();
                    return Ok("AD 신규 유저 생성이 완료되었습니다.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion

        #region >> 그룹 이동
        [HttpPost("userGroupMove")]
        public async Task<IActionResult> UserGroupMove(string userName, string userCurrentGroup, string movingGroup)
        {
            string changeUserName = userName;
            string presentGroup = userCurrentGroup;
            string changeTargetGroup = movingGroup;

            var presentOU = await findGroupName(presentGroup);
            var userOU = await findGroupName(changeTargetGroup);

            string presentGroupOU = presentOU;
            string userGroupOU = userOU;

            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, string.Format("{0}.{1}", domainInfo, domainInfoSecond)
                    , string.Format("OU={0},OU=Group,DC={1},DC={2}", presentGroupOU, domainInfo, domainInfoSecond)))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, changeUserName);

                    DirectoryEntry userEntry = (DirectoryEntry)user.GetUnderlyingObject();
                    DirectoryEntry targetOuEntry = new DirectoryEntry(string.Format("LDAP://OU={0},OU=Group,DC=kopoproject,DC=dev", userGroupOU));
                    userEntry.MoveTo(targetOuEntry);
                    userEntry.CommitChanges();
                    userEntry.Close();
                    targetOuEntry.Close();
                }
                return Ok("그룹 변경이 완료되었습니다.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region >> 유저 삭제
        [HttpPost("userDelete")]
        public async Task<IActionResult> UserDelete(string userName, string userOu)
        {
            string removeTargetUserName = userName;
            var userOU = await findGroupName(userOu);
            string userGroupOU = userOU;

            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, string.Format("{0}.{1}", domainInfo, domainInfoSecond)
                    , string.Format("OU={0},OU=Group,DC={1},DC={2}", userGroupOU, domainInfo, domainInfoSecond)))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, removeTargetUserName);
                    user.Delete();
                }
                return Ok("AD 유저 삭제가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region >> 조직 구성 단위 신설
        [HttpPost("CreateGroup")]
        public async Task<IActionResult> GroupCreate(string newGroupName)
        {
            try
            {
                string groupName = newGroupName;
                using (DirectoryEntry entry = new DirectoryEntry("LDAP://OU=Group,DC=kopoproject,DC=dev"))
                {
                    DirectoryEntries childEntries = entry.Children;
                    DirectoryEntry newOU = childEntries.Add("OU=" + groupName, "OrganizationalUnit");
                    newOU.CommitChanges();
                }
                return Ok("새로운 OU가 생성되었습니다.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region >> 그룹명 확인
        [HttpPost("findGroupName")]
        public async Task<string> findGroupName(string groupId)
        {
            string fullQuery = string.Format("SELECT group_name FROM groupinfo WHERE group_id = '{0}';", groupId);
            string connStr = Environment.GetEnvironmentVariable("DB_CONNECTION_INFO");
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    await connection.OpenAsync();
                    MySqlCommand cmd = new MySqlCommand(fullQuery, connection);

                    List<Dictionary<string, object>> myList = new List<Dictionary<string, object>>();

                    using (MySqlDataReader _mysqldatareader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        while (await _mysqldatareader.ReadAsync())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();

                            for (int i = 0; i < _mysqldatareader.FieldCount; i++)
                            {
                                string columnName = _mysqldatareader.GetName(i);
                                object value = _mysqldatareader[i];
                                row[columnName] = value;
                            }

                            myList.Add(row);
                        }
                    }
                    if (myList.Count > 0 && myList[0].ContainsKey("group_name"))
                    {
                        return myList[0]["group_name"].ToString();
                    }
                    else
                    {
                        return "CODE005";
                        /* CODE005 : 대상 그룹이 존재하지 않을 때. 신설을 위해 필요함. */
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

    }
}
