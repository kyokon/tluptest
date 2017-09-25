using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCamera1 : MonoBehaviour {
	public Vector3 SpeedForBall = new Vector3 (1.0f, 1.0f, 1.0f);
	public float speed = 1;
	public Vector3 Positions;
	public int flag_PermitMoving;//動いていいか許可する0だめ1おけ
	public Vector3 beforePosition;
	public float FirstPositionx;
	public GameObject cameraobjct;

	public Terrain Terrain1wood;

	//Ray ray = new Ray(transform.position, transform.forward);
	RaycastHit hit_forward, hit_right, hit_left, hit_back, hit_down;
	bool flag_hit_forward, flag_hit_right, flag_hit_left, flag_hit_back, flag_hit_down, flag_hit_up, flag_hit_totalup;
	float ballsheight, ballTotalhight;
	public int layermask;


	// Use this for initialization
	void Start () {
		FirstPositionx = transform.position.x;
		flag_PermitMoving = 0;
		flag_hit_forward = false;
		flag_hit_right = false;
		flag_hit_left = false;
		flag_hit_back = false;
		flag_hit_down = false;
		flag_hit_up = false;
		layermask = 1 << 8;
	}
	
	// Update is called once per frame
	void Update () {
		BallMove ();
	}

	void RayHitALL(){
		if (Physics.Raycast (transform.position, Vector3.forward, out hit_forward,3)) {
			flag_hit_forward = true;
			Debug.Log("forwardTrue");
		} else {
			flag_hit_forward = false;
		}
		if (Physics.Raycast (transform.position, Vector3.right, out hit_right,3)) {
			flag_hit_right = true;
			Debug.Log("RightTrue");
		} else {
			flag_hit_right = false;
		}
		if (Physics.Raycast (transform.position, Vector3.left, out hit_left,3)) {
			flag_hit_left = true;
			Debug.Log("LeftTrue");
		} else {
			flag_hit_left = false;
		}
		if (Physics.Raycast (transform.position, Vector3.back, out hit_back,3)) {
			flag_hit_back = true;
			Debug.Log("BackTrue");
		} else {
			flag_hit_back = false;
		}
		if (Physics.Raycast (transform.position, Vector3.down, out hit_down,3)) {
			flag_hit_down = true;
			Debug.Log("DownTrue");
		} else {
			flag_hit_down = false;
		}
		if (Physics.Raycast (transform.position, Vector3.down, out hit_down)) {
			ballsheight = hit_down.distance;
			//Debug.Log("ballsheight"+ballsheight);
			if (ballsheight > 20.0f) {
				flag_hit_up = true;
				Debug.Log("UpTrue");
			} else {
				flag_hit_up = false;
			}
		}
		if (Physics.Raycast (transform.position, Vector3.down, out hit_down, Mathf.Infinity, layermask)) {
			ballTotalhight = hit_down.distance;
			Debug.Log("ballTheight"+ballTotalhight);
			if (ballTotalhight > 70.0f) {
				flag_hit_totalup = true;
				Debug.Log("TUpTrue");
			} else {
				flag_hit_totalup = false;
			}
			Debug.Log("flag_hit_totalup"+flag_hit_totalup);
		}
	}


	void BallMove(){
		RayHitALL();
		if (flag_PermitMoving == 1) {
			Positions = transform.position;

			beforePosition = Positions;

			if ((Input.GetKey (KeyCode.UpArrow))&& flag_hit_forward != true && flag_hit_totalup != true) {
				Positions += transform.TransformDirection (Vector3.forward) * speed;
			}
			if ((Input.GetKey (KeyCode.DownArrow))&& flag_hit_back != true && flag_hit_totalup != true) {
				Positions += transform.TransformDirection (Vector3.back) * speed;
			}
			if ((Input.GetKey (KeyCode.RightArrow))&& flag_hit_right != true && flag_hit_totalup != true) {
				Positions += transform.TransformDirection (Vector3.right) * speed;
			}
			if ((Input.GetKey (KeyCode.LeftArrow))&& flag_hit_left != true && flag_hit_totalup != true) {
				Positions += transform.TransformDirection (Vector3.left) * speed;
			}
			if ((Input.GetKey (KeyCode.E))&& flag_hit_up != true && flag_hit_totalup != true) {
				Positions += transform.TransformDirection (Vector3.up) * speed;
			}
			if ((Input.GetKey(KeyCode.X))&& flag_hit_down != true) {
				Positions += transform.TransformDirection (Vector3.down) * speed;
			}

			if (Input.GetKey (KeyCode.A)) {
				cameraobjct.transform.Rotate (new Vector3 (0, -1, 0));
			}
			if (Input.GetKey (KeyCode.D)) {
				cameraobjct.transform.Rotate (new Vector3 (0, 1, 0));
			}
			if (Input.GetKey (KeyCode.W)) {
				cameraobjct.transform.Rotate (new Vector3 (-1, 0, 0));
			}
			if (Input.GetKey (KeyCode.S)) {
				cameraobjct.transform.Rotate (new Vector3 (1, 0, 0));
			}
			if (Positions.y <= 0) {
				Positions.y = 0;
			}

			/*if ((this.transform.eulerAngles.x >= 28)&&(this.transform.eulerAngles.x <= 180)) {
				float yeuler = this.transform.eulerAngles.y;
				float zeuler = this.transform.eulerAngles.z;
				this.transform.rotation = Quaternion.Euler (28.0f, yeuler, zeuler);
			}else if ((Mathf.RoundToInt(this.transform.eulerAngles.x) >= 180)&&(Mathf.RoundToInt(this.transform.eulerAngles.x) <= 332)){
				float yeuler = this.transform.eulerAngles.y;
				float zeuler = this.transform.eulerAngles.z;
				this.transform.rotation = Quaternion.Euler (332.0f, yeuler, zeuler);
			}*/

			transform.position = Positions;
		}

	}
	//現在の位置情報を得る
	public Vector3 get_ballPosition(){
		return Positions;
	}
	//動かしていいか
	public void set_flag_PermitMoving(int flag){
		flag_PermitMoving = flag;
	}

	//ぶつかったもののゲームオブジェクトを判定
	void OnCollisionEnter(Collision collision){
		//set_flag_PermitMoving (0);
		//Positions = beforePosition;
		//Positions +=transform.TransformDirection (Vector3.forward) * 0;
		//Destroy (collision.gameObject);
		//set_flag_PermitMoving (1);
		Debug.Log ("Collision");
	}


}
