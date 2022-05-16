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
    public TMP_Text totalTimeLivedText;

    public Canvas gameOver;
    public Canvas victoryObject;
    
    [HideInInspector]
    public static float totalTimeLived = 0f;

    float currentTimeToLive;
    bool isFreezed;
    bool finished = false;

    void Start() {
        finished = false;
        healthBar.fillAmount = 1;
        isFreezed = false;
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

    
    //transform a number of seconds into a string
    public string secondsToString(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60);
        seconds = Mathf.FloorToInt(seconds % 60);
        return minutes + " minutes and " + seconds + " seconds";
    }

    public void giveLife(float amount) {
        if(finished) return;
        currentTimeToLive += amount;
    }

    public void freezeLife(float seconds) {
        isFreezed = true;
        //start coroutine unFreeze
        StartCoroutine(unfreeze(seconds));
    }

    //create a routine that set isFreezed to false in n seconds
    IEnumerator unfreeze(float seconds) {
        yield return new WaitForSeconds(seconds);
        isFreezed = false;
    }

    public void Update() {
        
        if(finished) return;

        totalTimeToLive -= Time.deltaTime;

        if(totalTimeToLive <= 0) {
            triggerVictory();
        } else {
            totalTimeToLiveText.text = "Time until win " + getTimeText(totalTimeToLive, false);
            totalTimeLived += Time.deltaTime;

            if(isFreezed) {
                changeHealthColor(Color.grey);
                return;
            }

            if (currentTimeToLive > 15) {
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
        finished = true;
    }

    public void triggerVictory() {

        finished = true;

        //check if scene name is Map2
        if(SceneManager.GetActiveScene().name == "Map2") {
            victoryObject.gameObject.SetActive(true);
            totalTimeLivedText.text = "You did it in " + secondsToString(totalTimeLived);
        }

        Cursor.lockState = CursorLockMode.None;
        victoryObject.gameObject.SetActive(true);
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