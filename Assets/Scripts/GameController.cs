using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text comboText;

	private Vector3 screenSize;
	private BallSpawner spawner;
	private int comboCounter;

	// Use this for initialization
	void Start () {
		screenSize = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height));
		updateBorderObjectsPosition ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void updateBorderObjectsPosition()
	{
		//Don't know if top and bottom borders need to be moved... probably not
		//GameObject bottom = GameObject.Find ("/Borders/Bottom");
		//GameObject top = GameObject.Find ("/Borders/Top");
		GameObject left = GameObject.Find ("/Borders/Left");
		GameObject right = GameObject.Find ("/Borders/Right");

		Vector3 position = left.transform.position;
		position.x = -screenSize.x - left.transform.localScale.x / 2;
		left.transform.position = position;

		position = right.transform.position;
		position.x = screenSize.x + right.transform.localScale.x / 2;
		right.transform.position = position;
	}

	public void increaseComboCounter()
	{
		comboCounter++;
		refreshComboText ();
	}

	public void resetComboCounter()
	{
		comboCounter = 0;
		refreshComboText ();
	}

	private void refreshComboText()
	{
		comboText.text = (comboCounter >= 2) ? "x" + comboCounter + " Combo" : "";
		/*
		if (comboCounter >= 2) {
			comboText.text = "x" + comboCounter + " Combo";
		} else {
			comboText.text = "";
		}
		*/
	}

	public void destroyBall(EnemyBall ball)
	{
		ball.destroyBall ();
	}
}
