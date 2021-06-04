using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis_final : MonoBehaviour
{

    public GameObject maca;
    public GameObject pomba;
    public GameObject coracao;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            maca.GetComponent<Animator>().Play("maca");
            coracao.GetComponent<Animator>().Play("coraçao");
            pomba.GetComponent<Animator>().Play("pomba");
        }
        
    }
}
