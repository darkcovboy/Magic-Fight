using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int Health;
    [SerializeField] public int Reward;

    [SerializeField] private Player _target;
    private Animator _animator;

    public Player Target => _target;

    public event UnityAction<Enemy> Diyng;

    public void Init(Player target)
    {
        _target = target;

    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            _animator.Play("Dying");
            Diyng?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
