﻿using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{

	// Sound for when the bomb crate is picked up.

	//public Rigidbody2D weaponRB;

	public GameObject weaponObject;

	void Awake()
	{
		// Setting up the reference.	
	}

	void Start() 
	{
		Destroy (gameObject, 8);		
	}

	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			// ... play the pickup sound effect.
			SoundManager.instance.Play("WalkGrass");

			// Enable the ShurikenThrow script the player has.

			if 	((other.GetComponent<WeaponThrow>().weaponCount == 0) || (other.GetComponent<SpriteRenderer>().sprite.name == "fireball" )){

				other.GetComponent<WeaponThrow>().weaponCount = 1;

				// Set the sprite to be the current object sprite
				other.GetComponent<WeaponThrow>().weaponSprite = weaponObject.GetComponent<SpriteRenderer>().sprite;

				other.GetComponent<WeaponThrow>().weaponRB = weaponObject.GetComponent<Rigidbody2D>();
			}
			// Destroy the shuriken.
			Destroy(transform.root.gameObject);
			
		}
	}
}
