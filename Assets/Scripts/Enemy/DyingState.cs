using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DyingState : State
{
    private Animator _animator;
    private const string DiyngAnimation = "Diyng";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(DiyngAnimation);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
        Destroy(gameObject);
    }
}
