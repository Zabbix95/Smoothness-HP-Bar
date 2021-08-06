using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthAmountDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealthiness _playerHealthiness;
    [SerializeField] private Slider _healthbar;    
    [SerializeField] private float _smoothness = 0.1f;

    private int _targetHealth;

    private void Awake()
    {
        _healthbar = GetComponent<Slider>();
        _playerHealthiness = FindObjectOfType<PlayerHealthiness>();
    }

    private void OnEnable()
    {
        _playerHealthiness.HealthChanged += OnHealthChanged;
    }    

    private void OnDisable()
    {
        _playerHealthiness.HealthChanged -= OnHealthChanged;
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
        while (_healthbar.value != _targetHealth)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, _targetHealth, _smoothness);                       
            yield return null;            
        }       
    }

}
