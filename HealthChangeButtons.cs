using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangeButtons : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 100;

    private int _damageHealValue = 10;

    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            if ((value >= 0) && (value <= 100))
            {
                _currentHealth = value;
            }
        }
    }
    public event UnityAction<int> HealthChanged;

    public void OnDamageButtonClick()
    {
        CurrentHealth -= _damageHealValue;
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void OnHealButtonClick()
    {
        CurrentHealth += _damageHealValue;
        HealthChanged?.Invoke(CurrentHealth);
    }
    
}
