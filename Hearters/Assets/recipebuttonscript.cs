using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class recipebuttonscript : MonoBehaviour {
	public GameObject button_recipeopen,button_page,button_material;//ボタン
	public GameObject background_recipe,text_recipe,text_page,recipe_image;
	public int recipe_working;//レシピ開1 閉0

	private Button Button_recipeopen, Button_page, Button_material; 

	// Use this for initialization
	void Start () {
		recipe_working = 0;

		Button_recipeopen = button_recipeopen.GetComponent<Button> ();
		Button_page = button_page.GetComponent<Button> ();
		Button_material = button_material.GetComponent<Button> ();

		Button_recipeopen.gameObject.SetActive (true);
		Button_page.gameObject.SetActive (false);
		Button_material.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		recipe (recipe_working);
	}

	public int get_recipe_working(){
		return recipe_working;
	}

	public void set_recipe_working(){
		recipe_working = 1;
	}

	public void set_recipe_NotButtonworking(){//チュートリアル、その他イベント用
		Button_recipeopen.gameObject.SetActive (false);
		recipe_working = 0;
	}
	public void set_recipe_Buttonworking(){//チュートリアル、その他イベント用
		Button_recipeopen.gameObject.SetActive (true);
		recipe_working = 0;
	}

	public void Button_recipeOpenClick(){
		if (recipe_working == 0) {
			recipe_working = 1;
		} else {
			recipe_working = 0;
		}
	}

	void recipe(int recipe_flag){
		
		if (recipe_flag == 1) {
			Button_page.gameObject.SetActive (true);
			Button_material.gameObject.SetActive (true);

			background_recipe.GetComponent<CanvasRenderer> ().SetAlpha (1);
		} else {
			Button_page.gameObject.SetActive (false);
			Button_material.gameObject.SetActive (false);

			background_recipe.GetComponent<CanvasRenderer> ().SetAlpha (0);
		}
	}


}
