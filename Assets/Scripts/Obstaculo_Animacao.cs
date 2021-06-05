using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo_Animacao : MonoBehaviour
{
    [SerializeField]
    private Animator controlaObstaculos;

    [SerializeField]
    private Animator controlaObstaculos2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Jogador"))
        {
            controlaObstaculos.SetBool("playObstaculo", true);
            controlaObstaculos2.SetBool("playObstaculo2", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jogador"))
        {
            controlaObstaculos.SetBool("playObstaculo", false);
            controlaObstaculos2.SetBool("playObstaculo2", false);
        }
    }
   
}
