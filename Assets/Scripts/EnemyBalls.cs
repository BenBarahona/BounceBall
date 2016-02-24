using UnityEngine;
using System.Collections;

public class EnemyBalls : MonoBehaviour {

	public float speed = 3f;
	public Color color;

	private Vector3 _direction;
	private MeshRenderer _meshRenderer;
	private Collider _collider;
	private BallSpawner _spawner;

	// Use this for initialization
	void Start () {
		_meshRenderer = GetComponent<MeshRenderer> ();
		_collider = GetComponent<Collider> ();

		GameObject spawnerObj = GameObject.Find ("/Ball Spawn");
		_spawner = spawnerObj.GetComponent<BallSpawner> ();
		_direction = transform.position.x > 0 ? Vector3.left : Vector3.right;

		int layer = LayerMask.NameToLayer ("NPC Ignore Collision");
		Physics.IgnoreLayerCollision (layer, layer);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (_direction * Time.deltaTime * speed);

		if (transform.position.x < _spawner.horizontalPositions [0] || transform.position.x > _spawner.horizontalPositions [1]) {
			destroyBall ();
		}
	}

	void OnTriggerExit(Collider col)
	{
		Debug.Log ("Exit: " + col.gameObject);
		if((_direction.Equals(Vector3.left) && col.gameObject.CompareTag("Wall")) 
			|| (_direction.Equals(Vector3.right) && col.gameObject.CompareTag("RightWall")) )
		{
			destroyBall ();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		
	}

	public void destroyBall()
	{
		Destroy (gameObject);
		_spawner.ballCount--;
	}
}
