// See https://aka.ms/new-console-template for more information
using PA4.Interfaces;
using PA4;




DisplayIntro();

Character player1 = PlayerPick();
Character player2 = PlayerPick();

Console.WriteLine();
Console.WriteLine("PLAYER 1:");
PrintPlayerStats(player1);

Console.WriteLine();
Console.WriteLine("PLAYER 2:");
PrintPlayerStats(player2);

bool startingPlayer = FirstTurn(player1.UserName, player2.UserName);
DuringGame(startingPlayer, player1, player2);
WinnerWinner(player1, player2);

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

static Character PlayerPick()
{
    Console.WriteLine("Enter your username:");
    string userName = Console.ReadLine();

    MainMenu menuChoice = new MainMenu();
    int whichCharacter = menuChoice.WhichCharacter();

    Random rnd = new Random();
    int rndMaxPower = Character.MaxPowerUse();

    Character temp = whichCharacter switch
    {
        1 => new JackSparrow() { UserName = userName, MovieCharacter = "Jack Sparrow", maxPower = rndMaxPower, health = 100, attackStrength = Character.AttackStrengthUse(rndMaxPower), defenseStrength = Character.DefensePowerUse(rndMaxPower) },
        2 => new DavyJones() { UserName = userName, MovieCharacter = "Davy Jones", maxPower = rndMaxPower, health = 100, attackStrength = Character.AttackStrengthUse(rndMaxPower), defenseStrength = Character.DefensePowerUse(rndMaxPower) },
        3 => new WillTurner() { UserName = userName, MovieCharacter = "Will Turner", maxPower = rndMaxPower, health = 100, attackStrength = Character.AttackStrengthUse(rndMaxPower), defenseStrength = Character.DefensePowerUse(rndMaxPower) },
        _ => throw new ArgumentException("Invalid character choice.")
    };

    return temp;
}

static void PrintPlayerStats(Character player)
{
    Console.WriteLine($"Player: {player.UserName}");
    Console.WriteLine($"Character: {player.MovieCharacter}");
    Console.WriteLine($"MaxPower: {player.maxPower}");
    Console.WriteLine($"Health: {player.health}");
    Console.WriteLine($"AttackStrength: {player.attackStrength}");
    Console.WriteLine($"DefensivePower: {player.defenseStrength}");
    Console.WriteLine($"AttackBehavior: {player.attack.GetType().Name}");
}

static void DisplayIntro()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@" 
  ____________________________________________________
 /                                                    \
|    _____________________________________________     |
|   |                                             |    |
|   |  WELCOME TO GRANT'S PIRATE GAME!           |    |
|   |                                             |    |
|   |         _.-._                               |    |
|   |      .-     '-.                            |    |
|   |      \'-._.-    `'-._                       |    |
|   |         \`'-._         `'-._                |    |
|   |            \\    '-._       `'-._            |    |
|   |            `-._     `'-._       \\          |    |
|   |_______________________________________________|    |
|                                                      |
 \______________________________________________________/
              (Suppose to be a wave^)
  ");
    Console.ResetColor();
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}




static bool FirstTurn(string player1, string player2)
{
    System.Console.WriteLine();
    Console.WriteLine($"Now, a coin flip will decide which player goes first. HEADS for {player1}, TAILS for {player2}.");
    System.Console.WriteLine();
    Random rnd = new Random();
    bool coinFlip = rnd.Next(2) == 0;

    Console.WriteLine("Flipping coin...");
    Thread.Sleep(2000);
    System.Console.WriteLine();
    Console.WriteLine("Coin has landed...");
    System.Console.WriteLine();
    Thread.Sleep(1000);

    string coinResult = coinFlip ? "Heads" : "Tails";
    Console.WriteLine($"The coin landed on {coinResult}!");
    System.Console.WriteLine();

    bool startingPlayer = coinFlip;
    if (startingPlayer)
    {
        Console.WriteLine($"{player1} goes first!");
    }
    else
    {
        Console.WriteLine($"{player2} goes first!");
    }

    return startingPlayer;
}

static void DuringGame(bool startingPlayer, Character player1, Character player2)
{
    Console.WriteLine("Starting gameplay...");

    // Loop for game play until one player runs out of health
    while (player1.health > 0 && player2.health > 0)
    {
        Thread.Sleep(2000);

        if (startingPlayer)
        {
            System.Console.WriteLine();
            Console.WriteLine($"{player1.UserName}, press any key to attack!");
            Console.ReadKey();
            System.Console.WriteLine();
            Console.WriteLine("\n                           G A M E P L A Y");
            Console.WriteLine($"{player1.UserName} attacks!");
            System.Console.WriteLine();
            player1.attack.Attack();
            ManageHealth(startingPlayer, player1, player2);
            startingPlayer = false; // To let player2 go first next time
        }
        else
        {
            System.Console.WriteLine();
            Console.WriteLine($"{player2.UserName}, press any key to attack!");
            Console.ReadKey();
            System.Console.WriteLine();
            Console.WriteLine("\n                           G A M E P L A Y");
            Console.WriteLine($"{player2.UserName} attacks!");
            System.Console.WriteLine();
            player2.attack.Attack();
            ManageHealth(startingPlayer, player1, player2);
            startingPlayer = true; // To let player1 go first next time
        }


        // Resetting the players' attack strength and defensive power for each turn, but max power for whole round stays the same
        player1.attackStrength = Character.AttackStrengthUse(player1.maxPower);
        player2.attackStrength = Character.AttackStrengthUse(player2.maxPower);
        player1.defenseStrength = Character.AttackStrengthUse(player1.maxPower);
        player2.defenseStrength = Character.AttackStrengthUse(player2.maxPower);


    }

}



