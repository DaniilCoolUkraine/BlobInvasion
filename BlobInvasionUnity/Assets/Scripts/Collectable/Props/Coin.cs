using UnityEngine;

namespace BlobInvasion.Collectable.Props
{
    public class Coin : Item
    {
        public override void Collect(GameObject collector)
        {
            AddCoin();
            base.Collect(collector);
        }

        // todo rewrite it to playerPrefs
        private void AddCoin()
        {
            Debug.Log("coin added");
        }
    }
}