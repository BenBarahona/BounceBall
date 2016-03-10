using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	public float spawnRate; //Seconds between spawns
	public int maxBalls;
	public GameObject ballPrefab;
	public float maxY = 3.0f;
	public float minY = -5.0f;

	[HideInInspector]
    public float[] horizontalPositions = new float[2];
	public int ballCount;
	

	float lastSpawnTime;
	float timer;
	Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		timer = Time.time;
		ballCount = 0;
		Vector3 screenSize = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height));

		horizontalPositions[0] = -screenSize.x - 1.0f;
		horizontalPositions [1] = screenSize.x + 1.0f;
	}
	
	// Update is called once per frame
	void LateUpdate () {

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

	public void destroyBall()
	{
		ballCount--;
	}
}
