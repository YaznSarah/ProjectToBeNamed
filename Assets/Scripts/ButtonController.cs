using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadMainScene()
	{
		SceneManager.LoadScene("EliottGScene");
	}

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
