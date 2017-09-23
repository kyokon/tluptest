using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Sentaku : MonoBehaviour {
	public AudioClip SEstart;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().PlayOneShot (SEstart);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SceneLoad1(){
		SceneManager.LoadScene ("start");
	}
	public void SceneLoad2(){
	}		
	public void SceneLoad3(){
	}
	public void SceneLoad4(){
	}
	public void SceneLoad5(){
	}
	public void SceneLoad6(){
	}	
	public void SceneLoad7(){
	}
	public void SceneLoad8(){
	}	
	public void SceneLoad9(){
	}
	public void SceneLoad10(){
		SceneManager.LoadScene ("starters");
	}
}