using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReviewChapter05.Service
{
    public class BankingService
    {
        #region >> 전역 변수 설정
        List<Model.Bank> bankList = new List<Model.Bank>();
        Model.Bank targetAccount;
        private readonly string dirInfo = Environment.CurrentDirectory;
        #endregion

        #region >> 계좌 연동
        public void SetBank(Model.Bank bank)
        {
            bankList.Add(bank);
        }
        #endregion

        #region >> 접속계좌설정
        public void SetAccount()
        {
            if (bankList.Count == 0)
            {

            }
            else
            {
                Console.WriteLine("몇 번 계좌로 접속할까요?");
                for (int idx = 0; idx < bankList.Count; idx++)
                {
                    Console.WriteLine("'{0}'번 계좌 | 계좌명 : '{1}' | 소유주 : '{2}'", idx, bankList[idx].accountName, bankList[idx].accountOwner);
                }
                int userSelectAccount;
                try
                {
                    userSelectAccount = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("해당하는 번호의 계좌가 존재하지 않습니다.");
                    return;
                }
                this.targetAccount = bankList[userSelectAccount];
                Console.WriteLine("'{0}' 계좌로 접속합니다.", this.targetAccount.accountName);
            }
        }
        #endregion

        #region >> 조회계좌설정
        public void TargetAccount()
        {
            if (bankList.Count == 0)
            {
                Console.WriteLine("아직 계좌를 생성하시지 않으셨습니다.");
                return;
            }
            else if (bankList.Count == 1)
            {
                Console.WriteLine("조회 계좌의 인덱스를 입력해주세요.");
                Console.WriteLine("0번 계좌 보유 중");
            }
            else
            {
                Console.WriteLine("조회 계좌의 인덱스를 입력해주세요.");
                Console.WriteLine("계좌 인덱스 범위 : 0 ~ {0}", bankList.Count - 1);
                for (int idx = 0; idx < bankList.Count; idx++)
                {
                    Console.WriteLine("'{0}'번 계좌 | 계좌명 : '{1}' | 소유주 : '{2}'", idx, bankList[idx].accountName, bankList[idx].accountOwner);
                }
            }
            int targetAccountIndex;
            try
            {
                targetAccountIndex = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("올바른 인덱스 번호를 입력해주세요.");
                return;
            }
            try
            {
                this.targetAccount = bankList[targetAccountIndex];
            }
            catch
            {
                Console.WriteLine("인덱스 범위를 초과하셨습니다.");
                return;
            }
            Console.WriteLine("'{0}'번 인덱스 '{1}' 계좌 정보를 조회합니다. (소유주 : '{2}')", targetAccountIndex, this.targetAccount.accountName, this.targetAccount.accountOwner);
        }
        #endregion

        #region >> 계좌생성
        public void MakingAccount()
        {
            Console.WriteLine("계좌를 신설합니다.");
            targetAccount = new Model.Bank();
            Console.WriteLine("계좌명을 입력해주세요.");
            this.targetAccount.accountName = Console.ReadLine();
            Console.WriteLine("계좌 소유주명을 입력해주세요.");
            this.targetAccount.accountOwner = Console.ReadLine();
            this.targetAccount.accountMoney = "0";
            Console.WriteLine("'{0}'계좌가 생성되었습니다.", this.targetAccount.accountName);
            SetBank(this.targetAccount);
        }
        #endregion

        #region >> 잔액조회
        public void FindAccountInfo()
        {
            Console.WriteLine("잔액을 조회합니다.");
            Console.WriteLine("'{0}' 계좌 잔액은 '{1}'원입니다,", this.targetAccount.accountName, Convert.ToInt32(this.targetAccount.accountMoney));
        }
        #endregion

        #region >> 입금
        public void InputMoney()
        {
            Console.WriteLine("입금할 금액을 입력해주세요. 잔액:'{0}'원", this.targetAccount.accountMoney);
            int inputMoney;
            try
            {
                inputMoney = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("올바른 입금액을 입력해주세요.");
                return;
            }
            this.targetAccount.accountMoney = (Convert.ToInt32(this.targetAccount.accountMoney) + inputMoney).ToString();
            Console.WriteLine("'{0}'계좌 잔액 : '{1}'원", this.targetAccount.accountName, this.targetAccount.accountMoney);
            SetLogFile();
        }
        #endregion

        #region >> 출금
        public void WithdrawMoney()
        {
            Console.WriteLine("출금할 금액을 입력해주세요.");
            int withDrawMoney;
            try
            {
                withDrawMoney = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("올바른 금액을 입력해주세요.");
                return;
            }

            if (withDrawMoney < 0)
            {
                Console.WriteLine("-금액을 출금할 수 없습니다.");
                return;
            }
            else if (withDrawMoney > Convert.ToInt32(this.targetAccount.accountMoney))
            {
                Console.WriteLine("보유액을 초과하여 인출할 수 없습니다.");
                return;
            }
            this.targetAccount.accountMoney = (Convert.ToInt32(this.targetAccount.accountMoney) - withDrawMoney).ToString();
            Console.WriteLine("'{0}'원 인출되었습니다.", withDrawMoney);
            Console.WriteLine("'{0}'계좌 잔액 : '{1}'원", this.targetAccount.accountName, this.targetAccount.accountMoney);
            SetLogFile();
        }
        #endregion

        #region >> 서비스 종료 및 로그 기록
        public void serviceEnd()
        {
            Console.WriteLine("감사합니다.");
            SetLogFile();
        }
        #endregion

        #region >> 로그 파일로 저장
        public void SetLogFile()
        {
            DirectoryInfo drInfo = new DirectoryInfo(dirInfo + @"\data");
            if (!drInfo.Exists)
            {
                drInfo.Create();
            }
            using (StreamWriter sw = new StreamWriter(drInfo.FullName + @"\log.txt", false))
            {
                int index = 0;
                try
                {
                    while (bankList[index] != null)
                    {
                        this.targetAccount = bankList[index];
                        sw.WriteLine(this.targetAccount.accountName);
                        sw.WriteLine(this.targetAccount.accountOwner);
                        sw.WriteLine(this.targetAccount.accountMoney);
                        index++;
                    }
                }
                catch
                {
                    return;
                }
            }
        }
        #endregion

        #region >> 로그 파일 불러오기
        public void ReadLogFile()
        {
            DirectoryInfo drInfo = new DirectoryInfo(dirInfo + @"\data");
            if (!drInfo.Exists)
            {
                return;
            }
            FileInfo logFileInfo = new FileInfo(drInfo.FullName + @"\log.txt");
            if (!logFileInfo.Exists)
            {
                return;
            }
            Console.WriteLine("로그 파일로부터 데이터를 불러옵니다...");
            using (StreamReader sr = new StreamReader(logFileInfo.FullName))
            {
                while (!sr.EndOfStream)
                {
                    this.targetAccount = new Model.Bank();
                    this.targetAccount.accountName = sr.ReadLine();
                    this.targetAccount.accountOwner = sr.ReadLine();
                    this.targetAccount.accountMoney = sr.ReadLine();
                    bankList.Add(this.targetAccount);
                }
            }
            Console.WriteLine("불러오기가 완료되었습니다.");
            Console.WriteLine();
        }
        #endregion

        public void Run()
        {
            ReadLogFile();
            SetAccount();
            bool isValid = true;
            do
            {
                if (bankList.Count == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("현재 사용 계좌 : '{0}'번 | '{1}' 계좌 | 소유주 : '{2}'", bankList.IndexOf(this.targetAccount), this.targetAccount.accountName, this.targetAccount.accountOwner);
                    Console.WriteLine();
                }
                Console.WriteLine("***** 뱅킹 서비스입니다. *****");
                Console.WriteLine("1: 계좌 만들기");
                Console.WriteLine("2: 이용 계좌 변경");
                Console.WriteLine("3: 잔액 조회");
                Console.WriteLine("4: 입금");
                Console.WriteLine("5: 출금");
                Console.WriteLine("0: 종료");
                Console.WriteLine("******************************");
                int userSelMenu;
                try
                {
                    userSelMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("올바른 메뉴를 선택해주세요.");
                    continue;
                }
                if (userSelMenu == 1)
                {
                    MakingAccount();
                }
                else if (userSelMenu == 2)
                {
                    TargetAccount();
                }
                else if (userSelMenu == 3)
                {
                    FindAccountInfo();
                }
                else if (userSelMenu == 4)
                {
                    InputMoney();
                }
                else if (userSelMenu == 5)
                {
                    WithdrawMoney();
                }
                else if (userSelMenu == 0)
                {
                    serviceEnd();
                    isValid = false;
                }
                Console.WriteLine();
            }
            while (isValid);
            Console.ReadKey();
        }
    }
}