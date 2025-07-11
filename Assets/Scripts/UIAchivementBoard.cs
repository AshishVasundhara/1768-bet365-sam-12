using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAchivementBoard : MonoBehaviour 
{
	Transform canvTrans;
	void Start () 
	{
		canvTrans = gameObject.transform;
		ListAllAchivements ();
	}
	void ListAllAchivements()
	{
		print ("MAx Level : " + GameLoader.MaxLevel);
		Transform boardTrans = canvTrans.Find ("AchiBoradPanel").Find ("board").transform;

		for (int i=0; i<GameLoader.MaxLevel-1; i++) 
		{
			int ii=i+1;
			print(PPs.PPSHSCORECMN + ii);
			boardTrans.GetChild(i).gameObject.SetActive(true);
			string tempstring ="Mission "+ ii + " = " + ConvertTimeToString(PlayerPrefs.GetFloat(PPs.PPSHSCORECMN + ii));
			boardTrans.GetChild(i).GetComponent<Text>().text = tempstring;
		//	toShare = string.Concat(tempstring + "\n",toShare);
		}
		//print(toShare);
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
	public void OnClickBack()
	{
		GameObject.Find("MainMneuCanv").transform.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}

}
