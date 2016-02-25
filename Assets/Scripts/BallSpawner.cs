﻿using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	public float spawnRate; //Seconds between spawns
	public int maxBalls;
	public GameObject ballPrefab;
	public float maxY = 3.0f;
	public float minY = -5.0f;
    public float[] horizontalPositions = new float[2];
	[HideInInspector]
	public int ballCount;
	

	float lastSpawnTime;
	float timer;
	Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		timer = Time.time;
		ballCount = 0;
		//horizontalPositions [0] = -4.5f;
		//horizontalPositions [1] = 4.5f;
        horizontalPositions[0] = -11.5f;
        horizontalPositions [1] = 11.5f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - timer >= spawnRate && ballCount <= maxBalls)
		{
			timer = Time.time;
			float randomY = Random.Range (minY, maxY);
			int randomSide = Random.Range(0, horizontalPositions.Length);
			spawnPosition = new Vector3 (horizontalPositions[randomSide], randomY);
			spawnPosition.y = randomY;
			Instantiate (ballPrefab, spawnPosition, Quaternion.identity);
			ballCount++;
		}
	}
}
