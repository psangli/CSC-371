﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y );
		
		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
		
		if(transform.position.x < min.x){
			transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
		}
	}
}
