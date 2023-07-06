using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public Animator[] skibidiAnimators;

    public float timeToStop;
    public int coins;

    public AudioSource music;

    public AudioSource wednesday;
    public AudioSource phonk;
    public AudioSource standart;

    public GameObject tempWednesday;
    public GameObject tempPhonk;
    private void Start()
    {
        music.clip = standart.clip;
    }

    private void Update()
    {
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
    
}
