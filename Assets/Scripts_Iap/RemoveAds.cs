using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store.Example
{ 
	public class RemoveAds : MonoBehaviour {
		public static bool isRemoveAdsOwened  = false;
		public Transform CanvMainmTrans;
		public static bool isIAPInitialized;
		void Start () 
		{
			//PlayerPrefs.DeleteAll ();
			AdsSetter();
			if (!isIAPInitialized) {
				StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreIntitialized; //Handle the initialization of store events (calls function below - unneeded in this case)
				StoreEvents.OnMarketPurchase += onMarketPurchase;
				StoreEvents.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
				SoomlaStore.Initialize (new PurchableAssets ()); //Intialize the store
				checkPurchaseBalance ();
			}
		}
		public void onMarketPurchase(PurchasableVirtualItem pvi, string payload,Dictionary<string, string> extra)
		{
			Debug.Log("PURCHASED SUCCCC=================== --- ===> " + pvi.Name +"  "+ payload);
			GameObject.Find("MainMneuCanv").transform.GetChild(0).gameObject.SetActive(true);
		}
		void DisableAds()
		{			
			GameObject.Find("Admob_DnD").GetComponent<Admob_scripts>().Admob_hide_banner1();
			GameObject.Find("Admob_DnD").GetComponent<Admob_scripts>().enabled = false; //defaulet is true
		}
		void AdsSetter()
		{
			if(PlayerPrefs.HasKey(PPs.PPADSTATUS))
			{
				if(PlayerPrefs.GetInt(PPs.PPADSTATUS)==1)
				{
					isRemoveAdsOwened = true;
					DisableAds();
					CanvMainmTrans.Find("btnnoads").gameObject.SetActive(false);
				}
				else
				{
					CanvMainmTrans.Find("btnnoads").gameObject.SetActive(true);
				}
			}
			else
			{
				PlayerPrefs.SetInt(PPs.PPADSTATUS,0);
				PlayerPrefs.Save();	
				CanvMainmTrans.Find("btnnoads").gameObject.SetActive(true);
			}
		}
		public void onSoomlaStoreIntitialized()
		{
			Debug.Log ("SOOMLA STORE started");
			isIAPInitialized = true;
		}
		void Update()
		{
		}
		void checkPurchaseBalance()
		{
			Debug.Log ("Checking purchased balance .... "+ PPs.IAPITEM_ID_NOADS +"'s balance is = " + StoreInventory.GetItemBalance(PPs.IAPITEM_ID_NOADS));							// Print the current status of the IAP
			if (StoreInventory.GetItemBalance(PPs.IAPITEM_ID_NOADS) >= 1) 
			{
				ActivateRemoveAds();
				CanvMainmTrans.Find("btnnoads").gameObject.SetActive(false);
				//CanvMainmTrans.FindChild("btestorep").gameObject.SetActive(true);
				Debug.Log("Buying..... GREATE..!!!!!!");							// Print the current status of the IAP
			}	
		}
		void ActivateRemoveAds()
		{
			isRemoveAdsOwened = true; 
			DisableAds();
			PlayerPrefs.SetInt(PPs.PPADSTATUS,1);
			PlayerPrefs.Save();
		}
		public void onRestoreTransactionsStarted()
		{
			Debug.Log("SOOMLA STORE RESTORE CALLLLLLLLLEEEEEEDDDDDD");
		}
		public void onClickRemoveAds()
		{
			try 
			{
				//Debug.Log("Before attempt to purchase ");
				StoreInventory.BuyItem(PPs.IAPITEM_ID_NOADS);	// if the purchases can be completed sucessfully
				Debug.Log("After attempt to purchase ");
			} 
			catch(Exception e) 
			{																						// if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
				Debug.Log("SOOMLA/UNITY SucessFully Purchasedddd " + e.Message);							
			}
			//Debug.Log("Remove ads Button Clicked");
			Debug.Log ("--> "+ PPs.IAPITEM_ID_NOADS +" 's balance is = " + StoreInventory.GetItemBalance(PPs.IAPITEM_ID_NOADS));							// Print the current status of the IAP
		}
		public void onClickRestorePurchase()
		{
			try 
			{
				SoomlaStore.RestoreTransactions();													// restore purchases if possible
			} 
			catch (Exception e) 
			{
				Debug.Log("SOOMLA/UNITY" + e.Message);												// if restoring purchases fails (connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
			}
			Debug.Log("RESTORE ADS Button Clicked");
		}
	}
}
