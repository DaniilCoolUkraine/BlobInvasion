using UnityEngine;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewLevelShopEntity", menuName = "ScriptableObjects/LevelShopEntity", order = 0)]
    public class LevelShopEntitySO : ShopEntitySO
    {
        [SerializeField] private string _sceneName;

        public string SceneName => _sceneName;
    }
}