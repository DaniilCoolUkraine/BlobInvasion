using System;
using BlobInvasion.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlobInvasion.UI
{
    public class ShopSlotUiController : MonoBehaviour
    {
        public event Action<ShopEntitySO> OnTryToBuy;

        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        [SerializeField] private Button _button;

        private ShopEntitySO _weapon;
        
        public void Init(ShopEntitySO weaponShopEntity)
        {
            _weapon = weaponShopEntity;

            _icon.sprite = weaponShopEntity.Icon;
            SetBuied(_weapon.IsBuied);

            _weapon.OnBuied += SetBuied;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(TryToBuy);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(TryToBuy);
        }

        private void TryToBuy()
        {
            OnTryToBuy?.Invoke(_weapon);
        }

        private void SetBuied(bool isBuied)
        {
            if (isBuied)
            {
                _textMeshPro.text = $"{_weapon.Name}";
            }
            else
            {
                _textMeshPro.text = $"{_weapon.Name} \n {_weapon.Price}";
            }
        }
    }
}