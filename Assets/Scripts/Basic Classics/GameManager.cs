using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Resonance {Movement, Echoing};
public class GameManager : Singleton<GameManager> {
	public Resonance waves;

	void Start () {
		waves = Resonance.Movement;
	}

	void Update () {
		switch (waves){
		case Resonance.Movement:
			
			break;
		case Resonance.Echoing:
			break;
		default:
			waves = Resonance.Movement;
			break;
		}
	}
}