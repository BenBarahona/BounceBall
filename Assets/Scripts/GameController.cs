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
			//Reasign spawner limits	
		}

		updateBorderObjectsPosition ();
		Debug.Log (screenSize);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void updateBorderObjectsPosition()
	{
		//Don't know if top and bottom borders need to be moved... probably not
		GameObject bottom = GameObject.Find ("/Borders/Bottom");
		GameObject top = GameObject.Find ("/Borders/Top");
		GameObject left = GameObject.Find ("/Borders/Left");
		GameObject right = GameObject.Find ("/Borders/Right");

		Vector3 position = left.transform.position;
		position.x = -screenSize.x;
		left.transform.position = position;

		position = right.transform.position;
		position.x = screenSize.x;
		right.transform.position = position;
	}
}
