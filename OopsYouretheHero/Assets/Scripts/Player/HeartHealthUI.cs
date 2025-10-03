using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class HeartHealthUI : MonoBehaviour
{
    public CharacterStats playerHealth;
    public GameObject health;
    public RectTransform healthUI;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool healthSound = false;
    public bool soundCalled = false;
    public bool uiCalled = false;

    public bool HealthDepletion = false;
    public bool inBetweenValues = false;

    void Start()
    {
        playerHealth = GetComponent<PlayerStats>();
        health = GameObject.FindGameObjectWithTag("PlayerHealthUI");

        healthUI = health.GetComponent<RectTransform>();
        //Canvas.ForceUpdateCanvases();

        HealthDepletion = false;


        soundCalled = false;
        uiCalled = false;
        inBetweenValues = false;

    }


    void Update()
    {

        StartCoroutine("HealthSystemEvent");

    }

    IEnumerator ResetSoundBool()
    {
        yield return new WaitForSeconds(0.5f);
        soundCalled = false;



    }

    IEnumerator ResetUIBool()
    {
        yield return new WaitForSeconds(1);
        uiCalled = false;


    }

    IEnumerator ResetHealthBool()
    {
        yield return new WaitForSeconds(1);


        inBetweenValues = false;
        HealthDepletion = false;


    }


    public void PlaySound()
    {


        AudioManager.instance.PlayOneShot(FMODEvents.instance.loseHealth, this.transform.position);


    }

    public void ShakeUI()
    {
        var duration = 0.4f;
        // healthUI.DOPunchAnchorPos(punch: Vector3.back * 1, duration: 0.2f, vibrato: 0, elasticity: 0);
        healthUI.DOPunchAnchorPos(punch: Vector2.down * 4, duration: 0.4f, vibrato: 0, elasticity: 0);



        healthUI.DOShakeAnchorPos(duration: 0.2f, strength: 0.2f, vibrato: 5).SetDelay(duration * 0.5f);


    }

    IEnumerator HealthSystemEvent()
    {
        // PlaySound();
       // Debug.Log("event has been started");
        if (playerHealth.health >= 75)
        {
            numOfHearts = 4;

        }



        //Crazy thought: if health == 74 -> play the sound once. Only have it play when the numbeer is specific rather than a range

        if (playerHealth.health <= 75 && playerHealth.health >= 50)
        {
            numOfHearts = 3;


            if (inBetweenValues == false)
            {


                inBetweenValues = true;


                if (inBetweenValues == true)
                {

                    if (!soundCalled)
                    {
                        soundCalled = true;
                        PlaySound();
                        //soundCalled = false;

                        if (soundCalled == true)
                        {

                            //soundCalled = false;
                            StartCoroutine(ResetSoundBool());
                            //StopCoroutine(ResetSoundBool());
                        }
                    }

                    if (!uiCalled)
                    {
                        uiCalled = true;
                        ShakeUI();
                        //uiCalled = false;

                        if (uiCalled == true)
                        {
                            StartCoroutine(ResetUIBool());
                        }

                    }

                    // inBetweenValues = false;


                }



            }
        }



        if (playerHealth.health <= 49 && playerHealth.health >= 25)
        {
            numOfHearts = 2;


            if (inBetweenValues == true)
            {


                inBetweenValues = false;


                if (inBetweenValues == false)
                {

                    if (!soundCalled)
                    {
                        soundCalled = true;
                        PlaySound();
                        //soundCalled = false;

                        if (soundCalled == true)
                        {

                            //soundCalled = false;
                            StartCoroutine(ResetSoundBool());
                            //StopCoroutine(ResetSoundBool());
                        }
                    }

                    if (!uiCalled)
                    {
                        uiCalled = true;
                        ShakeUI();
                        //uiCalled = false;

                        if (uiCalled == true)
                        {
                            StartCoroutine(ResetUIBool());
                        }

                    }




                }



            }

        }




        if (playerHealth.health <= 24 && playerHealth.health >= 0)
        {
            numOfHearts = 1;

            if (inBetweenValues == false)
            {


                inBetweenValues = true;


                if (inBetweenValues == true)
                {

                    if (!soundCalled)
                    {
                        soundCalled = true;
                        PlaySound();
                        //soundCalled = false;

                        if (soundCalled == true)
                        {

                            //soundCalled = false;
                            StartCoroutine(ResetSoundBool());
                            //StopCoroutine(ResetSoundBool());
                        }
                    }

                    if (!uiCalled)
                    {
                        uiCalled = true;
                        ShakeUI();
                        //uiCalled = false;

                        if (uiCalled == true)
                        {
                            StartCoroutine(ResetUIBool());
                        }

                    }


                }

            }

        }


        if (playerHealth.health == 0)
        {


            if (!soundCalled)
            {
                soundCalled = true;
                PlaySound();

                if (soundCalled == true)
                {
                    StartCoroutine(ResetSoundBool());
                }

            }

            if (!uiCalled)
            {
                uiCalled = true;
                ShakeUI();


                if (uiCalled == true)
                {
                    StartCoroutine(ResetUIBool());
                }
            }


        }



        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;

            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            }

            else
            {
                hearts[i].enabled = false;

            }


        }

        yield return new WaitForSeconds(0.5f);
    }

}
