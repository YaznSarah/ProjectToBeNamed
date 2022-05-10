using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
 
    public Image healthBar;
    public float timeToLive = 120;
    public float totalTimeToLive = 180;
    public TMP_Text timeToLiveText;
    public TMP_Text totalTimeToLiveText;
    public Canvas gameOver;
    public Canvas victoryObject;
     float currentTimeToLive;

    void Start() {
        healthBar.fillAmount = 1;
        gameOver.gameObject.SetActive(false);
        victoryObject.gameObject.SetActive(false);
                currentTimeToLive = timeToLive;
        timeToLiveText.text = getTimeText(currentTimeToLive);
    }

    string getTimeText(float timeToLive, bool withSecond = true) {
            string min = Mathf.Floor(timeToLive / 60).ToString("00");
            string sec = Mathf.Floor(timeToLive % 60).ToString("00");
            if(withSecond) {
                string ms = Mathf.Floor((timeToLive * 100) % 100).ToString("00");
                return min + ":" + sec + ":" + ms;   
            } else {
                return min + ":" + sec;   
            }
    }

    public void giveLife(float amount) {
        currentTimeToLive += amount;
    }

    public void Update() {
        
        totalTimeToLive -= Time.deltaTime;

        if(totalTimeToLive <= 0) {
            triggerVictory();
        } else {
            totalTimeToLiveText.text = "Time to survive " + getTimeText(totalTimeToLive, false);
         if (currentTimeToLive > 60) {
            currentTimeToLive -= Time.deltaTime;
            healthBar.fillAmount = currentTimeToLive / timeToLive;
            changeHealthColor(Color.green);

            //convert seconds in min and sec and ms string
            timeToLiveText.text = getTimeText(currentTimeToLive);

        } else if(currentTimeToLive > 0) {
             currentTimeToLive -= Time.deltaTime;
            healthBar.fillAmount = currentTimeToLive / timeToLive;

            //convert seconds in min and sec and ms string
            timeToLiveText.text = getTimeText(currentTimeToLive);
            changeHealthColor(Color.red);
        } else {
            triggerGameOver();
        }

}
    }

    public void triggerGameOver() {
        Cursor.lockState = CursorLockMode.None;
        gameOver.gameObject.SetActive(true);
    }

    public void triggerVictory() {
        Cursor.lockState = CursorLockMode.None;
        victoryObject.gameObject.SetActive(true);
        // Time.timeScale = 0;
    }

    public void onRestart() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void goToNextLevel() {
        SceneManager.LoadScene("Map2");
    } 

    void changeHealthColor(Color healthColor)
    {
        healthBar.color = healthColor;
    }

    public void returnToMenu() {
        SceneManager.LoadScene("Menu");
    }
 
}