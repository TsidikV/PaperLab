using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperNS;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Page> plists = new List<Page>();
            Page[] page = new Page[10];
            bool flag = true;
            page[0] = new Page(2,"Белый", flag,"",0,0);
            page[1] = new Page(3, "Белый", flag, "", 0, 0);
            page[2] = new Page(4, "Белый", flag, "", 0, 0);
            page[3] = new Page(5, "Белый", flag, "", 0, 0);
            page[4] = new Page(6, "Белый", flag, "", 0, 0);
            page[5] = new Page(7, "Белый", flag, "", 0, 0);
            page[6] = new Page(8, "Белый", flag, "", 0, 0);
            page[7] = new Page(9, "Белый", flag, "", 0, 0);
            page[8] = new Page(10, "Белый", flag, "", 0, 0);
            page[9] = new Page(11, "Белый", flag, "", 0, 0);

            for (int i = 0; i < 10; i++)
            {
                plists.Add(page[i]);
            }

            IPaper picAction = new DrawingBook("A4", "Радуга", 2018, 4.56, plists, "для рисования");

            picAction.DrawPicture(2, "Черный квадрат", 100, 100);
            picAction.DrawPicture(4, "Девушка с персиками", 500, 500);
            picAction.DrawPicture(5, "Мишки в сосновом бору", 700, 900);
            picAction.DrawPicture(8, "Чертеж А", 50, 50);

            Console.WriteLine(picAction.ToString());
            foreach (Page p in plists)
            {
                Console.WriteLine(p.ToString());
            }

            picAction.ErasePicture(8);
            picAction.ShowAllPicture();
            picAction.ShowPicture(3);

            picAction.DeleteSheet(3);
            picAction.ShowAllPicture();
        }
    }
}
