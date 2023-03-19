using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectFloat _healthData;
        [SerializeField] private SpriteRenderer _heathbarSprite;

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
            Vector2 previousSize = _heathbarSprite.size;
            _heathbarSprite.size = new Vector2(currentHeath / _healthData.MaxValue.Value, previousSize.y);
        }
    }
}
