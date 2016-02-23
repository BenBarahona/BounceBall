using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 4;
	public Vector3 respawnPosition;
	public float leftLimit = -5;
	public float rightLimit = 5;
	public float bounceForce = 3;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		respawnPosition = transform.position;
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//keepBallInBorder ();	
	}

	void FixedUpdate()
	{
		if (Input.GetButton ("Horizontal")) {
			Vector3 translation = new Vector3 (Input.GetAxis("Horizontal") * speed, 0.0f);
			rigidBody.AddForce(translation);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Respawn"))
		{
			//rigidBody.AddForce (transform.up * 1000);
			respawnPosition.x = transform.position.x;
			transform.position = respawnPosition;

			Vector3 currentVelocity = rigidBody.velocity;
			currentVelocity.y = 0.0f;
			rigidBody.velocity = currentVelocity;
		}
		else if(col.gameObject.CompareTag("LeftWall"))
		{
			rigidBody.AddForce (transform.right * bounceForce);
		}
		else if(col.gameObject.CompareTag("RightWall"))
		{
			rigidBody.AddForce (transform.right * bounceForce * -1);
		}
	}

	void keepBallInBorder()
	{
		Vector3 newPosition = transform.position;
		//transform.position.x = Mathf.Max (transform.position.x,);
		if (transform.position.x < leftLimit)
			newPosition.x = leftLimit;
		else if (transform.position.x > rightLimit)
			newPosition.x = rightLimit;

		transform.position = newPosition;

	}
}
