using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    private NavMeshAgent MyAgent;
    public GameObject Target;
    void Start()
    {
        MyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MyAgent.SetDestination(Target.transform.position);
    }
}
