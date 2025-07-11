using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

		public GameObject[] hazards;
		public int hazardCount;			

		public float haz_startWait;
		public float haz_spawnWait;
		public float haz_waveWait;

		public GameObject[] LoPs;
		public int LopCount;
		public float PnLstartWait;
		public float PnLspawnWait;
		public float PnLwaveWait;

		Vector3 spawnValue;			
		int Score2 = 0 ;
		
		
		void Start()
		{
			Time.timeScale = 1;
			//spawnValue = new Vector3 (-3.3f,0,9);
		spawnValue = new Vector3 (-5f,0,9);
			StartCoroutine (spwanHaz());
			StartCoroutine (spwanLoP());
		}	

		

		public IEnumerator spwanHaz()	
		{
			yield return new WaitForSeconds (haz_startWait);	
			while (true)
			{
				for (int i=0; i<hazardCount; i++) 
				{
					GameObject hazard = hazards[Random.Range(0,hazards.Length)];
					Vector3 spwanposition2 = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
					Quaternion spwanRotation = Quaternion.identity;
					Instantiate (hazard, spwanposition2, spwanRotation);
					yield return new WaitForSeconds (haz_spawnWait);
				}
				yield return new WaitForSeconds (haz_waveWait);
			}	
		}
		
	public IEnumerator spwanLoP()	
	{
		yield return new WaitForSeconds (PnLstartWait);	
		while (true)
		{
			for (int i=0; i<LopCount; i++) 
			{
				GameObject LoP = LoPs[Random.Range(0,LoPs.Length)];
				Vector3 spwanposition2 = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spwanRotation = Quaternion.identity;
				int temp = GameLoader.LevelLifeLimite[GameLoader.CurretnLevel-1]-2;
				print("SSSSSSSSSS : " + lifeUpdate.life +" < " + temp);
				if(lifeUpdate.life < GameLoader.LevelLifeLimite[GameLoader.CurretnLevel-1]-2)
				{
					Instantiate (LoP, spwanposition2, spwanRotation);
				}
				yield return new WaitForSeconds (PnLspawnWait);
			}
			yield return new WaitForSeconds (PnLwaveWait);
		}	
	}
		void Update()
		{
			//print ("Time : " + Time.deltaTime);
		//print (scoreUpdate.scoreValue + ":::" + GameLoader.LevelFinishNeededScore [GameLoader.CurretnLevel - 1]);
			if (lifeUpdate.life > 0) 
			{
				if (scoreUpdate.scoreValue >= GameLoader.LevelFinishNeededScore[GameLoader.CurretnLevel - 1]) 
				{
					GameObject.Find("Player").GetComponent<BoxCollider>().enabled=false;
					GameOver.isLevelFinish = true;					
				}
			} 
			else 
			{
				GameObject.Find("Player").GetComponent<BoxCollider>().enabled=false;
				GameOver.isGameOver = true;
			}
		}
}	
