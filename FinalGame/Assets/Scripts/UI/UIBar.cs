using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{

	public Image bar;
    public GameObject winnerText;
	public GameObject key;
	public Text coinNum;
	public int totalCoinValue;
	public int coinValue = 10;
	public GameObject gameOverUI;
	public float powerLevel = 0.1f;
	public float ammountToAdd = 0.01f;

	public enum PowerUpType
	{
		PowerUp,
		PowerDown,
		CollectCoin,
	}

	public PowerUpType powerUp;

//Starts coroutine for each PowerUpType
	void OnTriggerEnter ()
    {

		switch (powerUp)
		{
			case PowerUpType.PowerUp:
				StartCoroutine(PowerUpBar());
			break;

			case PowerUpType.PowerDown:
				StartCoroutine(PowerDownBar());
			break;

			case PowerUpType.CollectCoin:
				StartCoroutine(CollectCoin());
			break;
		}
	}

//When collided with key, game will end (needs fixing)
    void OnCollisionEnter(Collision key)
    {
        if (bar.fillAmount > 0)
        {
            winnerText.SetActive(true);
            CharacterControl.gameOver = true;
        }
    }

//Allows player to collect coins, add coins to coinNum
    IEnumerator CollectCoin () 
	{
		totalCoinValue = int.Parse(coinNum.text);
		int tempAmount = totalCoinValue + coinValue;
		while (totalCoinValue <= tempAmount)
		{
			coinNum.text = (totalCoinValue++).ToString();
			yield return new WaitForFixedUpdate();
		}
	}

//Allows player to collect powerups to add to health bar
	IEnumerator PowerUpBar ()
    {
		float tempAmount = bar.fillAmount + powerLevel;
		if (tempAmount > 1)
		{
			tempAmount = 1;
		}

		while (bar.fillAmount < tempAmount)
		{
			bar.fillAmount += ammountToAdd;
			yield return new WaitForSeconds(ammountToAdd);
		}
	}

//Allows health to be lowered when player collects powerdowns, if health reaches 0 then the game will end (needs fixing)
	IEnumerator PowerDownBar ()
    {
		float tempAmount = bar.fillAmount - powerLevel;
		if (tempAmount <= 0)
		{
			tempAmount = 0;
		}
		
		while (bar.fillAmount > tempAmount)
		{
			bar.fillAmount -= ammountToAdd;
			yield return new WaitForSeconds(ammountToAdd);

			if (bar.fillAmount == 0)
            {
				yield return null;
			}

			if (bar.fillAmount == 0)
            {
				gameOverUI.SetActive(true);
				CharacterControl.gameOver = true;
			}
		}
	}
}
