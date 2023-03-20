using BlobInvasion.Collectable.Props.Bonuses;

namespace BlobInvasion.Damageable
{
    public class PlayerHealth : Health, IPowerable
    {
        public void ApplyPowerUp(params object[] param)
        {
            if ((int) param[0] == 1)
            {
                this.enabled = true;
                return;
            }
            this.enabled = false;
        }

    }
}