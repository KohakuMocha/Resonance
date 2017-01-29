using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States {Movement, Echoing, Idle};
public class GameManager : Singleton<GameManager> {
	public States waves;

	void Start () {
		waves = States.Movement;
	}

	void Update () {
		switch (waves){
		case States.Movement:
			
			break;
		case States.Echoing:
			break;
		default:
			waves = States.Movement;
			break;
		}
	}
}