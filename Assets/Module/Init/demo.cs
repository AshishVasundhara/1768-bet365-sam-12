using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//​
//public class demo : MonoBehaviour
//{

////    public Text text;
////    string txt;
////    void Start()
////    {
////        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
////        var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
////        var context = activity.Call<AndroidJavaObject>("getApplicationContext");

////        txt += getCountryCode(context);
////        text.text = txt;

////    }
////​
////    public bool isSimSupport(AndroidJavaObject context)
////    {
////        AndroidJavaClass myAndroidJavaClass = new AndroidJavaClass("com.test.myapplication.AndroidPluginAccess");
////        bool gg = myAndroidJavaClass.CallStatic<bool>("isSimSupport", context);
////        return gg;
////​
////    }
////    public string getCountryCode(AndroidJavaObject context)
////    {
////        AndroidJavaClass myAndroidJavaClass = new AndroidJavaClass("com.test.myapplication.AndroidPluginAccess");
////        string gg = myAndroidJavaClass.CallStatic<string>("getCountryCode", context);
////        return gg;
////​
////    }
////    public string getCountryName(AndroidJavaObject context)
////    {
////        AndroidJavaClass myAndroidJavaClass = new AndroidJavaClass("com.test.myapplication.AndroidPluginAccess");
////        string gg = myAndroidJavaClass.CallStatic<string>("getCountryName", context);
////        return gg;
////​
////    }
//}