using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private LayerMask _aimColliderMask = new LayerMask();
    [SerializeField] private Transform _debugTransform;
    [SerializeField] private Transform _prProjectile;
    [SerializeField] private Transform _spawnPlace;
    [SerializeField] private Player _player;

    private StarterAssetsInputs _starterAssetsInputs;
    private Animator _animator;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        if (_starterAssetsInputs.shoot && _player.GetMana() > 0)
        {
            _player.TakeMana(_player.CurrentSpell.GetManacost());
            Vector3 aimDir = (mouseWorldPosition - _spawnPlace.position).normalized;
            Instantiate(_player.CurrentSpell, _spawnPlace.position, Quaternion.LookRotation(aimDir, Vector3.up));
            _animator.Play("Shoot");
            _starterAssetsInputs.shoot = false;
        }
    }
}
