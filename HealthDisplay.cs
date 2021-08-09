using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _healthbar;    
    [SerializeField] private float _pathTime;

    private float _pathRunningtime;
    private int _targetHealth;

    private void Awake()
    {
        _healthbar = GetComponent<Slider>();        
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnHealthChanged;
    }    

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int currenthealth)
    {
        _targetHealth = currenthealth;
        StartCoroutine(CheckQueueCorutines());         
    }

    private IEnumerator CheckQueueCorutines()
    {
        yield return StartCoroutine(DisplayHealthValue());
    }

    private IEnumerator DisplayHealthValue()
    {
        _pathRunningtime = 0;
        while (_healthbar.value != _targetHealth)
        {
            _pathRunningtime += Time.deltaTime;
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, _targetHealth, _pathRunningtime/_pathTime);                       
            yield return null;            
        }       
    }

}
