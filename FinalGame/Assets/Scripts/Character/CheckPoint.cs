using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

//Restarts game from checkpoint
	void OnTriggerEnter()
	{
		ReplayGame.startPosition = transform.position;
	}

}
