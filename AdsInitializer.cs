using UnityEngine;
using UnityEngine.Advertisements;
using static UnityEngine.Advertisements.Advertisement;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
	[SerializeField] RewardedAds rewardedAds;
	[SerializeField] InterstitialAd interstitialAd;

	[Space(10)]

	[SerializeField] string _androidGameId;
	[SerializeField] string _iOSGameId;
	[SerializeField] bool _testMode = true;
	private string _gameId;

	void Awake()
	{
		InitializeAds();
	}

	public void InitializeAds()
	{
		#if UNITY_ANDROID
				_gameId = _androidGameId;
		#elif UNITY_EDITOR
				_gameId = _androidGameId; //Only for testing the functionality in the Editor
		#endif

		if (!Advertisement.isInitialized && Advertisement.isSupported)
		{
			Advertisement.Initialize(_gameId, _testMode, this);
		}
	}


	public void OnInitializationComplete()
	{
		Debug.Log("Unity Ads initialization complete.");

		LoadAds();
	}

	public void LoadAds()
	{
		rewardedAds.LoadAd();
		interstitialAd.LoadAd();
	}

	public void OnInitializationFailed(UnityAdsInitializationError error, string message)
	{
		Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
	}
}