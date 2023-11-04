using System;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Patterns.DZ2_Mediator
{
    public class Player : MonoBehaviour, IHealable, IHealthTaker, IDamageable, ICoinPicker
    {
        [SerializeField] private float _health;
        [SerializeField] private int _level;

        public float Health { get => _health; private set => _health = value; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }
        public int Coins { get; private set; }

        public event Action<float> HealthChanged;
        public event Action Died;
        public event Action<int> LevelChanged;

        private void Start()
        {
            MaxHealth = 100;
            MinHealth = 0;
            Health = 20;

            HealthChanged?.Invoke(Health);
            LevelChanged?.Invoke(_level);
        }

        public void Damage(float damage)
        {
            Health -= damage;
            HealthChanged?.Invoke(Health);

            if (Health <= MinHealth)
            {
                Debug.Log("����!");
                Died.Invoke();
                return;
            }
        }

        public void Heal(float healValue)
        {
            if (Health >= MaxHealth)
            {
                Debug.Log("�������� ��");
                return;
            }

            Health += healValue;

            HealthChanged?.Invoke(Health);
        }

        public void IncreaseLevel()
        {
            _level++;
            LevelChanged.Invoke(_level);
        }

        public void ResetStats()
        {
            Health = 80;
            HealthChanged.Invoke(Health);

            _level = 1;
            LevelChanged.Invoke(_level);
        }

        public void AddCoins(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            Coins += value;
            //Debug.Log(Coins);
        }
    }
}