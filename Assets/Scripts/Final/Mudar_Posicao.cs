using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudar_Posicao : MonoBehaviour
{

    [SerializeField]
    GameObject jogador;

    [SerializeField]
    GameObject jogador1;

    [SerializeField]
    GameObject jogador2;

    [SerializeField]
    GameObject jogador3;

    private void Start()
    {
        jogador.SetActive(true);
        jogador1.SetActive(false);
        jogador2.SetActive(false);
        jogador3.SetActive(false);

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal1")
        {
            Debug.Log("portal1");
            jogador.SetActive(false);
            jogador1.SetActive(true);
        }
        if (other.tag == "Portal2")
        {
            Debug.Log("portal2");
            jogador1.SetActive(false);
            jogador2.SetActive(true);
        }

        if(other.tag == "Portal3")
        {
            Debug.Log("portal3");
            jogador2.SetActive(false);
            jogador3.SetActive(true);
        }
    }
}
