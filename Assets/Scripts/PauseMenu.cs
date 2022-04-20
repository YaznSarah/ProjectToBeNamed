using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField]
  private GameObject _pauseMenu;

  public void Pause()
  {
    _pauseMenu.SetActive(true);
    Time.timeScale = 0f;
  }

  public void Resume()
  {
    _pauseMenu.SetActive(false);
    Time.timeScale = 1f;
  }

  public void Home(int sceneID)
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(sceneID);
  }
}
