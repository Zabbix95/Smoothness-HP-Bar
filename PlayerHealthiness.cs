using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthiness : MonoBehaviour
{
    private int _currentHealth = 100;
    private int _meatAmount = 0; // ��� ���� � ������ �������� � ������� ���������� Satiety ��������� � ������� �������. ������ �� ���� ������� ����� �� ������� ����������� �������.

    public UnityAction<int> SatietyChanged;
    public UnityAction<int> HealthChanged;

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

    public void SatietyAlert(bool hungry)
    {
        _meatAmount = hungry ? --_meatAmount : ++_meatAmount;

        SatietyChanged?.Invoke(_meatAmount);
    }
    
    public void GetDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void GetHeal(int heal)
    {
        CurrentHealth += heal;
        HealthChanged?.Invoke(CurrentHealth);
    }
}
