using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_2_1 : MonoBehaviour {

    public float speed, temps,timerDebut = 0.0f;
    private int changeSpeed;


    void Start () {
        timerDebut = Time.deltaTime;
        PlayerPrefs.SetFloat("Temps", 0.0f);
    }

    private void Update()
    {
        timerDebut += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DangerLava"))
        {
            PlayerPrefs.SetInt("endGame", -1);
            TempsDeJeu();
            SceneManager.LoadScene("Score");
        }
        if (other.gameObject.CompareTag("Speed"))
        {
            other.gameObject.SetActive(false); //On désactive l'objet de la scène
            speed = speed * 2.0f;
            changeSpeed = 1;
        }
    }

    private void TempsDeJeu()
    {
        float timer;
        timer = timerDebut;
        PlayerPrefs.SetFloat("Temps", timer);
    }

    void reduceSpeed()
    {
        if (changeSpeed == 1)
        {
            if (temps > 10)
            {
                speed = speed / 2;
                temps = 0;
            }
            else
            {
                temps = temps + Time.deltaTime;
            }
        }
    }
}
