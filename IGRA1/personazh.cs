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
        private bool lager;
        private int kolLive;
        private int uron;
        private int died;
        private string name;

        private int x;
        private int y;

        public void Info(string name, int x, int y, bool l, int kolLive, int uron)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.lager = l;
            this.kolLive = kolLive;
            this.uron = uron;
        }

   
        public int VozvratX()
        {
            return x;   //возвращение координат

        }
        public int VozvratY()
        {
            return y;
        }

        public void MooveX(int X) //движение по х
        {
            x = X;
        }
        public void MoveY(int Y)
        {
            y = Y;  //движение по у
        }

        public void Ubit(int died)
        {

            kolLive = 0;
            Console.WriteLine("Враг повержен");
        }

        public int getdu()
        {
            return uron;
        }

        public void Uron(int died)
        {
            kolLive = kolLive - died;
            if (kolLive < 1)
            {
                kolLive = 0;
                Console.WriteLine("\n Этого персонажа не существует\n");
            }
        }

        public void Lechenie(int lech)
        {
            kolLive += lech;
            if (kolLive > 100)
            {
                Console.WriteLine("Здоровье уже было на сотне");
                kolLive = 100;
            }
            Console.WriteLine("Вы восстановились на " + kolLive);
        }

        public void Vost()
        {
            Console.WriteLine("Восстановление на 100 жизней");
            kolLive = 100;
        }

        public void Lager()
        {
            lager = !lager;
        }

        public int VozvratXP()
        {
            return kolLive;
        }

        public void Out_tablo()
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

            Console.WriteLine($"Имя: {name}  Координаты x:{x}  y:{y}  {friend}   Количество его жизней: {kolLive}  Его урон: {uron}");

            //Console.WriteLine($"Имя: {0,20}  Координаты х: {0,-21} у: {1,-30}  {2,-40} Количество его жизней: {3, -60} Его урон: {4, -80}",  name, x, y, kolLive, uron);
            Console.WriteLine("**********************************************************************************************************");
        }


        public bool VozvratLager() //возвращение переменной. Используется в методе, чтобы определить, свой это лагерь или нет
        {
            return lager;
        }

    }


}
