using PA4.Interfaces;
namespace PA4
{
    public class CannonFire : IAttack
    {
        public void Attack()
        {
            System.Console.WriteLine("Davy Jones has used Cannon Fire Attack...");
            // Random rnd = new Random();
            // character.maxPower = rnd.Next(1, 101);
            // System.Console.WriteLine($"Damage dealt: {character.maxPower}");
        }
    }
}