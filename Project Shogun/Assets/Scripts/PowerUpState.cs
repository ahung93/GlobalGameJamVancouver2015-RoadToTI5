﻿using UnityEngine;
using System.Collections;

public class PowerUpState : MonoBehaviour {

	public enum state {
		FAST_MODE,
		NORMAL_MODE	
	};

	public PowerUpState.state currentState;

	public int powerUpTime;

	public int normalSpeed;

	// Use this for initialization
	void Start () {
		currentState = state.NORMAL_MODE;
		powerUpTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (currentState) {
		case state.FAST_MODE:
			transform.root.GetComponent<PlayerControl>().maxSpeed = 25;
			powerUpTime--;
			if (powerUpTime <= 0) {
				currentState = state.NORMAL_MODE;
				transform.root.GetComponent<PlayerControl>().maxSpeed = 11;
			}
			break;
		case state.NORMAL_MODE:
		default:
			break;
		}
	}
}