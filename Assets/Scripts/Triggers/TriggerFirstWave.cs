using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFirstWave : MonoBehaviour
{
    [SerializeField] private GameObject _scroolPrefab;
    [SerializeField] private Transform _scroolPrefabPlace;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_scroolPrefab, _scroolPrefabPlace);
        _spawner.gameObject.SetActive(true);
        _audioSource.Play();
        gameObject.SetActive(false);
    }
}
