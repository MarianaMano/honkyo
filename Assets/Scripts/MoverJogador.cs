using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] // impede o utilizador de remover o audiosource do jogador


public class MoverJogador : MonoBehaviour
{
    [SerializeField]
    private AudioClip somSalto;
    [SerializeField]

    private AudioClip somAndar;

    [SerializeField]
    private AudioClip SomCorrer;

    private AudioSource som;


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
        som = GetComponent<AudioSource>();

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

                som.clip = somAndar; // atribuimos ao som o som de andar 
                if (!som.isPlaying) som.Play(); // se o som nao estiver a tocar então toca
                

            }
            else if (direcaoMovimento != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                // estamos a correr
                Correr();

                som.clip = SomCorrer;
                if (!som.isPlaying) som.Play();
                
           
            }
            else if (direcaoMovimento == Vector3.zero)
            {
                // estamos parados
                Parado();

                som.Stop(); // paramos o som quando paramos de andar
            }

            direcaoMovimento *= velocidadeMovimento;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Saltar(-2);
                som.clip = somSalto;
                if (!som.isPlaying) som.Play();

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

    //TRAMPOLIM SIMULADO

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trampolim")
        {
            Saltar(-4);
        }
    }
}
