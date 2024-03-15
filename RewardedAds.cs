using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
	[SerializeField] string _androidAdUnitId = "Rewarded_Android";
	[SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
	string _adUnitId = null; // This will remain null for unsupported platforms

	void Awake()
	{
		#if UNITY_ANDROID
			_adUnitId = _androidAdUnitId;
		#endif
	}

	public void LoadAd()
	{
		Debug.Log("Loading Ad: " + _adUnitId);
		Advertisement.Load(_adUnitId, this);
	}

	public void OnUnityAdsAdLoaded(string adUnitId)
	{
		Debug.Log("Ad Loaded: " + adUnitId);
	}

	public void ShowAd()
	{
		Advertisement.Show(_adUnitId, this);
	}

	public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
	{
		if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
		{
			LoadAd();
		}
	}

	#region Debug
	public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
	{
		Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
	}

	public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
	{
		Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
	}

	public void OnUnityAdsShowStart(string adUnitId) { }
	public void OnUnityAdsShowClick(string adUnitId) { }

	#endregion
}