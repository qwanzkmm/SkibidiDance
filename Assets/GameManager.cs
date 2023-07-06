using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public Animator[] skibidiAnimators;

    public TextMeshProUGUI coinsText;
    
    public GameObject toiletA;
    public GameObject toiletB;
    public GameObject toiletC;
    public GameObject toiletD;
    public GameObject toiletE;
    public GameObject toiletF;
    
    public GameObject toiletAT;
    public GameObject toiletBT;
    public GameObject toiletCT;
    public GameObject toiletDT;
    public GameObject toiletET;
    public GameObject toiletFT;

    public float timeToStop;
    public int coins;

    public AudioSource music;

    public AudioSource wednesday;
    public AudioSource phonk;
    public AudioSource standart;

    public GameObject tempWednesday;
    public GameObject tempPhonk;

    private AdController _adController;
    private void Start()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            LoadAll();
        }
        music.clip = standart.clip;
        _adController = GetComponent<AdController>();
    }

    private void Update()
    {
        coinsText.text = coins.ToString();
        timeToStop -= Time.deltaTime;

        if (timeToStop <= 0)
        {
            foreach (Animator animator in skibidiAnimators)
            {
                animator.Play("Idle");
                music.Pause();
            }
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Animator animator in skibidiAnimators)
            {
                animator.Play("Dance");
                music.Pause();
            }
            music.Play();
            timeToStop = 1f;
            coins += 5;
            PlayerPrefs.SetInt("coins", coins);
        }
    }


    public void PlayMusic(int index)
    {
        switch (index)
        {
            case 0:
                music.clip = standart.clip;
                break;
            case 1:
                if (PlayerPrefs.GetString("wednesday") == "1")
                {
                    music.clip = wednesday.clip;
                    
                }
                else
                {
                    //play ads
                    tempWednesday.SetActive(false);
                    PlayerPrefs.SetString("wednesday", "1");
                    music.clip = wednesday.clip;

                }
                break;
            case 2:
                if (PlayerPrefs.GetString("phonk") == "1")
                {
                    music.clip = phonk.clip;
                }
                else
                {
                    //play ads
                    tempPhonk.SetActive(false);
                    PlayerPrefs.SetString("phonk", "1");
                    music.clip = phonk.clip;
                }
                break;
        }
    }

    public void BuyToilet(string name)
    {
        switch (name)
        {
            case "toiletA":
                if (coins >= 1000)
                {
                    coins -= 1000;
                    toiletA.SetActive(true);
                    toiletAT.SetActive(false);
                    PlayerPrefs.SetInt("toiletA", 1);
                }
                break;
            
            case "toiletB":
                if (coins >= 1000)
                {
                    coins -= 1000;
                    toiletB.SetActive(true);
                    toiletBT.SetActive(false);
                    PlayerPrefs.SetInt("toiletB", 1);
                }
                break;
            
            case "toiletC":
                if (coins >= 2500)
                {
                    coins -= 2500;
                    toiletC.SetActive(true);
                    toiletCT.SetActive(false);
                    PlayerPrefs.SetInt("toiletC", 1);
                }
                break;
            
            case "toiletD":
                if (coins >= 5000)
                {
                    coins -= 5000;
                    toiletD.SetActive(true);
                    toiletDT.SetActive(false);
                    PlayerPrefs.SetInt("toiletD", 1);
                }
                break;
            
            case "toiletE":
                if (coins >= 9000)
                {
                    coins -= 9000;
                    toiletE.SetActive(true);
                    toiletET.SetActive(false);
                    PlayerPrefs.SetInt("toiletE", 1);
                }
                break;
                        
            case "toiletF":
                if (coins >= 16000)
                {
                    coins -= 16000;
                    toiletF.SetActive(true);
                    toiletFT.SetActive(false);
                    PlayerPrefs.SetInt("toiletF", 1);
                }
                break;
        }
        
    }

    public void CoinsForAds()
    {
        _adController.ShowRewarded();
    }


    public void SaveAll()
    {
        PlayerPrefs.SetInt("coins", coins);
    }
    
    private void LoadAll()
    {
        coins = PlayerPrefs.GetInt("coins");
        
        toiletA.SetActive(PlayerPrefs.GetInt("toiletA") == 1);
        toiletAT.SetActive(PlayerPrefs.GetInt("toiletA") == 0);
        
        toiletB.SetActive(PlayerPrefs.GetInt("toiletB") == 1);
        toiletBT.SetActive(PlayerPrefs.GetInt("toiletB") == 0);
        
        toiletC.SetActive(PlayerPrefs.GetInt("toiletC") == 1);
        toiletCT.SetActive(PlayerPrefs.GetInt("toiletC") == 0);
        
        toiletD.SetActive(PlayerPrefs.GetInt("toiletD") == 1);
        toiletDT.SetActive(PlayerPrefs.GetInt("toiletD") == 0);
        
        toiletE.SetActive(PlayerPrefs.GetInt("toiletE") == 1);
        toiletET.SetActive(PlayerPrefs.GetInt("toiletE") == 0);
        
        toiletF.SetActive(PlayerPrefs.GetInt("toiletF") == 1);
        toiletFT.SetActive(PlayerPrefs.GetInt("toiletF") == 0);
        
        tempPhonk.SetActive(PlayerPrefs.GetString("phonk") == "0");
        tempWednesday.SetActive(PlayerPrefs.GetString("wednesday") == "0");
    }
    
}
