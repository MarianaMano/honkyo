using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

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
    }
}
