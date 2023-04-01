using System;
using BlobInvasion.Enemies;
using UnityEngine;

namespace BlobInvasion.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private BossController _boss;
        [SerializeField] private PauseMenu _menu;

        private void OnEnable()
        {
            _boss.OnBossKilled += _menu.EnableWinScreen;
        }
        
        private void OnDisable()
        {
            _boss.OnBossKilled -= _menu.EnableWinScreen;
        }
    }
}