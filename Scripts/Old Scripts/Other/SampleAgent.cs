// EXAMPLE SCRIPTS @2020 TOLGA
// Simple AI Example
// Mechanics : None
// Control : None

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAgent : MonoBehaviour {

    [HideInInspector] public GameObject target;
    [HideInInspector] public bool workAI = false;

    public GameObject Fills;
    NavMeshAgent agent;


    // ------
    private void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	private void Update ()
    {
        if (workAI)
        {
            agent.SetDestination(target.transform.position);
            Instantiate(Fills, new Vector3(transform.position.x, 0.293f, transform.position.z + 0.5f), Quaternion.Euler(90f, 0f, 0f));
        }

    }

}
