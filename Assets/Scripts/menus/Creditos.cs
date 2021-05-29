using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Creditos : MonoBehaviour
{
    private void Update()
    {
        LoadScene();

    }
    public void LoadScene()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SceneManager.LoadScene("Créditos");


    }
}

    
            

