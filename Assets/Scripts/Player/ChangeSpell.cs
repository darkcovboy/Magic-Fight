using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.Events;
[RequireComponent(typeof(Player))]

public class ChangeSpell : MonoBehaviour
{
    [SerializeField] public List<Spell> _spells;
    [SerializeField] private Player _player;


    private StarterAssetsInputs _starterAssetsInputs;
    private int _currentSpellIndex = 0;

    public Spell CurrentSpell { get; private set; }
    public event UnityAction<Sprite> SpellChanged;

    private void Awake()
    {
        Change(_currentSpellIndex);
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        if (_starterAssetsInputs.nextSpell)
        {
            NextSpell();
            _starterAssetsInputs.nextSpell = false;
        }

        if (_starterAssetsInputs.previousSpell)
        {
            PreviousSpell();
            _starterAssetsInputs.previousSpell = false;
        }
    }

    private void NextSpell()
    {
        if (_currentSpellIndex == _spells.Count - 1)
            _currentSpellIndex = 0;
        else
            _currentSpellIndex++;

        Change(_currentSpellIndex);
    }

    private void PreviousSpell()
    {
        if (_currentSpellIndex == 0)
            _currentSpellIndex = _spells.Count - 1;
        else
            _currentSpellIndex--;

        Change(_currentSpellIndex);
    }

    private void Change(int index)
    {
        CurrentSpell = _spells[index];
        SpellChanged?.Invoke(CurrentSpell.GetLogo());
    }
}
