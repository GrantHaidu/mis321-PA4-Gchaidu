using PA4.Interfaces;
namespace PA4
{
    public class JackSparrow : Character
    {
        public JackSparrow()
        {
            attack = new Distract();
            defend = new Defense();
        }
    }
}