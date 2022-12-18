using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _mana;
    [SerializeField] private int _maxMana;
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private float _timeDelayManaRegenaration;
    [SerializeField] private int _manaRegenaration;
    [SerializeField] private int _money;

    public Spell CurrentSpell { get; private set; }

    public event UnityAction<int,int> ManaChanged;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<Sprite> SpellChanged;
    private float _currentTime;
    private StarterAssetsInputs _starterAssetsInputs;
    private int _currentSpellIndex = 0;

    private void Awake()
    {
        ChangeSpell(_currentSpellIndex);
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    public void TakeMana(int manacost)
    {
        ManaChanged?.Invoke(_mana, _maxMana);
        _mana -= manacost;
    }

    public int GetMana()
    {
        return _mana;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int reward)
    {
        _money += reward;
    }

    private void Update()
    {
        if (_mana < _maxMana)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _timeDelayManaRegenaration)
            {
                _currentTime = 0;
                _mana += _manaRegenaration;
                ManaChanged?.Invoke(_mana, _maxMana);
            }
        }

        if(_starterAssetsInputs.nextSpell)
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

        ChangeSpell(_currentSpellIndex);
    }

    private void PreviousSpell()
    {
        if (_currentSpellIndex == 0)
            _currentSpellIndex = _spells.Count - 1;
        else
            _currentSpellIndex--;

        ChangeSpell(_currentSpellIndex);
    }

    private void ChangeSpell(int index)
    {
        CurrentSpell = _spells[index];
        SpellChanged?.Invoke(CurrentSpell.GetLogo());
    }
}
