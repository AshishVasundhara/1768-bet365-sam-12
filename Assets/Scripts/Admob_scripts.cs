using UnityEngine;
using System.Collections;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;
using UnityEngine.UI;
using System.Collections.Generic;
//using UnityEngine.SocialPlatforms;
//using UnityEngine.SocialPlatforms.GameCenter;
using System;
//using GoogleMobileAds.Common;


public class Admob_scripts : MonoBehaviour {
	
	public static Admob_scripts instance;
	public string ADS_ADMOB_INTERSTT;
	//private BannerView bannerView;
	//private InterstitialAd interstitial;

    private static Admob_scripts Admob_script;
    void Awake()
    {
        if (!Admob_script)
        {
            Admob_script = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
       // RequestBanner();
        RequestInterstitial();
    }

	
	public void Admob_Show_banner1()
	{
		if (Application.loadedLevel != 0)
		{			
			//bannerView.Show ();
		}
	}
	public void Admob_hide_banner1()
	{	
		//bannerView.Hide();
	}
	//	public void Admob_destroy_banner1()
	//	{
	//		bannerView.Destroy ();
	//	}
    /*
	public void Admob_Request_Interstitial2()
	{
		Time.timeScale = 1;
		RequestInterstitial();
	}
	public void Admob_Show_Interstitial2()
	{
		Time.timeScale = 1;
		ShowInterstitial();
	}
     * */
	public void RequestBanner()
	{

		// Create a 320x50 banner at the top of the screen.
	//	bannerView = new BannerView("", AdSize.SmartBanner, AdPosition.Top);
		//bannerView = new BannerView("ca-app-pub-7203748587441964/4989487338", AdSize.SmartBanner, AdPosition.Top);
		//bannerView = new BannerView(ADS_ADMOB_BANNER, AdSize.SmartBanner, AdPosition.Bottom);
       // bannerView = new BannerView("ca-app-pub-8628095956492351/3766073022", AdSize.Banner, AdPosition.Top);
		// Register for ad events.
		/*
		bannerView.AdLoaded += HandleAdLoaded;
		bannerView.AdFailedToLoad += HandleAdFailedToLoad;
		bannerView.AdOpened += HandleAdOpened;
		bannerView.AdClosing += HandleAdClosing;
		bannerView.AdClosed += HandleAdClosed;
		bannerView.AdLeftApplication += HandleAdLeftApplication;
		*/
		// Load a banner ad.
		//AdRequest request = new AdRequest.Builder ().Build ();
		//bannerView.LoadAd(request);
		if (Application.loadedLevel != 0)
		{
			//bannerView.Show ();
		}
	}
	public void RequestInterstitial()
	{
        //interstitial = new InterstitialAd("");
		//interstitial = new InterstitialAd(ADS_ADMOB_INTERSTT);
		// Register for ad events.
		/*
		interstitial.AdLoaded += HandleInterstitialLoaded;
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.AdOpened += HandleInterstitialOpened;
		interstitial.AdClosing += HandleInterstitialClosing;
		interstitial.AdClosed += HandleInterstitialClosed;
		interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
		*/
//		GoogleMobileAdsDemoHandler handler = new GoogleMobileAdsDemoHandler();
		//		interstitial.SetInAppPurchaseHandler(handler);
		// Load an interstitial ad.
		//AdRequest request1 = new AdRequest.Builder ().Build ();
		//interstitial.LoadAd(request1);
	}
   
	public void ShowInterstitial()
	{
		//if (interstitial.IsLoaded())
		//{
		//	interstitial.Show();
  //          print("ok");
		//}
        RequestInterstitial();

	}
	#region Banner callback handlers
	
	public void HandleAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}
	
	//public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	//{
	//	print("HandleFailedToReceiveAd event received with message: " + args.Message);
	//}
	
	public void HandleAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}
	
	void HandleAdClosing(object sender, EventArgs args)
	{
		print("HandleAdClosing event received");
	}
	
	public void HandleAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}
	
	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}
	
	#endregion
	
	#region Interstitial callback handlers
	
	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		print("HandleInterstitialLoaded event received.");
	}
	
	//public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	//{
	//	print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	//}
	
	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		print("HandleInterstitialOpened event received");
	}
	
	void HandleInterstitialClosing(object sender, EventArgs args)
	{
		print("HandleInterstitialClosing event received");
	}
	
	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		print("HandleInterstitialClosed event received");
	}
	
	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		print("HandleInterstitialLeftApplication event received");
	}
	
	#endregion
}





//public class Admob_scripts : MonoBehaviour {
