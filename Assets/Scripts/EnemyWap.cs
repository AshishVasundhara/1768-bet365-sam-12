﻿using UnityEngine;
using System.Collections;

public class EnemyWap : MonoBehaviour {

	public GameObject shot;
	public Transform shotspawn;
	public float fireRate;
	public float delay;
	
	void Start()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire()
	{
		Instantiate(shot,shotspawn.position,shotspawn.rotation);
	}
}
