using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
 
    public Image healthBar;
    public float timeToLive = 180;
    public TMP_Text timeToLiveText;
    public Canvas gameOver;
    public Canvas victoryObject;
 
    void Start() {
        healthBar.fillAmount = 1;
        gameOver.gameObject.SetActive(false);
        victoryObject.gameObject.SetActive(false);
        timeToLive = 180;
        timeToLiveText.text = getTimeText();
    }

    string getTimeText() {
            string min = Mathf.Floor(timeToLive / 60).ToString("00");
            string sec = Mathf.Floor(timeToLive % 60).ToString("00");
            string ms = Mathf.Floor((timeToLive * 100) % 100).ToString("00");
            return min + ":" + sec + ":" + ms;   
    }

    public void Update() {
        
        if (timeToLive > 60) {
            timeToLive -= Time.deltaTime;
            healthBar.fillAmount = timeToLive / 180;
            changeHealthColor(Color.green);

            //convert seconds in min and sec and ms string
            timeToLiveText.text = getTimeText();

        } else if(timeToLive > 0) {
             timeToLive -= Time.deltaTime;
            healthBar.fillAmount = timeToLive / 180;

            //convert seconds in min and sec and ms string
            timeToLiveText.text = getTimeText();
            changeHealthColor(Color.red);
        } else {
            triggerGameOver();
        }

    }

    void triggerGameOver() {
        Cursor.lockState = CursorLockMode.None;
        gameOver.gameObject.SetActive(true);
    }

    public void triggerVictory() {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("aaaa");
        victoryObject.gameObject.SetActive(true);
        Debug.Log("bbbb");
        // Time.timeScale = 0;
    }

    public void onRestart() {
        SceneManager.LoadScene("EliottGScene");
    }

    void changeHealthColor(Color healthColor)
    {
        healthBar.color = healthColor;
    }
 
}