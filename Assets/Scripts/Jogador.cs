using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    [SerializeField]
    float velocidade = 3f;
    private Rigidbody corpoRigido;

    // Start is called before the first frame update
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3( - moveHorizontal, 0.0f, - moveVertical);
        //transform.position = transform.position + (- movimento * velocidade * Time.deltaTime);
        corpoRigido.AddForce(movimento * velocidade);

    }
}
