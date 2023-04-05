using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public GameObject dest;
    void Start()
    {
        gameObject.GetComponent<NavMeshAgent>().destination = dest.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<NavMeshAgent>().destination = dest.transform.position;
    }
}
