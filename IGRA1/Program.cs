using IGRA;
using System.Threading.Channels;


Console.WriteLine("Добро пожаловать в игру");
Console.WriteLine("Введите число игроков:");
int kolich_igrokov = int.Parse(Console.ReadLine());

personazh[] player = new personazh[kolich_igrokov];

for (int i = 0; i < player.Length; i++)
{
    player[i] = new personazh();
}

Random random = new Random();

List<string> names = new List<string> {
"Алекс Миска","Ярык Программист","Юра Удалялкин","Стриканьоли","Донато Каркасс", "Леди Гага", "Стэн Кэрил", "Жозефина", "Золотая рыбка", "Билли Миллиган", "Евгений Понасенков", "Саня-прост-Саня", "Мамадзибрезов", "Мама Серёжи", "Сыбыр Кирилльский","Билли Джин","Хёнджин"
};


for (int i = 0; i < player.Length; i++)
{
    bool friend = false;
    int NameRand = random.Next(0, 16);
    int ForRandomFriend = random.Next(0, 2);
    if (ForRandomFriend == 0)
    {
        friend = false;
    }
    else { friend = true; }
    int lives = 100;


    player[i].Info(names[NameRand], random.Next(1, 100), random.Next(1, 100), friend, lives, random.Next(10, 20));
}
Console.Clear();
for (int i = 0; i < player.Length; i++)
{
    Console.Write(i + 1 + " ");
    player[i].Out_tablo();
}

Console.Write("Выбери своего героя: ");
int geroj = int.Parse(Console.ReadLine()) - 1;




while (true)
{
    Console.WriteLine("\n0 - Информация о всех героях \n1 - Поменять героя \n2 - Движение \n3 - Убийство \n");
    Console.WriteLine("4 - Битва \n5 - Лечение \n6 - Полное восстановление здоровья \n7 - Смена лагеря \n8 - Информация о соём герое.\n ");
    
    Console.Write("Ввод: ");
    int dejstvie = int.Parse(Console.ReadLine());
    Console.WriteLine();


    int xp = player[geroj].VozvratXP();
    if (xp < 1)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Out_tablo();
        }
        Console.WriteLine("Ваш герой отправился на фонтан, давай меняй героя");
        Console.Write("Выбери нового героя: ");
        geroj = int.Parse(Console.ReadLine()) - 1;
    }

  

    if (dejstvie == 0)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            player[i].Out_tablo();
        }
    }

    if (dejstvie == 1)
    {
        Console.Clear();
        Console.WriteLine("Введи айди персонажа, за которого будешь играть: ");
        geroj = int.Parse(Console.ReadLine()) - 1;
    }

    if (dejstvie == 2)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Out_tablo();
        }
        Console.WriteLine("Переход на другую координату");
        Console.Write("Введи координаты x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Введи координаты y: ");
        int y = int.Parse(Console.ReadLine());
        player[geroj].MooveX(x);
        player[geroj].MoveY(y);
    }


    //в случае нападения
    if (dejstvie == 3)
    {

        Console.Clear();


       

        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Out_tablo();
        }

        Console.WriteLine("Введи номер игрока, который будет нашей целью: ");
        int died = int.Parse(Console.ReadLine()) - 1;

        if (player[geroj].VozvratLager() == player[died].VozvratLager())
        {
            Console.WriteLine("Ты на своих напал\n");
        }

        else if (player[geroj].VozvratX() == player[died].VozvratX() && player[geroj].VozvratY() == player[died].VozvratY())
        {
            player[died].Ubit(died);


        }
        else
        {
            Console.WriteLine("Введена не та координата");
        }


    }
    if (dejstvie == 4)

    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write($"{i + 1}  "); player[i].Out_tablo();
        }



        Console.WriteLine("Введи номер игрока с которым хотим пообщаться: ");
        int anigilate = int.Parse(Console.ReadLine()) - 1;

        if (player[geroj].VozvratLager() == player[anigilate].VozvratLager())
        {
            Console.WriteLine("Ты напал на своих. Не делай болье так :(  \n");
        }




        else if (player[geroj].VozvratX() == player[anigilate].VozvratX() && player[geroj].VozvratY() == player[anigilate].VozvratY())
        {
            Console.WriteLine("Ты ввёл правилную координату и переместился к игроку, которого попытался уничтожить! ");


            int du = player[geroj].getdu();

            player[anigilate].Uron(du);

            du = player[anigilate].getdu();

            player[geroj].Uron(du);

            player[geroj].Out_tablo();

            player[anigilate].Out_tablo();

        }
        else if (player[geroj].VozvratX() != player[anigilate].VozvratX() || player[geroj].VozvratY() != player[anigilate].VozvratY())
        {
            Console.WriteLine("Выбрана неверная координарта");
        }

    }

    if (dejstvie == 5)
    {
        Console.Write("Персонаж вылечен на 10 хр");
        int lech = 10;
        player[geroj].Lechenie(lech);
    }

    if (dejstvie == 6)
    {
        Console.WriteLine("Полное восстановление здоровья.");
        player[geroj].Vost();
    }

    if (dejstvie == 7)
    {
        Console.WriteLine("Смена лагеря.");
        player[geroj].Lager();
    }
    if (dejstvie == 8)
    {
        Console.Clear();
        player[geroj].Out_tablo();
        Console.WriteLine();
    }







}
