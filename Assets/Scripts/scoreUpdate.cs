using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreUpdate : MonoBehaviour {

	public static int scoreValue;
	Text text;
	void Start () 
	{
//		print (" : : " + GameLoader.CurretnLevel);
		gameObject.transform.parent.Find ("txtlevelno").GetComponent<Text> ().text = "" + GameLoader.CurretnLevel;
		//assigned in GamePlayLoaderScript.
	}

	void Update () 
	{
		// print (" : : " + DestroyByContact.scoreValue);
		gameObject.GetComponent<Text> ().text = "" + scoreValue+" / "+ GameLoader.LevelFinishNeededScore[GameLoader.CurretnLevel-1];
	}
}
