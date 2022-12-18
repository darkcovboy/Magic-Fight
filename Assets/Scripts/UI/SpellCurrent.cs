using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCurrent : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image image;

    private void OnEnable()
    {
        _player.SpellChanged += ChangeSpellIcon;
    }

    private void OnDisable()
    {
        _player.SpellChanged -= ChangeSpellIcon;
    }

    private void ChangeSpellIcon(Sprite icon)
    {
        image.sprite = icon;
    }
}
