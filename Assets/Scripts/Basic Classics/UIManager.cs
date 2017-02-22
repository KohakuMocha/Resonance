using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public GameObject UIMainMenu;
    public GameObject UICredits;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("Cave");
    }

    public void Credits()
    {
        UIMainMenu.SetActive(false);
        UICredits.SetActive(true);
    }

    public void Back()
    {
        UICredits.SetActive(false);
        UIMainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
