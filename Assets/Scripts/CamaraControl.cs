using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    [SerializeField] private float sensibilidadeRato;
    
    private Transform pai;

    void Start()
    {
        pai = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Rotacao();
    }

    private void Rotacao()
    {
        float ratoX = Input.GetAxis("Mouse X") * sensibilidadeRato* Time.deltaTime;
        pai.Rotate(Vector3.up, ratoX);

    }
}
