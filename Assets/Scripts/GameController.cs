using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private Vector3 screenSize;
	private BallSpawner spawner;

	// Use this for initialization
	void Start () {
		screenSize = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height));
		spawner = GetComponent<BallSpawner> ();

		if (spawner != null) {
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
