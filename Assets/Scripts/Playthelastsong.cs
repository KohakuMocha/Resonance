using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playthelastsong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision)
	{
		SoundManager.Instance.musicSource.clip = ResourceManager.Instance.Sounds["CalmForest"];
		SoundManager.Instance.musicSource.Play();
	}
}
