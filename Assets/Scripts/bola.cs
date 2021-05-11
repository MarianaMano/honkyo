using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float velocidade = 3f;

    private Rigidbody corporigido;

    // Start is called before the first frame update
    void Start()
    {
        corporigido = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        corporigido.AddForce(movimento * velocidade);
    }
}
