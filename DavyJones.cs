using PA4.Interfaces;
namespace PA4
{
    public class DavyJones : Character
    {
        public DavyJones()
        {
            attack = new CannonFire();
            defend = new Defense();
      
        }
    }
}