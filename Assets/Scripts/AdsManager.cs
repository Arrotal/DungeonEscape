using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour

{
    
    [System.Obsolete]
    public void ShowRewardedAd()
    {
        Debug.Log("Ad Starting");
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Debug.Log("Ad Playing");
            Advertisement.Show("Rewarded_Android", options);
        }
    }


    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("Ad Failed");
                break;
            case ShowResult.Finished:
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped");
                break;


        }
    }
}
