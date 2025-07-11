using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms;
//using GooglePlayGames.BasicApi;
//using GooglePlayGames;
using System;

public class UIMainmenu : MonoBehaviour 
{

	Transform canv_trans;

	void Start () 
	{
		canv_trans = gameObject.transform;
	
		LeaderBoardAuth ();
	} 
	void LeaderBoardAuth()
	{
		//PlayGamesPlatform.DebugLogEnabled = true;
		//PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) =>{
			if (success){
				Debug.Log ("Login Sucess");
			} else {
				Debug.Log ("Login failed");
			}
		});
	}

	public void OnClickShowAchivement()
	{
		if(Social.localUser.authenticated) 
		{
			Social.ShowAchievementsUI();
		}
	}

	public void OnClickShowLeaderBoard()
	{
		OnClickAddScoreToLeaderBorad();
		try{
			if (Social.localUser.authenticated) {
				//PlayGamesPlatform.Instance.ShowLeaderboardUI(sss.leaderboard_long_survivor);
				Social.ShowLeaderboardUI ();
			} else {
				Debug.Log("Hiten Show Leaderboar.. Not Authetication");
			}
		}catch(Exception eE)
		{
			Debug.Log("Errrro  "+eE);
		}		
	}
	public void OnClickAddScoreToLeaderBorad()
	{

		if (Social.localUser.authenticated) 
		{
			//SCORE DISPLAY SCORE/10;
			Social.ReportScore(50, sss.leaderboard_long_survivor, (bool success) => {
				if (success) 
				{
					Debug.Log ("Update Score Success longsurviver DDD" );
				}
				else 
				{
					Debug.Log ("Update Score Fail");
				}
			});
		}
	}




	public void OnClickPlay()
	{
	//	AsyncOperation async = Application.LoadLevelAsync("GamePlay");
		//GameObject.Find ("CanvLoader").transform.GetChild (0).gameObject.SetActive (true);
	//	if(async.isDone)
		//Application.LoadLevel ("Level_Scene");

		GameObject.Find ("CanvLevels").transform.GetChild (0).gameObject.SetActive (true);
		gameObject.SetActive (false);
	}	
	public void OnClickLevels()
	{
		GameObject.Find ("CanvLevels").transform.GetChild (0).gameObject.SetActive (true);
		gameObject.SetActive (false);
	}
	public void OnClickInfo()
	{
        GameObject.Find("CanvInstruction").transform.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);
	}
	public void OnClickAchivements()
	{
		GameObject.Find("CanvMissionAchivements").transform.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
	public void OnClickExit()
	{
		Application.Quit ();
	}
	public void OnClickRateUs()
	{											
		print ("package::" + Application.identifier);
		Application.OpenURL ("market://details?id=" + Application.identifier);

	}
	public void OnClickSettingButton()
	{
		GameObject.Find("CanvSetting").transform.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}



    
}
