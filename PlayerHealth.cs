using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private int _maxHealth = 100;
   

    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            if ((value >= 0) && (value <= _maxHealth))
            {
                _currentHealth = value;
            }
        }
    }
   
    public UnityAction<int> HealthChanged;    
    
    public void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void ApplyHeal(int heal)
    {
        CurrentHealth += heal;
        HealthChanged?.Invoke(CurrentHealth);
    }
}
