using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : Singleton<AdsInitializer>, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "5975587";
    [SerializeField] string _iOSGameId = "5975586";
    [SerializeField] bool _testMode = true;
    
    private string _gameId;

    protected override void Awake()
    {
        base.Awake();
        this.InitializeAds();
    }

    private void InitializeAds()
    {
#if UNITY_IOS
    _gameId = _iOSGameId;
#elif UNITY_ANDROID
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
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
