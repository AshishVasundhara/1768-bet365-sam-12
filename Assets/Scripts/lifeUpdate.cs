using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lifeUpdate : MonoBehaviour
{

	public static int life;
	public Slider lifeSlider;
	Text text;
	void Start () 
	{
		lifeSlider.minValue = 0;
		lifeSlider.maxValue = GameLoader.LevelLifeLimite [GameLoader.CurretnLevel - 1];
		//	life = 5; // is assigned in GameLoader script..



	}
	
	void Update () 
	{
		//gameObject.GetComponent<Text>().text = life + "";
		lifeSlider.value = life;
	}
}



