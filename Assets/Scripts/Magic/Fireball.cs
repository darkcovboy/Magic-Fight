using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : Spell
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        AudioSource.PlayClipAtPoint(AudioClip, transform.position);
    }

    private void Start()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }
}
