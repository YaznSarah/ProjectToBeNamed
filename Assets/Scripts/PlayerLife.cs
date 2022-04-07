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
    
    public void Update() {
        
        if (timeToLive > 60) {
            timeToLive -= Time.deltaTime;
            healthBar.fillAmount = timeToLive / 180;
            changeHealthColor(Color.green);

            //convert seconds in min and sec and ms string
            string min = Mathf.Floor(timeToLive / 60).ToString("00");
            string sec = Mathf.Floor(timeToLive % 60).ToString("00");
            string ms = Mathf.Floor((timeToLive * 100) % 100).ToString("00");
            timeToLiveText.text = min + ":" + sec + ":" + ms;

        } else if(timeToLive > 0) {
             timeToLive -= Time.deltaTime;
            healthBar.fillAmount = timeToLive / 180;

            //convert seconds in min and sec and ms string
            string min = Mathf.Floor(timeToLive / 60).ToString("00");
            string sec = Mathf.Floor(timeToLive % 60).ToString("00");
            string ms = Mathf.Floor((timeToLive * 100) % 100).ToString("00");
            timeToLiveText.text = min + ":" + sec + ":" + ms;
            changeHealthColor(Color.red);
        } else {
            triggerGameOver();
            // Destroy(gameObject);
        }

    }

    void triggerGameOver() {
        Cursor.lockState = CursorLockMode.None;
        gameOver.gameObject.SetActive(true);
    }

    public void onRestart() {
        SceneManager.LoadScene("EliottGScene");
    }

    void changeHealthColor(Color healthColor)
    {
        healthBar.color = healthColor;
    }
 
}