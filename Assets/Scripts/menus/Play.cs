using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private void Update()
    {
        LoadScene();

    }
    public void LoadScene()

    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("Honkyo");
        }
          

    }

}
