using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFixo : MonoBehaviour
{

    [SerializeField] float temporizador = 240;
    private bool contaTempo = true;
    [SerializeField] Text mostrador;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ContadorTemporal();
    }

    //função para contar o tempo
    void ContadorTemporal()
    {
        MostraTempo(temporizador);

        if (contaTempo)
        {
            if (temporizador > 0)
            {
                temporizador -= Time.deltaTime;
            }
            else
            {
                temporizador = 0;
                contaTempo = false;
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    //função para mostrar o temporizador na interface gráfica
    void MostraTempo(float relogio)
    {
        float minutos = Mathf.FloorToInt(relogio / 60);
        float segundos = Mathf.FloorToInt(relogio % 60);

        mostrador.text = string.Format("{00:00}:{1:00}", minutos, segundos);
    }
}
