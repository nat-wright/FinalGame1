using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

	public GameObject winnerText;
	public Image bar;
	
//When collided with key, game will end (needs fixing)
	public void OnTriggerEnter () 
	{
		  if (bar.fillAmount > 0)
        {
            winnerText.SetActive(true);
            CharacterControl.gameOver = true;
        }
	}
}	
