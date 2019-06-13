using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        //if more than one music player in scene, destroy ourselves. else keep ourselves around
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        print("number of music players");
        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    

    
}
