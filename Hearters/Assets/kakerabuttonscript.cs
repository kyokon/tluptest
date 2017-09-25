using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class kakerabuttonscript : MonoBehaviour {
	public GameObject button_stroke,button_present,button_hit,button_cry;
	public int button_working;
	public GameObject gameobj_target;
	Animator animator;
	public int count_stroke, count_present, count_hit, count_cry, count_total;	
	private Button Button_stroke, Button_present, Button_hit, Button_cry; 



	// Use this for initialization
	void Start () {
		Button_stroke = button_stroke.GetComponent<Button> ();
		Button_present = button_present.GetComponent<Button> ();
		Button_hit = button_hit.GetComponent<Button> ();
		Button_cry = button_cry.GetComponent<Button> ();

		Button_stroke.gameObject.SetActive (false);
		Button_present.gameObject.SetActive (false);
		Button_hit.gameObject.SetActive (false);
		Button_cry.gameObject.SetActive (false);

		button_working = 0;

		gameobj_target = null;
		count_stroke = 0;
		count_present = 0;
		count_hit = 0;
		count_cry = 0;
		count_total = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void button_appear(GameObject target){
		Button_stroke.gameObject.SetActive (true);
		Button_present.gameObject.SetActive (true);
		Button_hit.gameObject.SetActive (true);
		Button_cry.gameObject.SetActive (true);

		button_working = 1;
		gameobj_target = target;
		animator = gameobj_target.GetComponent<Animator> ();

		count_stroke = 0;
		count_present = 0;
		count_hit = 0;
		count_cry = 0;
		count_total = 0;
	}

	public void button_disappear(){
		Button_stroke.gameObject.SetActive (false);
		Button_present.gameObject.SetActive (false);
		Button_hit.gameObject.SetActive (false);
		Button_cry.gameObject.SetActive (false);

		button_working = 0;
		gameobj_target = null;
	}

	public void button_Stroke_Click(){
		Debug.Log("animation_happy"+gameobj_target);
		animator.Play ("happy");
		count_stroke++;
	}
	public int Getbutton_Stroke_Click(){
		return count_stroke;
	}
	public void button_Present_Click(){
		animator.Play ("happy");
		count_present++;
	}
	public int Getbutton_Present_Click(){
		return count_present;
	}
	public void button_Hit_Click(){
		//animator.Play ("");
		count_hit++;
	}
	public int Getbutton_Hit_Click(){
		return count_hit;
	}
	public void button_Cry_Click(){
		//animator.Play ("");
		count_cry++;
	}
	public int Getbutton_Cry_Click(){
		return count_cry;
	}

}
