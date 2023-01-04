using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private const string AttackAnimation = "Attack";

    private float _lastAttackTime;
    private Animator _animator;
    private bool _canAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_canAttack) return;
        _canAttack = false;

        StartCoroutine(Reload());
    }

    private void Attack(Player Target)
    {
        _animator.Play(AttackAnimation);
        Target.ApplyDamage(_damage);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_delay);
        _canAttack = true;
    }
}
