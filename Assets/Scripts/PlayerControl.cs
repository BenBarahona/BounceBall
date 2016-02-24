using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 6;
	public Vector3 respawnPosition;
	public float leftLimit = -5;
	public float rightLimit = 5;
	public float wallBounce = 3;
	public float enemyBounce = 300;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		respawnPosition = transform.position;
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate()
	{
		if (Input.GetButton ("Horizontal")) {
			Vector3 translation = new Vector3 (Input.GetAxis("Horizontal") * speed, 0.0f);
			rigidBody.AddForce(translation, ForceMode.Acceleration);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("EnemyBall")) 
		{
			EnemyBalls ball = col.gameObject.GetComponent<EnemyBalls>();
			if (ball != null) {
				resetVelocity (true, true);
				rigidBody.AddForce (transform.up * enemyBounce);
				ball.destroyBall ();
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("LeftWall"))
		{
			rigidBody.AddForce (transform.right * wallBounce);
		}
		else if(col.gameObject.CompareTag("RightWall"))
		{
			rigidBody.AddForce (transform.right * wallBounce * -1);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.CompareTag("Respawn"))
		{
			respawnPosition.x = transform.position.x;
			transform.position = respawnPosition;
			resetVelocity (false, true);
		}
	}

	void resetVelocity(bool resetX, bool resetY)
	{
		Vector3 currentVelocity = rigidBody.velocity;
		if(resetY)
			currentVelocity.y = 0.0f;
		if (resetX)
			currentVelocity.x = 0.0f;
		
		rigidBody.velocity = currentVelocity;
	}
}
