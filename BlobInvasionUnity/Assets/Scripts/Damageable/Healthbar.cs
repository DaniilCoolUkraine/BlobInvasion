using UnityEngine;
using UnityEngine.UI;

namespace BlobInvasion.Damageable
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectFloat _healthData;
        [SerializeField] private Image _heathbarImage;

        private void OnEnable()
        {
            _healthData.OnValueChanged += UpdateHeathbar;
        }

        private void OnDisable()
        {
            _healthData.OnValueChanged -= UpdateHeathbar;
        }

        private void UpdateHeathbar(float currentHeath)
        {
            _heathbarImage.fillAmount = currentHeath / _healthData.MaxValue.Value;
        }
    }
}
