using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGameOver : MonoBehaviour {
	Transform canvTrans;
	private string strGameResult;
    private string strReason4GameOver;
	private string strGreeting;
	public static string toShare = "";
	void Awake()
    {
		/*
        incrementShowAds ++;
        int randno = Random.Range(min1,max1);
      //  print(incrementShowAds + " == " + randno + " || " + incrementShowAds + " == " + max1);
        if(incrementShowAds == randno || incrementShowAds == max1)
        {
         //   #if UNITY_ANDROID
            //    GameObject.Find("Admob_DnD").GetComponent<Admob_scripts>().ShowInterstitial();
        //    #endif
                incrementShowAds = 0;
            print("Shown.. " + incrementShowAds);
        }
		*/
    }

     
    void OnEnable()
    {
		//AdMgmnt ();
		//GameObject.Find("Main Camera").transform.GetChild(1).gameObject.SetActive(false); // eNGINEsOUND oFF
		//strReason4GameOver = GameOver.strReason4GameOver;

		GameObject.Find ("Main Camera").GetComponent<AudioSource>().Stop();
		canvTrans = gameObject.transform;
		canvTrans.Find ("btnreplay").gameObject.SetActive(false);
		canvTrans.Find ("btnnextLevel").gameObject.SetActive(false);
      
	//	print("Level finish " +GameOver.isLevelFinish + "from UI start, GameOver" + GameOver.isGameOver);
		if (GameOver.isGameOver)
		{
                       // GameOver.isGameOver = false;
				strGameResult = "Mission Failed";
				strGreeting = "TRY AGAIN";
				canvTrans.Find ("").gameObject.SetActive (true);
				canvTrans.Find ("btnreplay").gameObject.SetActive (true);
				AssignLeaderboard_LongSurviverValues();
        } 
        else if(GameOver.isLevelFinish) 
        {
			    int lastlevel = PPs.TOTAL_LEVEL ;
				strGameResult = "Mission Completed";
				setGetScoreHighScore(GameLoader.CurretnLevel);		//Score and HightScore Values are set here.			
				
				//canvTrans.FindChild ("btnshareHighScore").gameObject.SetActive(true);

				if (GameLoader.CurretnLevel == PPs.TOTAL_LEVEL) // cheking that is loaded level is last 
			    {
					//strGreeting = "Congrats !! \n Wait for new levels";
					strGreeting = "";
					canvTrans.Find ("btnreplay").gameObject.SetActive (true);
			    }
			    else // not last level 
			    {
				    SetNextLevel();
					strGreeting = "";
					canvTrans.Find ("btnnextLevel").gameObject.SetActive (true);
			    }
			UnloacAchivementLevels();
			AssigneLeaderBoard_FastFinishValues();
		} 
        else 
        {
			strGameResult = "";
			strGreeting = "";
		}
		//If player has been finish last level....
		canvTrans.Find ("txtgreeting").GetComponent<Text> ().text = strGreeting;
		canvTrans.Find ("txtresult").GetComponent<Text> ().text = strGameResult;
		Time.timeScale = 0.0f;
	}
	void AssigneLeaderBoard_FastFinishValues() // in Level finish condition
	{
		long scoreToSubmit = (long)TimerText.timerc;
		Debug.Log ("From  AssigneLeaderBoard_FastFinishValues() : " + scoreToSubmit);
		Social.ReportScore(scoreToSubmit,sss.leaderboard_fast_finisher,(bool success) => {}); //Fast Finisher
	}
	void AssignLeaderboard_LongSurviverValues() // in Long surviver condition
	{
		long scoreToSubmit = (long)TimerText.timerc;
		Debug.Log ("From  AssignLeaderboard_LongSurviverValues() : " + scoreToSubmit);
		Social.ReportScore(scoreToSubmit,sss.leaderboard_long_survivor,(bool success) => {}); //Fast Finisher
	}
	void AssignLeaderboard_theCaptain10thlevel() // in highscore of 10th level
	{
		long scoreToSubmit = (long)TimerText.timerc;
		Debug.Log ("From  AssignLeaderboard_theCaptain10thlevel() : " + scoreToSubmit);
		Social.ReportScore(scoreToSubmit,sss.leaderboard_the_captainship,(bool success) => {}); //Fast Finisher
	}
	void UnloacAchivementLevels() 
	{		
		Social.localUser.Authenticate((bool auth_success)=> {
			if(auth_success) 
			{
				int maxOpenedLevel= PlayerPrefs.GetInt(PPs.PPMAX_LEVEL);
				if(maxOpenedLevel==10)
					Social.ReportProgress (sss.achievement_the_veteran, 100.0f, (bool success) => {}); // for level 9th clear
				else if(maxOpenedLevel==7)
					Social.ReportProgress (sss.achievement_sky_warrior, 100.0f, (bool success) => {}); // for level 6th clear
				else if(maxOpenedLevel==3)
					Social.ReportProgress (sss.achievement_the_knight, 100.0f, (bool success) => {}); //for level 2th clear
			}
		});
	}
	void setGetScoreHighScore(int currLev)
	{
		float timerStored = PlayerPrefs.GetFloat(PPs.PPSHSCORECMN + currLev);
		float timenow = TimerText.timerc;
		//print ("Inside  : " + timerStored + " Now : " + timenow);

		canvTrans.Find("txtScore").gameObject.SetActive(true);
		canvTrans.Find("txtScore").gameObject.GetComponent<Text>().text = "" + ConvertTimeToString(timenow);

		if (timenow < timerStored) 
		{
			canvTrans.Find("txthurrahh").gameObject.SetActive (true);
			canvTrans.Find("txthurrahh").gameObject.GetComponent<Text>().text ="Yeh, Finished!!...\t";
			PlayerPrefs.SetFloat(PPs.PPSHSCORECMN + currLev,timenow);
			PlayerPrefs.Save();
		}
		canvTrans.Find("img_currscore").gameObject.SetActive(true);
		canvTrans.Find("img_bestscore").gameObject.SetActive(true);

		canvTrans.Find("txtHScore").gameObject.SetActive(true);
		canvTrans.Find("txtHScore").gameObject.GetComponent<Text>().text = "" + ConvertTimeToString(PlayerPrefs.GetFloat(PPs.PPSHSCORECMN + currLev));
		toShare ="Achived a mission-"+currLev+ " within "+  ConvertTimeToString(PlayerPrefs.GetFloat(PPs.PPSHSCORECMN + currLev));

		if (currLev == 10) 
		{
			AssignLeaderboard_theCaptain10thlevel();
		}
	}
	string ConvertTimeToString(float timerc)
	{
		int minutes = Mathf.FloorToInt(timerc / 60F);
		int seconds = Mathf.FloorToInt(timerc - minutes * 60);
		string strTime = string.Format("{0:00}:{1:00}", minutes, seconds);
		return strTime;
	}
	
	float ConverStringToTime(string strtime)
	{
		float min = float.Parse(strtime.Substring (0, 2));
		float sec = float.Parse(strtime.Substring (3, 2));
		return (min*60) + sec;
	}

	void SetNextLevel()
	{
		print(GameLoader.CurretnLevel +" == "+ GameLoader.MaxLevel);
		if(GameLoader.CurretnLevel == GameLoader.MaxLevel)
		{
			print(GameLoader.CurretnLevel +" < "+ PPs.TOTAL_LEVEL);
			if(GameLoader.CurretnLevel < PPs.TOTAL_LEVEL)
			{
				GameLoader.MaxLevel+=1;
				PlayerPrefs.SetInt(PPs.PPMAX_LEVEL,GameLoader.MaxLevel);
				PlayerPrefs.Save();
			}
		}
        if (GameLoader.CurretnLevel < PPs.TOTAL_LEVEL)
        {
            GameLoader.CurretnLevel += 1;
            PlayerPrefs.SetInt(PPs.PPCURR_LEVEL, GameLoader.CurretnLevel);
        }
		PlayerPrefs.Save();
	}
	/*
    public void ResetAll()
    {
        strGameResult = "";
        strGreeting = "";
        strReason4GameOver = "";

		GameObject.Find("CanvGP").transform.GetChild(0).gameObject.SetActive(true);  

		print ("UIGameover  gameover 11");
		GameObject.Find("Scripts").GetComponent<GampPlayLoader>().setAllNewStart();
		print ("UIGameover  gameover 22");
        this.gameObject.SetActive(false);
    }
    */
	public void OnClickReplayBtn()
	{
        Time.timeScale = 1;
		print ("ReplayClicked");
       // ResetAll(); 
		Application.LoadLevel ("GamePlay");
	}
	public void OnClickNextLvl()
	{
		Application.LoadLevel ("GamePlay");
	}
	public void OnClickMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}    



}
