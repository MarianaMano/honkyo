using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Update()
    {
        LoadScene();

    }
    public void LoadScene ()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SceneManager.LoadScene("Honkyo");

    }

}
