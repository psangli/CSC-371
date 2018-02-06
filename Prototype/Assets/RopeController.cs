﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

	private HingeJoint2D hj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Rope") && Input.GetButtonDown("Fire1"))
		{
			other.gameObject.SetActive (false);
			//this.gameObject.SetActive (false);
			hj = other.GetComponent<HingeJoint2D> ();

		}
	}
}