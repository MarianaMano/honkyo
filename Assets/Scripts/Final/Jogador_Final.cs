using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Final : MonoBehaviour
{

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
            gameObject.transform.position = c1;
        }

        if (other.tag == "Portal2")
        {
            Debug.Log("portal 2");
            gameObject.transform.position = c2;
        }

        if (other.tag == "Portal3")
        {
            Debug.Log("portal 3");
            gameObject.transform.position = c3;
        }
    }

}
