using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puffle : MonoBehaviour
{
    NavMeshAgent puffle;
    
    [SerializeField]
    Transform pertoAlma;

    
    // Start is called before the first frame update
    void Start()
    {
        puffle = GetComponent<NavMeshAgent>();
        pertoAlma = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        puffle.destination = pertoAlma.position;
    }
}