static void ManageHealth(bool startingPlayer, Character player1, Character player2)
{
    Console.WriteLine("\nCalculating damage...");
    double typeBonus = 1;

    if (startingPlayer)
    {
        if (((player1.MovieCharacter == "Jack Sparrow") && (player2.MovieCharacter == "Will Turner")) || ((player1.MovieCharacter == "Will Turner") && (player2.MovieCharacter == "Davy Jones")) || ((player1.MovieCharacter == "Davy Jones") && (player2.MovieCharacter == "Jack Sparrow")))
        {
            Console.WriteLine($"{player1.MovieCharacter}'s attack was 20% more effective!");
            typeBonus = 1.2;
        }

        double damageDealt = ((player1.attackStrength - player2.defenseStrength) * (typeBonus));

        if (damageDealt > 0)
        {
            player2.health -= damageDealt;
            Console.WriteLine($"{player2.UserName}'s health: -{Math.Round(damageDealt, 2)}");
        }
        else if (damageDealt < 0)
        {
            Console.WriteLine($"Oops, looks like {player2.UserName} blocked this round of attack. Let's move on.");
        }
    }
    else
    {
        if (((player2.MovieCharacter == "Jack Sparrow") && (player1.MovieCharacter == "Will Turner")) || ((player2.MovieCharacter == "Will Turner") && (player1.MovieCharacter == "Davy Jones")) || ((player2.MovieCharacter == "Davy Jones") && (player1.MovieCharacter == "Jack Sparrow")))
        {
            Console.WriteLine($"{player2.MovieCharacter}'s attack was 20% more effective!");
            typeBonus = 1.2;
        }

        double damageDealt = ((player2.attackStrength - player1.defenseStrength) * (typeBonus));

        if (damageDealt > 0)
        {
            player1.health -= damageDealt;
            Console.WriteLine($"{player1.UserName}'s health: -{Math.Round(damageDealt, 2)}");
        }
        else if (damageDealt < 0)
        {
            Console.WriteLine($"Oops, looks like {player1.UserName} blocked this round of attack. Let's move on.");
        }
    }

    ViewStats(player1, player2);
}

static void ViewStats(Character player1, Character player2)
{
     Thread.Sleep(2000);
    Console.WriteLine("\n                      P L A Y E R   S T A T S");

    Console.WriteLine($"\nHere are the new stats for the next battle round:\nUsername: {player1.UserName}\nCharacter: {player1.MovieCharacter}\nAttack Strength: {player1.attackStrength}\nDefensive Power: {player1.defenseStrength} \nHealth: {player1.health}");
    Console.WriteLine($"\nUsername: {player2.UserName}\nCharacter: {player2.MovieCharacter}\nAttack Strength: {player2.attackStrength}\nDefensive Power: {player2.defenseStrength} \nHealth: {player2.health}");
    Console.WriteLine("\n                 R E T U R N  T O  G A M E P L A Y");
}

static void WinnerWinner(Character player1, Character player2)
{
    Console.WriteLine("\nCalculating final scores...");
    Console.WriteLine("And the winner is...");

    string winnerMsg = "";
    ConsoleColor winnerColor = ConsoleColor.White;

    if (player1.health > 0)
    {
        winnerMsg = $"Player 1 Wins!!! Congrats {player1.UserName} & {player1.MovieCharacter}!";
        winnerColor = ConsoleColor.Green;
    }
    else if (player2.health > 0)
    {
        winnerMsg = $"Player 2 Wins!!! Congrats {player2.UserName} & {player2.MovieCharacter}!";
        winnerColor = ConsoleColor.Yellow;
    }
    else
    {
        winnerMsg = "It's a tie!";
        winnerColor = ConsoleColor.Magenta;
    }

    int paddingSize = (Console.WindowWidth - winnerMsg.Length) / 2;
    string padding = new string(' ', paddingSize);

    Console.ForegroundColor = winnerColor;
    Console.WriteLine("\n" + padding + "╔" + new string('═', winnerMsg.Length + 2) + "╗");
    Console.WriteLine(padding + "║ " + winnerMsg + " ║");
    Console.WriteLine(padding + "╚" + new string('═', winnerMsg.Length + 2) + "╝\n");
    Console.ResetColor();
}

