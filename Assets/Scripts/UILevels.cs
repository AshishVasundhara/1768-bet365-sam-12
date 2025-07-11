using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILevels : MonoBehaviour {

	Transform canvTrans;
    public Sprite levelLock;
	void Start () 
	{
	//	print ("UILevels...." + GameLoader.MaxLevel);
		canvTrans = gameObject.transform;
		setLevelAccessible ();
	}	
	public void setLevelAccessible()
	{
		Transform btn_bunch_trans = canvTrans.Find ("btnb").transform;
//		print(GameLoader.MaxLevel + "Child Buttons : " + btn_bunch_trans.childCount);
		for (int i=0; i<GameLoader.MaxLevel; i++) 
		{
			btn_bunch_trans.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
			//print("--->" + btn_bunch_trans.GetChild(i).gameObject.name);
		}
		for (int i=0; i<=btn_bunch_trans.childCount-1; i++) 
		{
			if (btn_bunch_trans.GetChild(i).gameObject.GetComponent<Button>().interactable == false)
			{
				btn_bunch_trans.GetChild(i).gameObject.GetComponent<Image>().sprite = levelLock;
			}
		}
	}
	public void OnclickBack()
	{
        GameObject.Find("MainMneuCanv").transform.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive (false);
	}
	public void OnClickLevelSelection(int Levelno)
	{	
		GameLoader.CurretnLevel = Levelno;
		PlayerPrefs.SetInt(PPs.PPCURR_LEVEL,Levelno);
		PlayerPrefs.Save();
	//	AsyncOperation async = Application.LoadLevelAsync("GamePlay");
	//	GameObject.Find ("CanvLoader").transform.GetChild (0).gameObject.SetActive (true);
	//	if(async.isDone)
			Application.LoadLevel("GamePlay");
	}
}





