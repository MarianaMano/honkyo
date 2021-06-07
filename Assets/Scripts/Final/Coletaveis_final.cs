using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis_final : MonoBehaviour
{

    private Animator coletaveis;

    private void Start()
    {
        coletaveis = GetComponent<Animator>();
    }

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("animar");
            coletaveis.SetBool("playAnimacao", true);
        }
    }
    
}
