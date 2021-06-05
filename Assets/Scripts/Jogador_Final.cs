using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //MUDAR DE PORTAL

        if (other.tag == "Portal1")
        {
            Debug.Log("portal 1");

        }
    }

}
