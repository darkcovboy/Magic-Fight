using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveScript : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _spawner.NextWave();
            Destroy(gameObject);
        }
    }
}
