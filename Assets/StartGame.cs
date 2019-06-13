using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToGame", 2f);
    }

    void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
