using UnityEngine;
using System.Collections;

public class PlayPauseExit : MonoBehaviour {
	
	private static PlayPauseExit PPE_obj;
	void Awake()
	{
		if (! PPE_obj)
		{
			PPE_obj = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			bool iscanvLevel = false;
			/*
            if(Application.loadedLevelName == "MainMenu")
            {
               iscanvLevel =GameObject.Find("CanvLevels").transform.GetChild(0).gameObject.activeSelf;
            }
            */
			if (Application.loadedLevelName == "GamePlay" && GameOver.isGameOver == false)
			{
				gameObject.transform.GetChild(0).gameObject.SetActive(true);
				if (PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE) == 1)
					AudioListener.volume = 0;
				
				Time.timeScale = 0;
				
			}
			// else if (GameOver.isGameOver == false && Application.loadedLevelName != "MainMenu" && GameObject.Find("CanvLevels").transform.GetChild(0).gameObject.activeSelf != true && GameObject.Find("CanvLevels").transform.GetChild(0).gameObject.activeSelf != true)
			else if (Application.loadedLevelName == "MainMenu")
			{
				if (GameObject.Find("MainMneuCanv").transform.GetChild(0).gameObject.activeSelf == true)
				{
					print("-->More Apps.. I Quite");
					 Application.Quit();                    
					//GameObject.Find("MainMneuCanv").transform.GetChild(0).gameObject.SetActive(true);

				}
			}
		}
	}
}
