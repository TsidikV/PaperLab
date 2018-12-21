using System;
using System.Collections.Generic;
using System.Text;

namespace PaperNS
{
    public interface IPaper
    {
        void DrawPicture(int n, string name, int d, int w);
        void ShowPicture(int n);
        void ShowAllPicture();
        void ErasePicture(int n);
        void DeleteSheet(int n);
    }

    public abstract class Notebook: IPaper
    {
        public string _format { get; set; }
        public string _publisher { get; set; }
        public int _year { get; set; }
        public double _price { get; set; }
        public List<Page> _plist { get; set; }

        public Notebook()
        {
            _format = "";
            _publisher = "";
            _year = 0;
            _price = 0;
        }

        public Notebook(string form, string pub, int year, double pri, List<Page> plist)
        {
            this._format = form;
            this._publisher = pub;
            this._year = year;
            this._price = pri;
            this._plist = plist;
        }

        public void ShowPicture(int n)
        {
            int s = n - 2;
            if (s>-1 && _plist[s]._clean != false)
            {
                Console.WriteLine(_plist[s].ToString());
            }
            else Console.WriteLine("Изображение отсутствует!");
        }

        public void ShowAllPicture()
        {
            for(int i = 0; i <  _plist.Count; i++)
            Console.WriteLine(_plist[i].ToString());
        }

        public void DrawPicture(int n, string name, int d, int w)
        {
            int s = n - 2;
            if (s > -1 && s < _plist.Count)
            {
                if (_plist[s]._clean == false)
                {
                    ErasePicture(s);
                    _plist[s]._picname = name;
                    _plist[s]._height = d;
                    _plist[s]._width = w;
                }
                else
                {
                    _plist[s]._picname = name;
                    _plist[s]._height = d;
                    _plist[s]._width = w;
                }
                _plist[s]._clean = false;
            }
        }

        public void ErasePicture(int n)
        {
            int s = n - 2;
            if (s > -1)
            {
                _plist[s]._clean = true;
                _plist[s]._picname = "";
                _plist[s]._height = 0;
                _plist[s]._width = 0;
            }
            else Console.WriteLine("Неверный номер страницы!");
        }

        public void DeleteSheet(int n)
        {
            if (n > 0 && n <_plist.Count/2)
            {
                _plist.RemoveAt(2 * n + 1);
                _plist.RemoveAt(2 * n);                
            } else Console.WriteLine("Невозможно удалить лист!");
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder(100);
            s.Append("Тетрадь формата "+_format +" выпущена в " + _year+"\n");
            s.Append("   Издательство: " + _publisher + ". Стоимость:" + _price + " руб.\n");
            return s.ToString();
        }
    }

    public class DrawingBook:  Notebook, IPaper
    {
        private string _type { get; set; }

        public DrawingBook()
        {
            _type = "";
        }

        public DrawingBook(string form, string pub, int year, double pri, List<Page> plist, string type): base(form,pub,year,pri,plist)
        {
            this._type = type;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder(100);
            s.Append("Тетрадь ("+ _type +") формата "+ _format +" выпущена в " + _year + "\n");
            s.Append("   Издательство: " + _publisher + ". Стоимость:" + _price +" руб.\n");
            return s.ToString();
        }
    }

    public class Page
    {
        public int _number { get; set; }
        public string _backcolor { get; set; }       
        public bool _clean { get; set; }
        public string _picname { get; set; }
        public int _height { get; set; }
        public int _width { get; set; }

        public Page()
        {
            this._backcolor = "";
            this._number = 0;            
            this._height = 0;
            this._width = 0;
        }

        public Page(int num, string back, bool cle, string name, int hei, int wid)
        {         
            this._number = num;
            this._backcolor = back;            
            this._clean = cle;
            this._picname = name;
            this._height = hei;
            this._width = wid;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder(100);
            if(_clean != true)
            {
                s.Append("Страница №" + _number + ". Фон - " + _backcolor + "\n");
                s.Append("Рисунок под названием: " + _picname + "\n");
                s.Append("Параметры рисунка(высотахширина): " + _height + "x"+ _width + "\n");
                return s.ToString();
            } else
                s.Append("На странице номер " + _number + " ничего не изображено\n");
                return s.ToString();
        }
    }
}
