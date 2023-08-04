using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasic.Chapter05.Examples
{
    public class Ex010
    {
        public void Run()
        {
            int number = 1;
            string title = "첫 번째 게시글입니다.";
            string content = "첫 번째 공지사항입니다.";
            string writer = "Admin";

            Service.BoardService boardService = 
                new Service.BoardService();

            boardService.Save(number, title, content, writer);
            boardService.Read();

            Console.WriteLine("============");

            boardService.Read();
        }
    }
}
