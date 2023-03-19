using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private SpriteRenderer _heathbarSprite;

        private void OnEnable()
        {
            _health.OnDamageTaken += UpdateHealthbar;
        }

        private void OnDisable()
        {
            _health.OnDamageTaken -= UpdateHealthbar;
        }

        private void UpdateHealthbar(float currentHeath, float maxHealth)
        {
            Vector2 previousSize = _heathbarSprite.size;
            _heathbarSprite.size = new Vector2(currentHeath / maxHealth, previousSize.y);
        }
    }
}
