using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    NavMeshAgent inimigo;
    Transform alma;
    
    // Start is called before the first frame update
    void Start()
    {
       inimigo = GetComponent<NavMeshAgent>();
       alma = GameObject.FindGameObjectWithTag("Jogador").transform;
    }

    // Update is called once per frame
    void Update()
    {
        inimigo.destination = alma.position;
    }
}
