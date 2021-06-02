using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class e : MonoBehaviour
{
    bool pause;

    [SerializeField]
    GameObject panel;
    private void Start()

    {
        pause = false;

            panel.gameObject.SetActive(false);
    }
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = true;
            panel.gameObject.SetActive(true);
            Time.timeScale = 0f;

        }

        if (pause == true) 
        {
            if (Input.GetKeyDown(KeyCode.M))

                SceneManager.LoadScene("Menu Inicial");

            if (Input.GetKeyDown(KeyCode.E))
                Application.Quit();

            if (Input.GetKeyDown(KeyCode.H))

                SceneManager.LoadScene("Help");

            if (Input.GetKeyDown(KeyCode.R))
            {
                    panel.gameObject.SetActive(false);

                Time.timeScale = 1f;
                pause = false;
            }


        }
       
        




     

        

    }

  

   
}
