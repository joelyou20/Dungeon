using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthSlider;
    private int? _health;
    private TMP_Text _text;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        _text = GameObject.Find("text").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _healthSlider.value = _health.Value;
        _text.text = _health.Value.ToString();
    }


    public void Set(int health)
    {
        _health = health;
    }
}