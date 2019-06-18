using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider newBoxCollider;

    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 250;
    [SerializeField] int hits = 3;


    ScoreBoard scoreBoard;

    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>(); //during runtime, find a reference to scoreboard, and assigns scoreBoard to it
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit); //updates scoreboard
        hits--;
        if (hits < 1)
        {
            KillEnemy();
        }
        
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity); //creates the explosion prefab and plays it on death
        fx.transform.parent = parent; //attaches its transform to parent to make the hierarchy easier to read
        Destroy(gameObject); //destroys self
    }

    void AddNonTriggerBoxCollider()
    {
        newBoxCollider = gameObject.AddComponent<BoxCollider>();
        newBoxCollider.isTrigger = false;
        
    }

    
}
