using UnityEngine;
using System.Collections;

public class UIPlayPauseExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        
	}
	
	void Update () {
	
	}
    public void OnClickPlay() // after pause
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE) == 1 && AudioListener.volume == 0)
            AudioListener.volume = 1;
    }
    public void OnClickExit()
    {
        if (Application.loadedLevelName == "GamePlay")
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            Application.LoadLevel("MainMenu");
            if (PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE) == 1 && AudioListener.volume == 0)
                AudioListener.volume = 1;

        }
    }
}
