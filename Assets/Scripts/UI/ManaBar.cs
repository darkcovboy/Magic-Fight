using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ManaChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.ManaChanged -= OnValueChanged;
    }
}
