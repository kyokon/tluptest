using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCamera : MonoBehaviour {
	public Vector3 SpeedForBall = new Vector3 (1.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start () {
		Vector3 Positions = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		BallMove ();
		BallRotate ();

	}


	void BallMove(){
		Vector3 Positions = transform.position;

		if (Input.GetKey (KeyCode.G)) {
			Positions.x += SpeedForBall.x;
		}
		if (Input.GetKey (KeyCode.B)) {
			Positions.x -= SpeedForBall.x;
		}
		if (Input.GetKey (KeyCode.T)) {
			Positions.y -= SpeedForBall.y;
		}
		if (Input.GetKey (KeyCode.Y)) {
			Positions.y += SpeedForBall.y;
		}
		if (Input.GetKey (KeyCode.I)) {
			Positions.z -= SpeedForBall.z;
		}
		if (Input.GetKey (KeyCode.K)) {
			Positions.z += SpeedForBall.z;
		}
		if(Input.GetKey (KeyCode.J)){
		this.transform.Translate( Vector3.forward );
		}
		transform.position = Positions;
	}

	void BallRotate(){
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (new Vector3 (0, -1, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (new Vector3 (0, 1, 0));
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Rotate (new Vector3 (-1, 0, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Rotate (new Vector3 (1, 0, 0));
		}
		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0, 0, -1));
		}
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (0, 0, 1));
		}
		if (Input.GetKey(KeyCode.M)){
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}
}
