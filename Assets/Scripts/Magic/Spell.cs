using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected int Damage;
    [SerializeField] protected Sprite Logo;
    [SerializeField] protected int Manacost;
    [SerializeField] protected AudioClip AudioClip;
    [SerializeField] private GameObject _afterDiyngParticles;

    public int GetManacost()
    {
        return Manacost;
    }

    public Sprite GetLogo()
    {
        return Logo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            GameObject afterDiyngParticles = (GameObject)Instantiate(_afterDiyngParticles, transform.position, transform.rotation);
            Destroy(afterDiyngParticles, afterDiyngParticles.GetComponent<ParticleSystem>().startLifetime);
            Destroy(gameObject);
        }

        if(other.gameObject.layer == 6)
        {
            GameObject afterDiyngParticles = (GameObject)Instantiate(_afterDiyngParticles, transform.position, transform.rotation);
            Destroy(afterDiyngParticles, afterDiyngParticles.GetComponent<ParticleSystem>().startLifetime);
            Destroy(gameObject);
        }
    }
}
