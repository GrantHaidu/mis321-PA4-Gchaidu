using PA4.Interfaces;
namespace PA4
{
    public class Character
    {
        public string UserName { get; set; }
         public string MovieCharacter { get; set; }

         public int maxPower { get; set; }

         public double health { get; set; }
         public int attackStrength { get; set; }
         public int defenseStrength { get; set; }

        public IAttack attack { get; set; }

        public IDefend defend { get; set; }

        public static int MaxPowerUse()
        {
            Random rnd = new Random();
            int rndAttackMaxPower = rnd.Next(1, 101);
            return rndAttackMaxPower;

        }
        
        public static int AttackStrengthUse(int maxPower)
        {
            Random rnd = new Random();
            int rndAttackStrength = rnd.Next(1, maxPower);
            return rndAttackStrength;

        }
        public static int DefensePowerUse(int maxPower)
        {
            Random rnd = new Random();
            int rndDefensePower = rnd.Next(1, maxPower);
            return rndDefensePower;

        }
        public void SetAttack(IAttack attack)
        {
            this.attack = attack;
        }
        public void SetDefend(IDefend defend)
        {
            this.defend = defend;
        }
        
    }
}