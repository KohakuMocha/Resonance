using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public GameObject UIMainMenu;
    public GameObject UICredits;
    public GameObject KeyPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("Level");
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

    public void DisplayKey()
    {
        GameObject key = Instantiate<GameObject>(KeyPrefab);
        key.transform.parent = this.transform;
    }
    public void RemoveKey()
    {
       Destroy( this.GetComponent<Canvas>());
    }
}
