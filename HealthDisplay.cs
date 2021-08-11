using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _healthbar;    
    [SerializeField] private float _smoothTime;

    private float _smoothRunningTime;    
    private bool _coroutineIsRunning;
    private Coroutine _healthChanging;

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
        if (_healthChanging == null)
            _healthChanging = StartCoroutine(DisplayHealthValue(currenthealth));         
    }    

    private IEnumerator DisplayHealthValue(int targetHealth)
    {        
        _smoothRunningTime = 0;
        while (_healthbar.value != targetHealth)
        {
            _smoothRunningTime += Time.deltaTime;
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, targetHealth, _smoothRunningTime/_smoothTime);                       
            yield return null;            
        }        
    }

}
