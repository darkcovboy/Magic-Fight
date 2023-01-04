using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCurrent : MonoBehaviour
{
    [SerializeField] private ChangeSpell _changeSpell;
    [SerializeField] private Image image;

    private void OnEnable()
    {
        _changeSpell.SpellChanged += ChangeSpellIcon;
    }

    private void OnDisable()
    {
        _changeSpell.SpellChanged -= ChangeSpellIcon;
    }

    private void ChangeSpellIcon(Sprite icon)
    {
        image.sprite = icon;
    }
}
