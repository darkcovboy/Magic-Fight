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
    [SerializeField] private float _timeDelayManaRegenaration;
    [SerializeField] private int _manaRegenaration;
    [SerializeField] private int _money;


    public event UnityAction<int,int> ManaChanged;
    public event UnityAction<int, int> HealthChanged;

    public void TakeMana(int manacost)
    {
        ManaChanged?.Invoke(_mana, _maxMana);
        _mana -= manacost;
        StartCoroutine(RegenerateMana());
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

    private IEnumerator RegenerateMana()
    {
        while (_mana < _maxMana)
        {
            _mana += _manaRegenaration;
            ManaChanged?.Invoke(_mana, _maxMana);
            yield return new WaitForSecondsRealtime(_timeDelayManaRegenaration);
        }
    }
}
