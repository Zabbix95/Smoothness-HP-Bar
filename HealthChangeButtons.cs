using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangeButtons : MonoBehaviour
{    

    private int _damageValue = 10;
    private int _healValue = 10;
    private PlayerHealth _playerHealthiness;   

    private void Start()
    {
        _playerHealthiness = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageButtonClick()
    {
        _playerHealthiness.ApplyDamage(_damageValue);
    }

    public void OnHealButtonClick()
    {
        _playerHealthiness.ApplyHeal(_healValue);
    }
    
}
