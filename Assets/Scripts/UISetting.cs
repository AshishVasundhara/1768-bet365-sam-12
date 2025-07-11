using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISetting : MonoBehaviour {

	Transform canv_trans;
	public Sprite sprtOnAudio, sprtOffAudio,sprtSensor,sprtSteer;
	void Start () {
		canv_trans = gameObject.transform;
		SetAudioToggle();	
		SetInputToggle();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void OnClickInputToggle()
	{
		if (PlayerPrefs.GetInt(PPs.PPINPUT_TOGGLE) == 1)
		{
			PlayerPrefs.SetInt(PPs.PPINPUT_TOGGLE, 0);
			canv_trans.Find("btnInputmod").GetComponent<Image>().sprite = sprtSensor;
		}
		else if (PlayerPrefs.GetInt(PPs.PPINPUT_TOGGLE) == 0)
		{
			PlayerPrefs.SetInt(PPs.PPINPUT_TOGGLE, 1);
			canv_trans.Find("btnInputmod").GetComponent<Image>().sprite = sprtSteer;
		}
		PlayerPrefs.Save();   
	}   
	public void OnClickAudioToggle()
	{
		if (PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE) == 1)
		{
			AudioListener.volume = 0f;
			PlayerPrefs.SetInt(PPs.PPAUDIO_TOGGLE,0);
			canv_trans.Find("btnSound").GetComponent<Image>().sprite = sprtOffAudio;
		}
		else if (PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE) == 0)
		{
			AudioListener.volume = 1f;
			PlayerPrefs.SetInt(PPs.PPAUDIO_TOGGLE, 1);
			canv_trans.Find("btnSound").GetComponent<Image>().sprite = sprtOnAudio;
		}
		PlayerPrefs.Save();   
	}

	public void SetInputToggle()
	{
		if (PlayerPrefs.GetInt(PPs.PPINPUT_TOGGLE) == 1)
		{
			canv_trans.Find("btnInputmod").GetComponent<Image>().sprite = sprtSteer;
		}
		else
		{
			canv_trans.Find("btnInputmod").GetComponent<Image>().sprite = sprtSensor;
		}
	}
	public void SetAudioToggle()
	{
		if (PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE) == 1)
		{
			AudioListener.volume = 1;	
			canv_trans.Find("btnSound").GetComponent<Image>().sprite = sprtOnAudio;
		}
		else
		{
			AudioListener.volume = 0;
			canv_trans.Find("btnSound").GetComponent<Image>().sprite = sprtOffAudio;
		}
	}

	public void OnClickBack()
	{
		GameObject.Find("MainMneuCanv").transform.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
