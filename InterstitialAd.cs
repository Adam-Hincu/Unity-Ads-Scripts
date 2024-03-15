using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
	[SerializeField] string _androidAdUnitId = "Interstitial_Android";
	[SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
	string _adUnitId; // This will remain null for unsupported platforms

	void Awake()
	{
		_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
			? _iOsAdUnitId
			: _androidAdUnitId;
	}

	public void LoadAd()
	{
		Debug.Log("Loading Ad: " + _adUnitId);
		Advertisement.Load(_adUnitId, this);
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
	public void OnUnityAdsAdLoaded(string adUnitId)
	{
		// Optionally execute code if the Ad Unit successfully loads content.
	}

	public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
	{
		Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
	}

	public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
	{
		Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
	}

	public void OnUnityAdsShowStart(string _adUnitId) { }
	public void OnUnityAdsShowClick(string _adUnitId) { }

	#endregion
}