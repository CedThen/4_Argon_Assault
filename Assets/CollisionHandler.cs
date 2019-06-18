using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelDelay = 1f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        //must disable controls, by talking to player control script
        SendMessage("OnPlayerDeath");
        Invoke("ReloadLevel", levelDelay);
        deathFX.SetActive(true);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
