using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 4;
	public float wallBounce = 3;
	public float enemyBounce;

	private Vector3 _respawnPosition;
	private Rigidbody _rigidBody;
	private GameController _gameController;

	// Use this for initialization
	void Start () {
		_respawnPosition = transform.position;
		_rigidBody = GetComponent<Rigidbody> ();

		GameObject gc = GameObject.FindGameObjectWithTag ("GameController");
		_gameController = gc.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (Input.GetButton ("Horizontal")) {
			Vector3 translation = new Vector3 (Input.GetAxis("Horizontal") * speed, 0.0f);
			_rigidBody.AddForce(translation, ForceMode.Acceleration);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("EnemyBall")) 
		{
			EnemyBall ball = col.gameObject.GetComponent<EnemyBall>();
			if (ball != null) {
				resetVelocity (true, true);
				_rigidBody.AddForce (transform.up * enemyBounce);
				_gameController.destroyBall (ball);
				_gameController.increaseComboCounter ();
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("LeftWall"))
		{
			_rigidBody.AddForce (transform.right * wallBounce);
		}
		else if(col.gameObject.CompareTag("RightWall"))
		{
			_rigidBody.AddForce (transform.right * wallBounce * -1);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.CompareTag("Respawn"))
		{
			_respawnPosition.x = transform.position.x;
			transform.position = _respawnPosition;
			resetVelocity (false, true);
			_gameController.resetComboCounter ();
		}
	}

	void resetVelocity(bool resetX, bool resetY)
	{
		Vector3 currentVelocity = _rigidBody.velocity;
		if(resetY)
			currentVelocity.y = 0.0f;
		if (resetX)
			currentVelocity.x = 0.0f;
		
		_rigidBody.velocity = currentVelocity;
	}
}
