using UnityEngine;
using System.Collections;

public class EnemyBalls : MonoBehaviour {

	public float speed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * speed);
	}
}
