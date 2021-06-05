using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    [SerializeField]
    AudioSource somcoletavel;

    CharacterController controlador;
    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

    MoverJogador controlaJogador;

    [SerializeField]
    Text objetosTexto;

    private int contaObjetos = 0;

    [SerializeField]
    Text vidasTexto;

    private int vidas = 3;


    void Start()
    {
        controlador = GetComponent<CharacterController>();
        
        jogadorPosicaoOriginal = transform.position;
        jogadorOrientacaoOriginal = transform.rotation;
    }

    void Update()
    {
        vidasTexto.text = vidas.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        
         //RESPAWN

        if (other.tag == "Respawn")
        {
            StartCoroutine(Transporta());
            
            vidas = vidas - 1;
            if (vidas <= 0)
            {
                SceneManager.LoadScene("Game Over");
            }
        }
        
        //COLETAVEL

        if (other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            AtualizaObjetos();

           somcoletavel.gameObject.GetComponent<AudioSource>().Play();
        }

        //BOMBAS

        if (other.gameObject.CompareTag("Bomba"))
        {
            other.gameObject.SetActive(false);

            //somcoletavel.gameObject.GetComponent<AudioSource>().Play();
        }

        //MUDAR CENA FINAL - PORTAL
        
        if (other.gameObject.CompareTag("PortalMain"))
        {
            SceneManager.LoadScene("Final_1");
        }

    }

    //RESPAWN

    private IEnumerator Transporta()
    {
        GetComponent<MoverJogador>().enabled = false;

        transform.position = jogadorPosicaoOriginal;
        transform.rotation = jogadorOrientacaoOriginal;

        yield return new WaitForSeconds(0.1f);

        GetComponent<MoverJogador>().enabled = true;
    }

    //COLETAVEL + DESBLOQUEAR PORTAL   

    private void AtualizaObjetos()
    {
        contaObjetos ++;
        objetosTexto.text = "collected items:" + contaObjetos.ToString();
        if (GameObject.FindGameObjectsWithTag("Coletavel").Length <= 0) //dizia >= 3
        {
            // tirar a porta que dá acesso ao portal

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        //INIMIGO
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene("Game Over");
        }

        /*
        //MUDAR CENA FINAL
        if (collision.gameObject.CompareTag("PortalMain"))
        {
            SceneManager.LoadScene("Final_1");
        }
        */
    }


}


