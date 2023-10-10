using Microsoft.AspNetCore.Mvc;
using System;
using System.DirectoryServices;
using Project.Models;

namespace Project.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ADUserController : ControllerBase
    {
        [HttpPost("usercreate")]
        public IActionResult UserCreate([FromBody] AddsUserInsertModel addsM)
        {
            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://OU={0},OU=Group,DC=kopoproject,DC=dev", addsM.userOu)))
                {
                    DirectoryEntries childEntries = entry.Children;
                    DirectoryEntry newUser = childEntries.Add("CN=" + addsM.userName, "user");
                    newUser.Properties["samAccountName"].Value = addsM.userId;
                    newUser.CommitChanges();

                    // 사용자를 그룹에 추가
                    DirectoryEntry groupEntry = new DirectoryEntry(string.Format("LDAP://CN=Development,OU=Group,DC=kopoproject,DC=dev", addsM.userOu));
                    groupEntry.Properties["member"].Add(newUser.Properties["distinguishedName"].Value);
                    groupEntry.CommitChanges();
                    return Ok("생성이 완료되었습니다.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
