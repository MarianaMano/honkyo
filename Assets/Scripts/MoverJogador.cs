using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJogador : MonoBehaviour
{

    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float andarVelocidade;
    [SerializeField] private float correrVelocidade;

    private Vector3 direcaoMovimento;
    private Vector3 velocidade;

    [SerializeField] private bool estasNoChao;
    [SerializeField] private float chaoDistancia;
    [SerializeField] private LayerMask chaoMascara;
    [SerializeField] private float gravidade;
    [SerializeField] private float saltoAltura;

    private CharacterController controlador;
    private Animator animacao;


    void Start()
    {
        controlador = GetComponent<CharacterController>();
        animacao = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Movimento();
    }

    private void Movimento()
    {
        // definimos uma área de verificação do chão

        // estasNoChao = Physics.CheckSphere(transform.position, chaoDistancia, chaoMascara);

        estasNoChao = controlador.isGrounded;
        if (estasNoChao && velocidade.y < 0)
        {
            velocidade.y = -2f; // se estivermos no chão deixamos de aplicar a gravidade
        }

        float moverZ = Input.GetAxis("Vertical");

        direcaoMovimento = new Vector3(0, 0, moverZ);
        direcaoMovimento = transform.TransformDirection(direcaoMovimento);  // passa o pivot de transformação a ser local


        if (estasNoChao)
        {
  
            // se a direção por diferente de 0 e não estivermos a carregar em Shift
            if (direcaoMovimento != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                // estamos a andar
                Andar();


            }
            else if (direcaoMovimento != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                // estamos a correr
                Correr();
            }
            else if (direcaoMovimento == Vector3.zero)
            {
                // estamos parados
                Parado();
            }

            direcaoMovimento *= velocidadeMovimento;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Saltar(-2);
            }

        } 
 
       
        // simulamos a gravidade
        controlador.Move(direcaoMovimento * Time.deltaTime);    // movemos na direção (horizontal e frente)
        velocidade.y += gravidade * Time.deltaTime;
        controlador.Move(velocidade * Time.deltaTime);    // aplicamos a gravidade
    }

    private void Parado()
    {
        animacao.SetFloat("Velocidade", 0f);
    }
    private void Andar()
    {
        velocidadeMovimento = andarVelocidade;
        animacao.SetFloat("Velocidade", 0.5f);
    }
    private void Correr()
    {
        velocidadeMovimento = correrVelocidade;
        animacao.SetFloat("Velocidade", 1f);
    }

    private void Saltar(float salto = -2)
    {

        animacao.SetTrigger("Saltar");
        velocidade.y = Mathf.Sqrt(saltoAltura * salto * gravidade);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trampolim")
        {
            Saltar(-4);
        }
    }
}
