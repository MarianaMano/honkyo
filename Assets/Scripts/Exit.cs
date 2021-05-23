using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        Fechar();

    }
    public void Fechar()

    {
        if (Input.GetKeyDown(KeyCode.E))
            Application.Quit();
        

    }

}
