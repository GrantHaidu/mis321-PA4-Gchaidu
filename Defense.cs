using PA4.Interfaces;
namespace PA4
{
    public class Defense : IDefend
    {
        public void Defend()
        {
            System.Console.WriteLine("Defense has been used...");
        }
        
    }
}