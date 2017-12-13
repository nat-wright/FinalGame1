using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour {

	public Transform player;
	public NavMeshAgent agent;
	
//Makes NavMeshAgent walk on NavMesh
	void Update () 
	{
		agent.destination = player.position;
	}
}
