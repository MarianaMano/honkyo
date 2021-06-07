using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis_final : MonoBehaviour
{

    [SerializeField]
    private Animator maca;

    [SerializeField]
    private Animator pomba;

    [SerializeField]
    private Animator coracao;

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PousaColetaveis")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                maca.SetBool("playMaca", true);
                pomba.SetBool("playPomba", true);
                coracao.SetBool("playCoracao", true);
            }
        }
        
    }
    */

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            maca.SetBool("playMaca", true);
            pomba.SetBool("playPomba", true);
            coracao.SetBool("playCoracao", true);
        }
    }
}
