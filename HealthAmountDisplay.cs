using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthAmountDisplay : MonoBehaviour
{
    [SerializeField] private HealthChangeButtons _healthChangeButtons;
    [SerializeField] private Slider _healthbar;
    [SerializeField] private float _displayedHealth;
    [SerializeField] private float _smoothness = 0.1f;

    private int _targetHealth;

    private void Awake()
    {
        _healthbar = GetComponent<Slider>();
        _healthChangeButtons = GetComponentInParent<HealthChangeButtons>();
    }

    private void OnEnable()
    {
        _healthChangeButtons.HealthChanged += OnHealthChanged;
    }

    private void Start()
    {
        _displayedHealth = _healthChangeButtons.CurrentHealth;
    }

    private void OnDisable()
    {
        _healthChangeButtons.HealthChanged -= OnHealthChanged;
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
            _displayedHealth = _healthbar.value;            
            yield return null;
            _displayedHealth = _targetHealth;
        }       
    }

}
