using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{

    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

    [SerializeField]
    Text objetosTexto;

    private int contaObjetos = 0;

    void Start()
    {
        jogadorPosicaoOriginal = transform.position;
        jogadorOrientacaoOriginal = transform.rotation;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            transform.position = jogadorPosicaoOriginal;
            transform.rotation = jogadorOrientacaoOriginal;
            // SceneManager.LoadScene("Game Over");
        }

        if (other.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);

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
