using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    [SerializeField]
    AudioSource somcoletavel;
    [SerializeField]
    AudioSource sombomba;

   


    CharacterController controlador;
    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

    MoverJogador controlaJogador;

    [SerializeField]
    GameObject coverPortal;

    [SerializeField]
    Text objetosTexto;

    

    private int contaObjetos = 0;

    [SerializeField]
    Text vidasTexto;

    private int vidas = 3;

    public Text coverPortalTexto;

    


    void Start()
    {

        // CANVAS COVER PORTAL

        coverPortalTexto.enabled = false;

        // RESPAWN

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
            
            vidas -= 1;
            Debug.Log("- 1");
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

            vidas -= 1;
            if (vidas <= 0)
            {
                SceneManager.LoadScene("Game Over");
            }

            Debug.Log("CABUMM!!!");

            sombomba.gameObject.GetComponent<AudioSource>().Play();
        }

        //INIMIGO

        if (other.tag == ("Inimigo"))
        {
            SceneManager.LoadScene("Game Over");
        }

        //MUDAR CENA FINAL - PORTAL

        if (other.tag == ("PortalMain"))
        {
            SceneManager.LoadScene("Final_1");
        }

        //CANVAS COVER PORTAL

        if (other.tag == "coverPortal")
        {
            coverPortalTexto.enabled = true;
        }
        else
        {
            coverPortalTexto.enabled = false;
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

        if (contaObjetos >= 3)
        {
            coverPortal.SetActive(false);

        }
        else
        {
            coverPortal.SetActive(true);

        }
  
    }


    private void OnCollisionEnter(Collision collision)
    {

        //MUDAR CENA FINAL - PORTAL

        if (collision.gameObject.CompareTag("PortalMain"))
        {
            Debug.Log("mudar cena");
            SceneManager.LoadScene("Final_1");
        }

    }


}


