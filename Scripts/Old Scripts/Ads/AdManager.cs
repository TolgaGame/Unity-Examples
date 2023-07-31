using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	public bool TestAds = false;        //This has to be true when testing, and has to be false when publishing!!!
    public bool unityAds = true;        //Set this false if you want to use Admob, set this true if you want to use Unity Ads!!!

	private static BannerView bannerView;
	private InterstitialAd interstitialView;
	RewardBasedVideoAd rewardBasedVideoAd;


	public static bool firstTime = true;

	public static AdManager admanagerInstance = null;

    //These IDs have to be changed to the actual app and ad IDs!!!
	[SerializeField] private string appID = "";
	[SerializeField] private string bannerID = "ca-app-pub-3940256099942544/6300978111";
	[SerializeField] private string interstitialID = "ca-app-pub-3940256099942544/1033173712";
	[SerializeField] private string rewardVideoID = "ca-app-pub-3940256099942544/5224354917";

	void Awake()
	{		
		if (admanagerInstance == null) {
			admanagerInstance = this;
		} else if (admanagerInstance != this) {
			Destroy (gameObject);
		}

		if (firstTime) {
			firstTime = false;
			DontDestroyOnLoad (gameObject);		

			MobileAds.Initialize (appID);
			RequestInterstitial ();
			admanagerInstance.RequestBanner ();
		}
	}

	void Start()
	{
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleOnAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;

		//Reward
		// Get singleton reward based video ad reference.
		admanagerInstance.rewardBasedVideoAd = RewardBasedVideoAd.Instance;

		//Video Ad Events
		// Called when an ad request has successfully loaded.
		rewardBasedVideoAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
		// Called when an ad request failed to load.
		rewardBasedVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		// Called when an ad is shown.
		rewardBasedVideoAd.OnAdOpening += HandleRewardBasedVideoOpened;
		// Called when the ad starts to play.
		rewardBasedVideoAd.OnAdStarted += HandleRewardBasedVideoStarted;
		// Called when the user should be rewarded for watching a video.
		rewardBasedVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
		// Called when the ad is closed.
		rewardBasedVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;
		// Called when the ad click caused the user to leave the application.
		rewardBasedVideoAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

		//request reward video
		admanagerInstance.RequestRewardBasedVideo();
    }

	#region AdmobBannerCallBackEvents
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		//ShowAdmobBanner();
		MonoBehaviour.print("HandleAdLoaded event received");
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		//		RequestBanner ();
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
			+ args.Message);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdOpened event received");
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		//		bannerView.Destroy ();
		MonoBehaviour.print("HandleAdClosed event received");
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLeavingApplication event received");
	}
    #endregion

    //Call this to show banner ad
    public void ShowAdmobBanner()
	{
		bannerView.Show();
	}

    //Call this to hide banner ad
    public void HideAdmobBanner()
	{
		bannerView.Hide ();
	}

	//Call this to show interstitial ad
	public void ShowAdmobInterstitial()
	{
		if (admanagerInstance.interstitialView.IsLoaded()) 
			admanagerInstance.interstitialView.Show();

		RequestInterstitial ();
	}

    //Call this to show reward video ad
    public void ShowAdmobRewardVideo()
	{
		if (rewardBasedVideoAd.IsLoaded()) {
			rewardBasedVideoAd.Show();
			//When completed this function is called : HandleRewardBasedVideoRewarded
		}
	}


	#region AdmobRequests
	private void RequestBanner()
	{
		bannerView = new BannerView (bannerID, AdSize.Banner, AdPosition.Bottom);

		AdRequest request = null;
		if(!TestAds)
		request = new AdRequest.Builder ().Build();
		
		if(TestAds)
		{
			request = new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice(SystemInfo.deviceUniqueIdentifier)  // My test device.
			.Build();
		}
		bannerView.LoadAd (request);
	}

	private void RequestInterstitial()
	{
		if (admanagerInstance.interstitialView != null)
		{
			admanagerInstance.interstitialView.Destroy();
		}

		admanagerInstance.interstitialView = new InterstitialAd(interstitialID);		//orignal
		// Create an empty ad request.

		AdRequest request = null;

		if(!TestAds)
			request = new AdRequest.Builder().Build();

		if(TestAds)
		{
			request = new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice(SystemInfo.deviceUniqueIdentifier)  // My test device.
			.Build();						
		}
		admanagerInstance.interstitialView.LoadAd(request);
	}

	private void RequestRewardBasedVideo()
	{
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the rewarded video ad with the request.
		admanagerInstance.rewardBasedVideoAd.LoadAd(request, rewardVideoID);
	}
	#endregion


	#region AdmobRewardCallBackEvents
	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print(
			"HandleRewardBasedVideoFailedToLoad event received with message: "
			+ args.Message);
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		admanagerInstance.RequestRewardBasedVideo();

		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
	}

	//This is called when user completes Admob reward video
	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		Debug.Log ("The ad was shown successfully");
        FindObjectOfType<RewardButton>().AddReward();       //Adds reward to the player when rewardVideo is finished successfully
    }

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}
    #endregion     //Reward Events Ends




    //Uity3D related Events

    //------------------------------------------------------------
    //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!

        /*
    //Call this to show video ad
    public void ShowUnityVideoAd()
    {
        Debug.Log("ShowUnityVideoAd");

        if (Advertisement.IsReady("video"))
            Advertisement.Show("video");
    }

    //Call this to show reward video ad
    public void ShowUnityRewardVideoAd()
    {
        Debug.Log("ShowUnityRewardVideoAd");
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Debug.Log("Showing Advertisement");
            var options = new ShowOptions { resultCallback = HandleSHowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleSHowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The Unity Reward ad was shown successfully");
                FindObjectOfType<RewardButton>().AddReward();       //Adds reward to the player when rewardVideo is finished successfully
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad was skipped");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad fialed to be shown");
                break;
        }
    }
    */
}
