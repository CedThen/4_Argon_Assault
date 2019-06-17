using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider newBoxCollider;

    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 250;

    ScoreBoard scoreBoard;

    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>(); //during runtime, find a reference to scoreboard
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        
        Destroy(gameObject);

        scoreBoard.ScoreHit(scorePerHit);
    }

    void AddNonTriggerBoxCollider()
    {
        newBoxCollider = gameObject.AddComponent<BoxCollider>();
        newBoxCollider.isTrigger = false;
        
    }

    
}
