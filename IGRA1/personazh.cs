using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IGRA
{
    internal class personazh
    {
        private string name;
        private int x;
        private int y;
        private bool lager;
        private int kol;
        private int uron;


        public void Info(string name, int x, int y, bool l, int kol, int uron)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.lager = l;
            this.kol = kol;
            this.uron = uron;
        }

        public void Print()
        {
            string friend;
            if (lager == true)
            {
                friend = "Лига картошки";
            }
            else
            {
                friend = "Лига сала";
            }

            Console.WriteLine($"Имя: {name}   Координаты x:{x}   y:{y}   {friend}   Количество его жизней: {kol}    Его урон: {uron}");
            Console.WriteLine("**********************************************************************************************************" );
        }

        public void MoveX(int dx) //движение по х
        {
            x = dx;
        }
        public void MoveY(int dy)
        {
            y = dy;  //движение по у
        }

        public int getx()
        {
            return x;   //возвращение координат

        }
        public int gety()
        {
            return y;
        }

        public void Ubit(int anigilate)
        {

            kol = 0;
            Console.WriteLine("Враг повержен");
        }

        public int getdu()
        {
            return uron;
        }

        public void Uron(int anigilate)
        {
            kol = kol - anigilate;
            if (kol < 1)
            {
                kol = 0;
                Console.WriteLine("\n Этого персонажа не существует\n");
            }
        }

        public void Doc(int du)
        {
            kol += du;
            if (kol > 100)
            {
                Console.WriteLine("Здоровье уже было на сотне");
                kol = 100;
            }
            Console.WriteLine("Вы восстановились на " + kol);
        }

        public void Vost()
        {
            Console.WriteLine("Восстановление на 100 жизней");
            kol = 100;
        }

        public void Lager()
        {
            lager = !lager;
        }

        public int getxp()
        {
            return kol;
        }

        public bool getl() //возвращение переменной. Используется в методе, чтобы определить, свой это лагерь или нет
        {
            return lager;
        }

    }


}