using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    public void Credits()
    {

    }

    public void Back()
    {

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

    }
}
