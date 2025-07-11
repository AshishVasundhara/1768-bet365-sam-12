using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class DestroyByContact : MonoBehaviour
{
	public static DestroyByContact instance;
	public GameObject explosion;
	public GameObject playerExplosion;
//	private GameController3 gameController;

	static int countBullethurt;


	void Start ()
	{
		/*
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController3>();
		}
		*/
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "haz1" || other.tag == "haz2" || other.tag == "Enemy" || other.tag == "EnemyBullet")
		{
			return;
		}


		if (explosion != null)
		{
			if(gameObject.tag != "haz1" || gameObject.tag != "haz2")
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
		}

		if (other.tag == "Player")
		{
			if(playerExplosion !=null)
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			if(explosion!=null)
				Instantiate(explosion, other.transform.position, other.transform.rotation);
		}
		if (gameObject.tag == "haz2" || gameObject.tag == "haz1" && other.name != "Player") 
		{
			countBullethurt++;
			gameObject.GetComponent<AudioSource>().Play();
			if (countBullethurt == 5)
			{
				//GameObject.Find("RadianAttack").transform.GetChild(0).gameObject.SetActive(true);
				//GameObject.Find("RadianAttack").transform.GetChild(0).position = gameObject.transform.position;
				//	print(GameObject.Find("RadianAttack").transform.GetChild(0).position);
				Instantiate(playerExplosion,other.transform.position, other.transform.rotation);
				Destroy (gameObject);
				scoreUpdate.scoreValue += 10;
				countBullethurt = 1;
			}
		}
		else if (gameObject.tag == "Enemy" && other.name != "Player") 
		{
			scoreUpdate.scoreValue += 20;
			Destroy (gameObject);
		}	
		//gameObject.GetComponent<AudioSource>().Play();
	}
}