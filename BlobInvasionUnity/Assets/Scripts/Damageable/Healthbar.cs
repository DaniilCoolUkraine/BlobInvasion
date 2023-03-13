using UnityEngine;
using UnityEngine.UI;

namespace BlobInvasion.Damageable
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Image _heathbarImage;

        public void UpdateHeathbar(float maxHeath, float currentHeath)
        {
            _heathbarImage.fillAmount = currentHeath / maxHeath;
        }
    }
}
