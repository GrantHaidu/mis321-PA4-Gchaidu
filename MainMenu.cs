namespace PA4
{
    public class MainMenu
    {
        public int WhichCharacter()
        {
            Console.Clear();
            System.Console.WriteLine("WELCOME TO PIRATES OF THE CARIBBEAN !!");
            System.Console.WriteLine("Which character would you like to play as? Type the number and press enter.");
            System.Console.WriteLine();
            System.Console.WriteLine("1. Jack Sparrow");
            System.Console.WriteLine();
            System.Console.WriteLine("2. Davy Jones");
            System.Console.WriteLine();
            System.Console.WriteLine("3. Will Turner");
            System.Console.WriteLine();
            int WhichCharacter = int.Parse(System.Console.ReadLine());
            while (WhichCharacter != 1 && WhichCharacter != 2 && WhichCharacter != 3)
            {
                Console.Clear();
                System.Console.WriteLine("P L E A S E  C H O O S E  A  V A L I D  N U M B E R.");
                System.Console.WriteLine();
                System.Console.WriteLine("type the number and press enter.");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Jack Sparrow");
                System.Console.WriteLine();
                System.Console.WriteLine("2. Davy Jones");
                System.Console.WriteLine();
                System.Console.WriteLine("3. Will Turner");
                System.Console.WriteLine();
                WhichCharacter = int.Parse(System.Console.ReadLine());
            }
            return WhichCharacter;

        }
    }
}