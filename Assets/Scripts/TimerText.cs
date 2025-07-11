using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

	public static float timerc;
	void Start () 
	{
		timerc = 0;
	}
	
	void Update () 
	{
		timerc += Time.deltaTime;
		int minutes = Mathf.FloorToInt(timerc / 60F);
		int seconds = Mathf.FloorToInt(timerc - minutes * 60);
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
		gameObject.GetComponent<Text> ().text =" " + niceTime;
	}

}



