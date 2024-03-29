﻿using UnityEngine;

namespace BlobInvasion.Enemies
{
    [CreateAssetMenu(fileName = "NewBossAttackData", menuName = "ScriptableObjects/BossAttackData", order = 0)]
    public class BossAttackDataSO : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackRadius;

        public int Damage => _damage;
        public float AttackRadius => _attackRadius;
    }
}