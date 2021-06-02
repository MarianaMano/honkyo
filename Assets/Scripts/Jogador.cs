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

    [SerializeField]
    Text objetosTexto;

    private int contaObjetos = 0;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        
        jogadorPosicaoOriginal = transform.position;
        jogadorOrientacaoOriginal = transform.rotation;
        Debug.Log("posição " + jogadorPosicaoOriginal);
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Respawn"))
        {
            transform.position = jogadorPosicaoOriginal;
            Debug.Log("posição alvo " + transform.position);

            // controlador.Move(jogadorPosicaoOriginal); 
            
            // SceneManager.LoadScene("Game Over");
        }

        if (other.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            AtualizaObjetos();

        }
    }

    private void AtualizaObjetos()
    {
        contaObjetos ++;
        objetosTexto.text = "collected objects:" + contaObjetos.ToString();
        if (GameObject.FindGameObjectsWithTag("Coletavel").Length <= 0) //dizia >= 3
        {
            // tirar a porta que dá acesso ao portal

        }
    }
  
}
