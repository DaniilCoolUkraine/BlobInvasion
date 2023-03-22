using BlobInvasion.Collectable.Props.Bonuses;

namespace BlobInvasion.Damageable
{
    public class PlayerHealth : Health, IPowerable
    {
        public bool IsActive { get; set; }
        
        public void Apply(params object[] param)
        {
            this.enabled = false;
        }

        public void Discard(params object[] param)
        {
            this.enabled = true;
        }
    }
}