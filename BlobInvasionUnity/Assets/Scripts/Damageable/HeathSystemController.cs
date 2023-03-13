using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class HeathSystemController : MonoBehaviour
    {
        [SerializeField] private Healthbar _healthbar;
        [SerializeField] private HitPoints _hitPoints;

        private void OnEnable()
        {
            _hitPoints.OnDamageTaken += _healthbar.UpdateHeathbar;
        }
        
        private void OnDisable()
        {
            _hitPoints.OnDamageTaken -= _healthbar.UpdateHeathbar;
        }
    }
}