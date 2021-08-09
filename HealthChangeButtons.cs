using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangeButtons : MonoBehaviour
{    
    [SerializeField]private PlayerHealth _playerHealth;   

    private int _damageValue = 10;
    private int _healValue = 10;    

    public void OnDamageButtonClick()
    {
        _playerHealth.ApplyDamage(_damageValue);
    }

    public void OnHealButtonClick()
    {
        _playerHealth.ApplyHeal(_healValue);
    }
    
}
