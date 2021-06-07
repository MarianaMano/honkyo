using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador_Final : MonoBehaviour
{
     [SerializeField]
     public Text textoFinalObjetos;

    [SerializeField]
    GameObject coordenada1;

    [SerializeField]
    GameObject coordenada2;

    [SerializeField]
    GameObject coordenada3;

    Vector3 c1;
    Vector3 c2;
    Vector3 c3;

    // Start is called before the first frame update
    void Start()
    {
        textoFinalObjetos.enabled = false;

        c1 = coordenada1.transform.position;
        c2 = coordenada2.transform.position;
        c3 = coordenada3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //MUDAR DE PORTAL

        if (other.tag == "Portal1")
        {
            Debug.Log("portal 1");
            StartCoroutine(MudaPortal(c1));
        }

        if (other.tag == "Portal2")
        {
            Debug.Log("portal 2");
            StartCoroutine(MudaPortal(c2));
        }

        if (other.tag == "Portal3")
        {
            Debug.Log("portal 3");
            StartCoroutine(MudaPortal(c3));
            textoFinalObjetos.enabled = true;

        }
    }

    private IEnumerator MudaPortal(Vector3 jogadorPosicaoOriginal)
    {
        Debug.Log("posição:" + jogadorPosicaoOriginal);

        GetComponent<MoverJogador>().enabled = false;

        transform.position = jogadorPosicaoOriginal;

        yield return new WaitForSeconds(0.1f);

        GetComponent<MoverJogador>().enabled = true;
    }

}
