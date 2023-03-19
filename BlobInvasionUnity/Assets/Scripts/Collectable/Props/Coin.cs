using UnityEngine;

namespace BlobInvasion.Collectable.Props
{
    public class Coin : Item
    {
        [SerializeField] private ScriptableObjectInt _coinData;

        public override void Collect(GameObject collector)
        {
            AddCoin();
            base.Collect(collector);
        }
        
        private void AddCoin()
        {
            int newValue = _coinData.Value.Value + 1;
            _coinData.ChangeValue(newValue, true);
        }
        
       
    }
}