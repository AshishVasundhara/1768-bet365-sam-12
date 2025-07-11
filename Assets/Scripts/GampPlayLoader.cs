using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class GampPlayLoader : MonoBehaviour 
{

    public static bool isSteeringwheel;
    public static float timer;
	public static float MaxDimondGenArea;
	public static int totalPickupInLevel;
	private Vector3 Ter_Size;

	public static int lno;
	Transform playerTrans;
	private Texture textur;

	Transform GoldsMain;

	//Advertise purpose
	static int incrementShowAds=0;
	static int min1 = 1;
	static int max1 = 3;
	static int isAdsTurn=1;

	playerConroller playerContr;
	
	void Start() 
	{
		//GameLoader.CurretnLevel = 1;
		timer = GameLoader.LevelLifeLimite [GameLoader.CurretnLevel - 1]; 
		playerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
		//	timer = GameLoader.LevelFinishTimeLimite[0]; 

		print(GameLoader.CurretnLevel +" == "+ GameLoader.MaxLevel);
		playerContr = GameObject.Find("Player").GetComponent<playerConroller> ();
		setAllNewStart ();	
	}

	void AdMgmnt()
	{
		incrementShowAds ++;
		int randno = Random.Range(min1,max1);
		//  print(incrementShowAds + " == " + randno + " || " + incrementShowAds + " == " + max1);
		if(incrementShowAds == randno || incrementShowAds == max1)
		{
			if(isAdsTurn==1)
			{
				Debug.Log("SHOW ADMOB ADS");
				isAdsTurn=2;
				#if UNITY_ANDROID
				GameObject.Find("Admob_DnD").GetComponent<Admob_scripts>().ShowInterstitial(); 	//Admob Ads
				#endif

			}
			else if(isAdsTurn==2)
			{
				Debug.Log("SHOW Vid ADS");
				isAdsTurn=1;
				ShowUnityVidAd();
			}
			incrementShowAds = 0;
			print("Shown.. " + incrementShowAds);
		}
	}
	public void ShowUnityVidAd()
	{
		//if (Advertisement.IsReady())
		//{
		//	Advertisement.Show();
		//}
	}
    public void setAllNewStart()
    {

		if (Soomla.Store.Example.RemoveAds.isRemoveAdsOwened == false) 
		{
			Debug.Log("Noads is not activated");
			//AdMgmnt ();
		} 
		else 
		{
			Debug.Log("Noads ACTIVATED");
		}
		GameOver.isGameOver = false;
        GameOver.isLevelFinish = false;
		GameObject.Find("Player").GetComponent<BoxCollider>().enabled=true;
 		
		Time.timeScale = 1;
        LoadCurrentLevel(GameLoader.CurretnLevel);
    }
	void LoadCurrentLevel(int currLevel)
	{
//		print ("Current level  : " + currLevel);
		switch (currLevel) 
		{
			case 1 : 
					AssigneLevel1();
					break;
			case 2 : 
					AssigneLevel2();
					break;
			case 3 : 
					AssigneLevel3();
					break;
			case 4 : 
					AssigneLevel4();
					break;
			case 5 : 
					AssigneLevel5();
					break;
			case 6 :
					AssigneLevel6();
					break;
			case 7 :
					AssigneLevel7();
					break;
			case 8 :
					AssigneLevel8();
					break;
			case 9 :
					AssigneLevel9();
					break;
			case 10 :
					AssigneLevel10();
					break;
		default :
					print("Default Executed in switch - case....");
					break;
		}
		GameObject.Find ("Level"+currLevel).transform.Find ("L" + currLevel).gameObject.SetActive(true);
		lifeUpdate.life = GameLoader.LevelLifeLimite [GameLoader.CurretnLevel - 1]; //Given Life
		scoreUpdate.scoreValue = 0;//Start Score

	} 

	Texture setThisTexure(string pathq)
	{
		return Resources.Load (pathq, typeof(Texture)) as Texture;
	}
	void AssigneLevel1()
	{
		// player  				

			// assigning Player's texture and material 
			//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L1Player");	
			playerTrans.Find ("ship3").gameObject.SetActive(true);
			
			
			playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
			
			//assigning Player's jet flare smoke.
			playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem>().GetComponent<Renderer>().material.mainTexture = setThisTexure ("myParticle/11"); 
			playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem>().GetComponent<Renderer>().material.mainTexture = setThisTexure ("myParticle/14"); 

			// assigning Player's bullet and speed
			playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load ("Prafbs/Bullet10", typeof(GameObject)) as GameObject; 
			GameObject go = Resources.Load ("Prafbs/Bullet10", typeof(GameObject)) as GameObject; 
			go.GetComponent<Mover> ().speed = 15;
			playerContr.FireRate = 0.4f;
			

			//Enemy
			//Used enemy are.. h1-e1-er5
			GameObject enemy = Resources.Load ("Prafbs/Enemy1", typeof(GameObject)) as GameObject; 
			enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet_AnimatedEnemy", typeof(GameObject)) as GameObject; 
			enemy.GetComponent<EnemyWap>().fireRate = 1F;
		
			// stratagies ==>assigned in GameLoadercript
			// life = 5
			// missionFinish score = 700
				 
			//Extra power and life power in this level

			
	}
	void AssigneLevel2()
	{
		//Player
			// assigning Player's texture and material 
			//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L2Player");

			playerTrans.Find ("ship3").gameObject.SetActive(true);
			playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.7F);

			//assigning Player's jet flare smoke.
			playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/4"); 
			playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/11"); 

			// assigning Player's bullet and speed
			playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet4", typeof(GameObject)) as GameObject; 
			GameObject go = Resources.Load ("Prafbs/Bullet4", typeof(GameObject)) as GameObject; 
			go.GetComponent<Mover>().speed = 13; 
			playerContr.FireRate = 0.6f;


		GameObject enemy = Resources.Load ("Prafbs/Enemy1", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet_AnimatedEnemy", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 0.6F;

		//Enemy
		//Used enemy are.. e1-e2-e3-e4
			
		//stratagies ==>assigned in GameLoadercript
		// life = 7
		// missionFinish score = 1000
		
		//Extra power and life power in this level
	}

	void AssigneLevel3()
	{
		//Player
			// assigning Player's texture and material 
			//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L3Player");
			playerTrans.Find ("ship2").gameObject.SetActive(true);
			playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
		
			//assigning Player's jet flare smoke.
			playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/10"); 
			playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/11"); 
		
			//Assigning Player's bullet and speed
			playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet2", typeof(GameObject)) as GameObject; 
			GameObject go = Resources.Load ("Prafbs/Bullet2", typeof(GameObject)) as GameObject; 
			go.GetComponent<Mover>().speed = 20;
			playerContr.FireRate = 0.4f;
		//Enemy
		//Used enemy are.. er5-e2-e4-e1
			GameObject enemy = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
			enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet1", typeof(GameObject)) as GameObject; 
			enemy.GetComponent<EnemyWap> ().fireRate = 1F;


		GameObject enemy1 = Resources.Load ("Prafbs/Enemy1", typeof(GameObject)) as GameObject; 
		enemy1.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet_AnimatedEnemy", typeof(GameObject)) as GameObject; 
		enemy1.GetComponent<EnemyWap> ().fireRate = 1F;
		//stratagies ==>assigned in GameLoadercript
		// life = 6
		// missionFinish score = 1000
		
		//Extra power and life power in this level
	}

	void AssigneLevel4()
	{
		//Player
			// assigning Player's texture and material 
			//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L4Player");
			
			playerTrans.Find ("ship2").gameObject.SetActive(true);
			playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
			

			//assigning Player's jet flare smoke.
			playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/4"); 
			playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/7"); 
			
			//Assigning Player's bullet and speed
			playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet6", typeof(GameObject)) as GameObject; 
			GameObject go = Resources.Load ("Prafbs/Bullet6", typeof(GameObject)) as GameObject; 
			go.GetComponent<Mover>().speed = 15;
		playerContr.FireRate = 0.4f;

		//Enemy
			//Used enemy are.. e1-er6-er5
			GameObject enemy = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
			enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet5", typeof(GameObject)) as GameObject; 
			enemy.GetComponent<EnemyWap> ().fireRate = 1F;
			
			GameObject enemy2 = Resources.Load ("Prafbs/Enemy6", typeof(GameObject)) as GameObject; 
			enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet4", typeof(GameObject)) as GameObject; 
			enemy2.GetComponent<EnemyWap> ().fireRate = 1F;

		//stratagies ==>assigned in GameLoadercript
			// life = 8
			// missionFinish score = 1200
		
			//Extra power and life power in this level
	}

	void AssigneLevel5()
	{
		//Player
		// assigning Player's texture and material 
		//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L5Player");
		playerTrans.Find ("ship2").gameObject.SetActive(true);
		playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
		
		
		//assigning Player's jet flare smoke.
		playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/4"); 
		playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/7"); 
		
		//Assigning Player's bullet and speed
		playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet4", typeof(GameObject)) as GameObject; 
		GameObject go = Resources.Load ("Prafbs/Bullet4", typeof(GameObject)) as GameObject; 
		go.GetComponent<Mover>().speed = 13;
		playerContr.FireRate = 0.4f;
		//Enemy
		//Used enemy are.. h1,h2e2,er6
		GameObject enemy = Resources.Load ("Prafbs/Enemy2", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet1", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 1F;
		
		GameObject enemy2 = Resources.Load ("Prafbs/Enemy6", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet2", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap> ().fireRate = 1F;
		
		//stratagies ==>assigned in GameLoadercript
		// life = 8
		// missionFinish score = 1300
		
		//Extra power and life power in this level
	}

	void AssigneLevel6()
	{
		//Player
		// assigning Player's texture and material 
		//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L6Player");
		playerTrans.Find ("ship1").gameObject.SetActive(true);

		playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
				
		//assigning Player's jet flare smoke.
		playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/5"); 
		playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/14"); 
		
		//Assigning Player's bullet and speed
		playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet2", typeof(GameObject)) as GameObject; 
		GameObject go = Resources.Load ("Prafbs/Bullet2", typeof(GameObject)) as GameObject; 
		go.GetComponent<Mover>().speed = 22;
		playerContr.FireRate = 0.5f;
		//Enemy
		//Used enemy are.. h1,e1,e2,e4,er5
		GameObject enemy = Resources.Load ("Prafbs/Enemy2", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet1", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 1F;
		
		GameObject enemy2 = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet3", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap> ().fireRate = 1F;
		
		//stratagies ==>assigned in GameLoadercript
		// life = 7
		// missionFinish score = 1500
		
		//Extra power and life power in this level
	}

	void AssigneLevel7()
	{
		//Player
		// assigning Player's texture and material 
		playerTrans.Find ("ship3").gameObject.SetActive(true);
		//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L7Player");
		playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
		
		//assigning Player's jet flare smoke.
		playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/14"); 
		playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/11"); 
		
		//Assigning Player's bullet and speed
		playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet7", typeof(GameObject)) as GameObject; 
		GameObject go = Resources.Load ("Prafbs/Bullet7", typeof(GameObject)) as GameObject; 
		go.GetComponent<Mover>().speed = 15;
		playerContr.FireRate = 0.4f;
		//Enemy
		//Used enemy are.. er5,er6,e2,e3,h2
		GameObject enemy = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet5", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 1F;
		
		GameObject enemy2 = Resources.Load ("Prafbs/Enemy6", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet4", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap> ().fireRate = 1F;
		
		//stratagies ==>assigned in GameLoadercript
		// life = 9
		// missionFinish score = 1800
		
		//Extra power and life power in this level
	}

	void AssigneLevel8()
	{
		
		//Player
		// assigning Player's texture and material 
		//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L8Player");
		playerTrans.Find ("ship2").gameObject.SetActive(true);
		playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);

	
		//assigning Player's jet flare smoke.
		playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/14"); 
		playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/5"); 
		

		//Assigning Player's bullet and speed
		playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet8", typeof(GameObject)) as GameObject; 
		GameObject go = Resources.Load ("Prafbs/Bullet8", typeof(GameObject)) as GameObject; 
		go.GetComponent<Mover>().speed = 20;
		playerContr.FireRate = 0.4f;

		//Enemy
		//Used enemy are.. er5,er6,h1,h2
		GameObject enemy = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet1", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 1F;
		
		GameObject enemy2 = Resources.Load ("Prafbs/Enemy6", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet5", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap> ().fireRate = 1F;
		
		//stratagies ==>assigned in GameLoadercript
		// life = 10
		// missionFinish score = 2000

	}
	void AssigneLevel9()
	{
		
		//Player
		// assigning Player's texture and material 
		//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L9Player");
		playerTrans.Find ("ship2").gameObject.SetActive(true);
		playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
		

		//assigning Player's jet flare smoke.
		playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/14"); 
		playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/11"); 
		
		
		//Assigning Player's bullet and speed
		playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet6", typeof(GameObject)) as GameObject; 
		GameObject go = Resources.Load ("Prafbs/Bullet6", typeof(GameObject)) as GameObject; 
		go.GetComponent<Mover>().speed = 22;
		playerContr.FireRate = 0.4f;

		//Enemy
		//Used enemy are.. h2,e2,er5,er6,h1
		GameObject enemy = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet1", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 1F;
		
		GameObject enemy2 = Resources.Load ("Prafbs/Enemy6", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet5", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap> ().fireRate = 1F;
		
		//stratagies ==>assigned in GameLoadercript
		// life = 10
		// missionFinish score = 2500
		
	}
	void AssigneLevel10()
	{
		//Player
		// assigning Player's texture and material 
		//playerTrans.Find("Ship").GetComponent<Renderer>().material.mainTexture = setThisTexure("Ships/L9Player");
		playerTrans.Find ("ship1").gameObject.SetActive(true);
		playerTrans.Find ("ShotSpwanPoint").localPosition = new Vector3 (0, 0, 0.8F);
		
		
		//assigning Player's jet flare smoke.
		playerTrans.Find ("engines_player").Find ("part_jet_flare").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/14"); 
		playerTrans.Find ("engines_player").Find ("part_jet_core").GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material.mainTexture = setThisTexure ("myParticle/11"); 
		
		
		//Assigning Player's bullet and speed
		playerTrans.gameObject.GetComponent<playerConroller>().shot = Resources.Load("Prafbs/Bullet6", typeof(GameObject)) as GameObject; 
		GameObject go = Resources.Load ("Prafbs/Bullet6", typeof(GameObject)) as GameObject; 
		go.GetComponent<Mover>().speed = 22;
		playerContr.FireRate = 0.4f;

		//Enemy
		//Used enemy are.. h2,e2,er5,er6,h1
		GameObject enemy = Resources.Load ("Prafbs/Enemy5", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet1", typeof(GameObject)) as GameObject; 
		enemy.GetComponent<EnemyWap> ().fireRate = 0.9F;
		
		GameObject enemy2 = Resources.Load ("Prafbs/Enemy6", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap>().shot = Resources.Load("Prafbs/EnemyBullet5", typeof(GameObject)) as GameObject; 
		enemy2.GetComponent<EnemyWap> ().fireRate = 0.7F;
		
		//stratagies ==>assigned in GameLoadercript
		// life = 10
		// missionFinish score = 2500

	}
}










