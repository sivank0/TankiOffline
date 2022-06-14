using TankiOffline;

public static class Program
{
    public static void Main()
    {
        Console.Title = "ТанкиОфлайн";

        //Заполнение информации о командах
        Team firstTeam = new Team(1, ConsoleColor.Blue);
        Team secondTeam = new Team(2, ConsoleColor.Red);

        //Вывод существующих команд
        firstTeam.ConsoleWriteTeam();
        secondTeam.ConsoleWriteTeam();

        Actions.Match(firstTeam, secondTeam);

        Console.ReadKey();
    }
}