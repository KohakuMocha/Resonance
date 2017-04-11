using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.Instance.musicSource.clip = ResourceManager.Instance.Sounds["SadCave"];
        SoundManager.Instance.musicSource.Play();
        SoundManager.Instance.musicSource.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
