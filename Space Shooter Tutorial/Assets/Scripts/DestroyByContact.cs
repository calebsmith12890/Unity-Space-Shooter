﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	private GameController gameController;

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary") { return; }
		
		if (other.tag == "Player") 
		{ 
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (other.gameObject);
		Destroy (gameObject);

		gameController.AddScore (scoreValue);
	}

}
