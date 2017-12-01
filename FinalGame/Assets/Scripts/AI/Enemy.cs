using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public Sprite[] enemySprite = new Sprite[3];
	public SpriteRenderer myEnemy;
	public Image bar;
	

	public void Start() {
		StartCoroutine (enemySwitch());
	}


		IEnumerator enemySwitch () 
	{
		
		while (bar.fillAmount > 0)
		{
			for (int i = 0;  i < enemySprite.Length; i++)
			{
				myEnemy.sprite = enemySprite[i];
				yield return new WaitForSeconds(0.1f);
			}
			
		}
	}
	
}
