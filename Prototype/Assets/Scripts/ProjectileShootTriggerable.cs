﻿using UnityEngine;
using System.Collections;

public class ProjectileShootTriggerable : MonoBehaviour {

	[HideInInspector] public Rigidbody2D projectile;                          // Rigidbody variable to hold a reference to our projectile prefab
	public Transform bulletSpawn;                           // Transform variable to hold the location where we will spawn our projectile
	[HideInInspector] public float projectileForce = 500f;                  // Float variable to hold the amount of force which we will apply to launch our projectiles

	public void Launch()
	{
		//Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedBullet
		Rigidbody2D clonedBullet = Instantiate(projectile, bulletSpawn.position, transform.rotation) as Rigidbody2D;

		//Add force to the instantiated bullet, pushing it forward away from the bulletSpawn location, using projectile force for how hard to push it away
		clonedBullet.AddForce(bulletSpawn.transform.right * projectileForce);
	}
}