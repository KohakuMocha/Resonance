using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {



	void OnTriggerEnter(Collider collision)
	{
		SoundManager.Instance.musicSource.clip = ResourceManager.Instance.Sounds["CalmForest"];
		SoundManager.Instance.musicSource.Play();
		GameObject.Find ("Canvas/Resonance").SetActive (true);
	}
	// Use this for initialization
	void Start () {
		GameObject.Find ("Canvas/Resonance").SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
