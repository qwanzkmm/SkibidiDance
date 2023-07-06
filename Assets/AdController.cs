using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : MonoBehaviour
{
    [SerializeField] private string Reward = "Reward";

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        
        if (YandexSDK.YaSDK.instance.isInterstitialReady)
        {
            ShowInterstitial();
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    private void OnEnable()
    {
        YandexSDK.YaSDK.onRewardedAdReward += UserGotReward;
    }

    private void OnDisable()
    {
        YandexSDK.YaSDK.onRewardedAdReward -= UserGotReward;
    }

    public void ShowRewarded()
    {
        YandexSDK.YaSDK.instance.ShowRewarded(Reward);
        
        Cursor.lockState = CursorLockMode.Confined;
        
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    public void ShowInterstitial()
    {
        YandexSDK.YaSDK.instance.ShowInterstitial();

        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    public void UserGotReward(string reward)
    {
        if (this.Reward == reward)
        {
            _gameManager.coins += 1000;
        }
    }
}