using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private static AdsManager Instance;
    private GameManager gm;
    private string gameId = "4220845";

    string mySurfacingId = "Rewarded_Android";
    bool testMode = false;


    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void SetGameManager(GameManager gm)
    {
        this.gm = gm;
    }

    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
        }
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        } else
        {
            gm.BuildNextLevel();
        }

    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        gm.BuildNextLevel();
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
