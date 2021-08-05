using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangeButtons : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 100;

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
        CurrentHealth -= 10;
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void OnHealButtonClick()
    {
        CurrentHealth += 10;
        HealthChanged?.Invoke(CurrentHealth);
    }
    
}
