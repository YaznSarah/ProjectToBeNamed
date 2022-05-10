using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{   

    public Canvas startCanvas;
    public Canvas explainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadMainScene()
	{
		SceneManager.LoadScene("Map1");
	}

    public void OpenExplainations() {
        startCanvas.gameObject.SetActive(false);
        explainCanvas.gameObject.SetActive(true);
    }

    public void CloseExplainations() {
        startCanvas.gameObject.SetActive(true);
        explainCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
