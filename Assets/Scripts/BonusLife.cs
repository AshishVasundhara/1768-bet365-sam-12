using UnityEngine;
using System.Collections;

public class BonusLife : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") 
		{		
			gameObject.transform.Find("Shockwave").gameObject.SetActive(true);
			print("Current Level : " + GameLoader.CurretnLevel +"Total Life : " +GameLoader.LevelLifeLimite[GameLoader.CurretnLevel-1]);	
			lifeUpdate.life+=1;
			gameObject.GetComponent<AudioSource>().Play();
			Destroy(this.gameObject,0.2F);			
		}	
	}
}
