using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangeButtons : MonoBehaviour
{    

    private int _damageValue = 10;
    private int _healValue = 10;
    private PlayerHealthiness _playerHealthiness;   

    private void Start()
    {
        _playerHealthiness = FindObjectOfType<PlayerHealthiness>();
    }

    public void OnDamageButtonClick()
    {
        _playerHealthiness.GetDamage(_damageValue);
    }

    public void OnHealButtonClick()
    {
        _playerHealthiness.GetHeal(_healValue);
    }
    
}
