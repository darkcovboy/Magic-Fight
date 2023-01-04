using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;
    private const string AttackAnimimation = "Attack";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <=0)
        {
            Attack(Target);
            _lastAttackTime = _delay;    
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player Target)
    {
        _animator.Play(AttackAnimimation);
        Target.ApplyDamage(_damage);
    }
}
