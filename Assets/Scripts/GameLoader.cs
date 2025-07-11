using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {

	public static int CurretnLevel; 
	public static int MaxLevel;
	public  int[] LifeLimite;
	public int[] NeededScore;
	public static int[] LevelLifeLimite;
	public static int[] LevelFinishNeededScore;
	void Start () 
	{
		//PlayerPrefs.DeleteAll ();
		ExecuteFirstTimeForHighScore ();
        AssignAudioSettings();
		setGet_CurrentLevel(); // CurretnLevel = 4;
		serGet_MaxLevel (); //MaxLevel =7;
		LevelLifeLimite = new int[PPs.TOTAL_LEVEL];
		LevelFinishNeededScore = new int[PPs.TOTAL_LEVEL];
		AssignLevelFinshTime();
        AssignInputSettings();
	}
    void AssignInputSettings()
    {
        if (!PlayerPrefs.HasKey(PPs.PPINPUT_TOGGLE))
        {
            PlayerPrefs.SetInt(PPs.PPINPUT_TOGGLE, 1);
            PlayerPrefs.Save();
        }
    }
    void AssignAudioSettings()
    {
        if (PlayerPrefs.HasKey(PPs.PPAUDIO_TOGGLE))
        {
            AudioListener.volume = PlayerPrefs.GetInt(PPs.PPAUDIO_TOGGLE);
        }
        else
        {
            PlayerPrefs.SetInt(PPs.PPAUDIO_TOGGLE,1);
            AudioListener.volume = 1;
            PlayerPrefs.Save();
        }
    }
	void AssignLevelFinshTime()
	{
		

		for (int i = 0; i < 10; i++)
		{
			LevelLifeLimite [i] = LifeLimite[i] ;
			LevelFinishNeededScore [i] = NeededScore[i] ;

		}

	}

	void ExecuteFirstTimeForHighScore()
	{
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL1)) 
				PlayerPrefs.SetFloat(PPs.PPSHSCOREL1,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL2)) 
				PlayerPrefs.SetFloat(PPs.PPSHSCOREL2,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL3)) 
				PlayerPrefs.SetFloat(PPs.PPSHSCOREL3,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL4)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL4,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL5)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL5,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL6)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL6,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL7)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL7,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL8)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL8,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL9)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL9,1000);
		if (!PlayerPrefs.HasKey (PPs.PPSHSCOREL10)) 
			PlayerPrefs.SetFloat(PPs.PPSHSCOREL10,1000);
		PlayerPrefs.Save ();
	}
	void setGet_CurrentLevel()
	{
		if (PlayerPrefs.HasKey (PPs.PPCURR_LEVEL)) 
		{
			// assigning value to this variable is scirpt and UILEVELS.cs and GAMEFINISH(nextlevel).
			CurretnLevel = PlayerPrefs.GetInt(PPs.PPCURR_LEVEL);	
		} 
		else 
		{
			PlayerPrefs.SetInt(PPs.PPCURR_LEVEL,1);
			CurretnLevel = 1;
			PlayerPrefs.Save();
		}
	}
	void serGet_MaxLevel()
	{
		if (PlayerPrefs.HasKey(PPs.PPMAX_LEVEL)) 
		{
			// assigning value to this variable is scirpt and GAMEFINISH(nextlevel).
			// using in UILEVELS.cs 
			MaxLevel = PlayerPrefs.GetInt(PPs.PPMAX_LEVEL);	
		} 
		else 
		{
			PlayerPrefs.SetInt(PPs.PPMAX_LEVEL,1);
			MaxLevel = 1;
			PlayerPrefs.Save();
		}
	}
    public void OnClickBackToMM()
    {
        Application.LoadLevel(0);
    }
}
