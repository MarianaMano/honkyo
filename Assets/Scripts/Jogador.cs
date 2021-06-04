using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{

    CharacterController controlador;
    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

    MoverJogador controlaJogador;

    GameObject jogador;


    [SerializeField]
    Text objetosTexto;

    private int contaObjetos = 0;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        
        jogadorPosicaoOriginal = transform.position;
        jogadorOrientacaoOriginal = transform.rotation;
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("qualquer coisa " + other.tag);
        if(other.tag == "Respawn")
        {
            StartCoroutine(Transporta());
        }
        

        if (other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            AtualizaObjetos();

        }

        if (other.gameObject.CompareTag("Portal (1)"))
        {
            Debug.Log("portal 1");
            jogador.transform.position = new Vector3(-31, -5, -9);
        }
    }

    private IEnumerator Transporta()
    {
        GetComponent<MoverJogador>().enabled = false;

        transform.position = jogadorPosicaoOriginal;
        transform.rotation = jogadorOrientacaoOriginal;

        yield return new WaitForSeconds(0.1f);

        GetComponent<MoverJogador>().enabled = true;
    }

    private void AtualizaObjetos()
    {
        contaObjetos ++;
        objetosTexto.text = "collected items:" + contaObjetos.ToString();
        if (GameObject.FindGameObjectsWithTag("Coletavel").Length <= 0) //dizia >= 3
        {
            // tirar a porta que dá acesso ao portal

        }
    }

    /*Portal

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Portal (1)"))
        {
            Debug.Log("portal 1");
            transform.SetPositionAndRotation(new Vector3(-31, -5, -9), new Quaternion(0, -90, 0, 0 ));

        }
    }
     */


}


