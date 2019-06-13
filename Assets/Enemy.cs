using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider newBoxCollider;

    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;

    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        print("particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }

    void AddNonTriggerBoxCollider()
    {
        newBoxCollider = gameObject.AddComponent<BoxCollider>();
        newBoxCollider.isTrigger = false;
        
    }

    
}
