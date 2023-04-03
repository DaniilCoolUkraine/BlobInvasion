using BlobInvasion.Shop;
using UnityEngine;

namespace BlobInvasion.UI
{
    public class ShopUiController : MonoBehaviour
    {
        [SerializeField] private ShopServiceSO _shopServiceSO;

        [Space(10)]
        
        [SerializeField] private ShopSlotUiController _buySlotPrefab;

        [Space(5)]

        [SerializeField] private Transform _weaponsHolder;
        [SerializeField] private Transform _levelsHolder;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            ShopSlotUiController temporarySlot;
            
            foreach (var weapon in _shopServiceSO.Weapons)
            {
                temporarySlot = Instantiate(_buySlotPrefab, _weaponsHolder);
                temporarySlot.Init(weapon);

                temporarySlot.OnTryToBuy += TryToBuy;
            }

            foreach (var level in _shopServiceSO.Levels)
            {
                temporarySlot = Instantiate(_buySlotPrefab, _levelsHolder);
                temporarySlot.Init(level);
                
                temporarySlot.OnTryToBuy += TryToBuy;
            }
        }
        
        private void TryToBuy(ShopEntitySO shopEntity)
        {
            bool isBuied = _shopServiceSO.TryBuyEntity(shopEntity);
            
            shopEntity.TryToBuy(isBuied);
        }
    }
}