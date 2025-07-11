	using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameOver : MonoBehaviour {
	
	public static bool isGameOver;
	public static bool isLevelFinish;
  //  public static string strReason4GameOver; // accessing in UIGameOver
	GameObject carVehicle;
	GameObject Timertxt;
	Text timeText;
    public AudioSource levelfinishSound,timeupsound;
    public Slider timeSlider;
	bool GameOOrFinish;
	Transform SpeedoMeterStrans;


    void OnEnable() 
    {	
      //  isGameOver = false;
	//	isLevelFinish = false;
	//	GameOOrFinish = false;		 
	//	GameObject.Find("CanvGP").transform.FindChild("Canvas").FindChild("txtlevelno").GetComponent<Text>().text = " " + GameLoader.CurretnLevel;
	}

	void Update()
	{
	    if(isGameOver)
			CheckForLifeOver();

		if(isLevelFinish)
			CheckForLevelFinish();
	}
   
	void CheckForLifeOver()
	{
		PrepareGameOver ();
	}
	void CheckForLevelFinish()
	{
	//	levelfinishSound.Play ();
		PrepareGameOver ();
	}
    void PrepareGameOver()
    {
		GameObject.Find("CanvGP").transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(WaittoGameResult());
    }
	IEnumerator WaittoGameResult()
	{
		yield return new WaitForSeconds (1f);       
		GameObject.Find("CanvGameover").transform.GetChild(0).gameObject.SetActive(true);
	}

}




	