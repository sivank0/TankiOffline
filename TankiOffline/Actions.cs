namespace TankiOffline;

public static class Actions
{
    public static void Match(Team firstTeam, Team secondTeam) //сражение
    {
        while (firstTeam.IsAlive && secondTeam.IsAlive)
        {
            firstTeam.Target(secondTeam);
            secondTeam.Target(firstTeam);

            List<Shot> shots = new List<Shot>();

            shots.AddRange(firstTeam.Hits());            
            shots.AddRange(secondTeam.Hits());

            foreach (Shot shot in shots)
            {
                shot.Apply();
                shot.ConsoleWriteDamage();
            }

            firstTeam.ConsoleWriteTeam();
            secondTeam.ConsoleWriteTeam();

            firstTeam.ClearTargets();
            secondTeam.ClearTargets();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nПобеду одержала\n");

        if (firstTeam.IsAlive)
            firstTeam.ConsoleWriteTeam();
        else if (secondTeam.IsAlive)
            secondTeam.ConsoleWriteTeam();
    }
}
