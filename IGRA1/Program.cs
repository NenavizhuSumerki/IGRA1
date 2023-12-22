using IGRA;
using System.Threading.Channels;



Console.WriteLine("Введите число игроков:");
int kolich_igrokov = int.Parse(Console.ReadLine());

personazh[] player = new personazh[kolich_igrokov];

for (int i = 0; i < player.Length; i++)
{
    player[i] = new personazh();
}

Random random = new Random();

List<string> names = new List<string> {
"Алекс Миска","Ярык","Юра Удалялкин","Стриканьоли","Донато Каркасс", "Леди Гага", "Стэн Кэрил", "Жозефина", "Золотая рыбка", "Билли Миллиган", "Евгений Понасенков", "Саня-прост-Саня", "Мамадзибрезов", "Мама Серёжи", "Сыбыр Кирилльский","Билли Джин","Хёнджин"
};


for (int i = 0; i < player.Length; i++)
{
    bool friend = false;
    int ForRandomName = random.Next(0, 8);
    int ForRandomFriend = random.Next(0, 2);
    if (ForRandomFriend == 0)
    {
        friend = false;
    }
    else { friend = true; }
    int lives = 100;


    player[i].Info(names[ForRandomName], random.Next(1, 100), random.Next(1, 100), friend, lives, random.Next(10, 20));
}
Console.Clear();
for (int i = 0; i < player.Length; i++)
{
    Console.Write(i + 1 + " ");
    player[i].Print();
}

Console.Write("Выбери своего героя: ");
int geroj = int.Parse(Console.ReadLine()) - 1;




while (true)
{
    Console.WriteLine("\n0 - Информация о всех героях.\n1 - Поменять героя.\n2 - Движение.\n3 - УНИЧТОЖЕНИЕ.\n4 - Битва.\n5 - Лечение.\n6 - Полное восстановление здоровья.\n7 - Смена лагеря.\n8 - Информация о соём герое.");
    Console.Write("Ввод: ");
    int dejstvie = int.Parse(Console.ReadLine());
    Console.WriteLine();


    int xp = player[geroj].getxp();
    if (xp < 1)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Print();
        }
        Console.WriteLine("Ваш герой отправился на фонтан, давай меняй героя");
        Console.Write("Выбери нового героя: ");
        geroj = int.Parse(Console.ReadLine()) - 1;
    }

    if (dejstvie == 8)
    {
        Console.Clear();
        player[geroj].Print();
        Console.WriteLine();
    }

    if (dejstvie == 0)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            player[i].Print();
        }
    }

    if (dejstvie == 1)
    {
        Console.Clear();
        Console.WriteLine("Выбери своего героя: ");
        geroj = int.Parse(Console.ReadLine()) - 1;
    }

    if (dejstvie == 2)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Print();
        }
        Console.WriteLine("Перемещение героя.");
        Console.Write("Введи координаты x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Введи координаты y: ");
        int y = int.Parse(Console.ReadLine());
        player[geroj].MoveX(x);
        player[geroj].MoveY(y);
    }

    if (dejstvie == 3)
    {

        Console.Clear();
        Console.WriteLine("Режим турбо пушки");

        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Print();
        }

        Console.WriteLine("Введи номер игрока, который будет нашей целью: ");
        int anigilate = int.Parse(Console.ReadLine()) - 1;

        if (player[geroj].getl() == player[anigilate].getl())
        {
            Console.WriteLine("Ты на своих напал\n");
        }

        else if (player[geroj].getx() == player[anigilate].getx() && player[geroj].gety() == player[anigilate].gety())
        {
            player[anigilate].Ubit(anigilate);


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
            Console.Write(i + 1 + " ");
            player[i].Print();
        }
        Console.WriteLine("Введи номер игрока с которым хотим пообщаться: ");
        int anigilate = int.Parse(Console.ReadLine()) - 1;

        if (player[geroj].getl() == player[anigilate].getl())
        {
            Console.WriteLine("ЭЭЭ, СВОИ СВОИ БРАТ. Ты волыну то убери.\n");
        }

        else if (player[geroj].getx() == player[anigilate].getx() && player[geroj].gety() == player[anigilate].gety())
        {
            int du = player[geroj].getdu();
            player[anigilate].Uron(du);

            du = player[anigilate].getdu();
            player[geroj].Uron(du);

            player[geroj].Print();
            player[anigilate].Print();

        }
        else if (player[geroj].getx() != player[anigilate].getx() && player[geroj].gety() == player[anigilate].gety())
        {
            Console.WriteLine("Дружок - перожок, тобой выбранна неправильная координата. Клуб кожевенного мастерства парой координат дальше.");
        }

    }

    if (dejstvie == 5)
    {
        Console.Write("Лечение.");
        int du = random.Next(5, 20);
        player[geroj].Doc(du);
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

   





}