using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class Coletaveis_final : MonoBehaviour
{
    [SerializeField] 
    float tempoVitoria = 5;
    private bool contarTempo = true;

    private Animator coletaveis;

    private void Start()
    {
        coletaveis = GetComponent<Animator>();
     

    }

   
    private void Update()
    {
        Animacao();
    }

    void Animacao()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Debug.Log("animar");
            coletaveis.SetBool("playAnimacao", true);

            if (contarTempo)
            {
                if (tempoVitoria > 0)
                {
                    tempoVitoria -= Time.deltaTime;
                }
                else
                {
                    tempoVitoria = 0;
                    contarTempo = false;
                    SceneManager.LoadScene("Victory");
                }
            }
        }
        
    }

}

  
