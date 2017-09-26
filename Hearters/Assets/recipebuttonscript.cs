using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class recipebuttonscript : MonoBehaviour {
	//ボタン等UI関連
	public GameObject button_recipeopen,button_page,button_material;//ボタン
	public GameObject background_recipe,recipe_image;
	public GameObject text_name,text_red,text_blue,text_green,text_total;//text for readings
	public Text text_nameToread,text_redToread,text_blueToread,text_greenToread,text_totalToread;
	public Text text_pagenumber;
	public int recipe_working;//レシピ開1 閉0
	private Button Button_recipeopen, Button_page, Button_material; 

	//情報保持用変数
	int red_kakera, blue_kakera, yellow_kakera;
	int Read_red_kakera, Read_blue_kakera, Read_yellow_kakera;

	//レシピの情報を格納しているテキストファイル名
	string textreader = "Recipetree";

	//レシピの情報を格納するための読み込み変数等
	TextAsset textfiles;
	string stext;
	StringReader reader;

	public string[] scenarios;
	string Pageallowflag;

	int currentPage;
	int PagenumberForrecipe;

	//書き込みのためのテキストファイル等
	string textForwriting;

	// Use this for initialization
	void Start () {
		recipe_working = 0;

		Button_recipeopen = button_recipeopen.GetComponent<Button> ();
		Button_page = button_page.GetComponent<Button> ();
		Button_material = button_material.GetComponent<Button> ();

		Button_recipeopen.gameObject.SetActive (true);
		Button_page.gameObject.SetActive (false);
		Button_material.gameObject.SetActive (false);
		textreader = "Recipetree";

		currentPage = 1;
		Pageallowflag = "0";
		PagenumberForrecipe = 1;

	}
	
	// Update is called once per frame
	void Update () {
		recipe (recipe_working);
		RecipeShowTotext ();
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
	public void set_recipe_Buttonworking(){//チュートリアル、その他イベント用　ボタンはアクティブだがレシピ自体ははたらかない
		Button_recipeopen.gameObject.SetActive (true);
		recipe_working = 0;
	}
	//レシピを開いたら
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

			text_name.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_red.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_blue.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_green.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_total.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_nameToread.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_redToread.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_blueToread.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_greenToread.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_totalToread.GetComponent<CanvasRenderer> ().SetAlpha (1);
			text_pagenumber.GetComponent<CanvasRenderer> ().SetAlpha (1);

			recipe_image.GetComponent<CanvasRenderer> ().SetAlpha (0.5f);


			background_recipe.GetComponent<CanvasRenderer> ().SetAlpha (1);
		} else {
			Button_page.gameObject.SetActive (false);
			Button_material.gameObject.SetActive (false);

			text_name.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_red.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_blue.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_green.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_total.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_nameToread.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_redToread.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_blueToread.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_greenToread.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_totalToread.GetComponent<CanvasRenderer> ().SetAlpha (0);
			text_pagenumber.GetComponent<CanvasRenderer> ().SetAlpha (0);

			recipe_image.GetComponent<CanvasRenderer> ().SetAlpha (0);

			background_recipe.GetComponent<CanvasRenderer> ().SetAlpha (0);

			//RecipeWritings ();
		}
	}

	//名前,赤,青,緑,トータル,赤必要数,青必要数,緑必要数,トータル必要数,フラグ,
	public void RecipeReadings(){
		textfiles = Resources.Load(textreader) as TextAsset;
		stext = textfiles.text;
		reader = new StringReader(stext);

		for (int i = 0; i < 80; i++) {
			scenarios = stext.Split (',');
		}
		for (int j = 0; j < 80; j++) {
			Debug.Log (scenarios [j]);
		}
		currentPage = 1;
	}
	//レシピのテキストファイルへの書き込み
	public void RecipeWritings(){
		StreamWriter textfileWrite = new StreamWriter ("Recipetree", false);
		textForwriting = string.Join (",", scenarios);
		Debug.Log (textForwriting);
		textfileWrite.WriteLine (textForwriting);
		textfileWrite.Flush ();
		textfileWrite.Close ();
	}

	public void RecipeShowTotext(){
		if (recipe_working == 1) {
			Pageallowflag = scenarios [currentPage * 9];//ページがアクティブかどうかフラグをチェック
			text_pagenumber.GetComponent<Text>().text = (currentPage+"ぺーじ");//ページ番号表示
			//以下フラグが1のとき、各テキストにそれぞれの個数と必要個数を書きこみ
			if (Pageallowflag == "1") {
				text_nameToread.GetComponent<Text>().text = (scenarios [currentPage * 0]);
				text_redToread.GetComponent<Text>().text = (scenarios [currentPage * 1]+"こ / "+scenarios [currentPage * 5]+"こひつよう");
				text_blueToread.GetComponent<Text>().text = (scenarios [currentPage * 2]+"こ / "+scenarios [currentPage * 6]+"こひつよう");
				text_greenToread.GetComponent<Text>().text = (scenarios [currentPage * 3]+"こ / "+scenarios [currentPage * 7]+"こひつよう");
				text_totalToread.GetComponent<Text>().text = (scenarios [currentPage * 4]+"こ / "+scenarios [currentPage * 8]+"こひつよう");
			}else if(Pageallowflag == "0"){
				text_nameToread.GetComponent<Text>().text = "???";
				text_redToread.GetComponent<Text>().text = "???";
				text_blueToread.GetComponent<Text>().text = "???";
				text_greenToread.GetComponent<Text>().text = "???";
				text_totalToread.GetComponent<Text>().text = "???";
			}
		}
	}

	public void nextPage(){
		if (currentPage < 8) {
			currentPage++;
		}
	}
	public void beforePage(){
		if (currentPage > 1) {
			currentPage--;
		}
	}
	public int getCurrentPage(){
		return currentPage;
	}

	public void ShokikatextToRecipe(){//レシピ完全初期化 [12349]のみ
		RecipeReadings();
		for (int i = 0; i < 80; i++) {
			if ((i % 10 == 1) || (i % 10 == 2)|| (i % 10 == 3)|| (i % 10 == 4)|| (i % 10 == 9)) {
				scenarios [i] = "0";
			}
		}
		StreamWriter textfileWrite = new StreamWriter ("Recipetree", false);
		textForwriting = string.Join (",", scenarios);
		Debug.Log (textForwriting);
		textfileWrite.WriteLine (textForwriting);
		textfileWrite.Flush ();
		textfileWrite.Close ();
	}
	public void SettextToRecipe(int recipenumberFS){//レシピ一部のみ初期化　レシピは持っているが楽譜を作った時にかけらのみリセット
		RecipeReadings();
		for (int i = 0; i < 80; i++) {
			if ((i % 10 == 1) || (i % 10 == 2)|| (i % 10 == 3)|| (i % 10 == 4)){
				scenarios [i] = "0";
			}
		}
		StreamWriter textfileWrite = new StreamWriter ("Recipetree", false);
		textForwriting = string.Join (",", scenarios);
		Debug.Log (textForwriting);
		textfileWrite.WriteLine (textForwriting);
		textfileWrite.Flush ();
		textfileWrite.Close ();
		//ここで楽譜のフラグをたてる、楽譜を1枚増やす関数を後で入れる
	}

	public void SetRecipeToActive(int recipenumberFA){//レシピゲット時　そのレシピをActiveにする
		PagenumberForrecipe = recipenumberFA;
		RecipeReadings();
		scenarios [PagenumberForrecipe*9] = "1";
		RecipeWritings ();
	}

	public void SetKakeraToRecipe(int kakera){//かけらゲット時　そのレシピをActiveにする（１～３）
		//1は赤　2が青　3が緑
		RecipeReadings();
		string kakerasce, kakeratotal;
		int kakerasuu, kakerasuutotal;
		for (int i = 0; i < 80; i++) {
			if ((i % 10 == kakera)){//特定の色のかけらに1をたす
				kakerasce = scenarios [i];
				kakerasuu = int.Parse ("kakerasce");
				kakerasuu += 1;
				scenarios [i] = kakerasuu.ToString();
			}
			if (i % 10 == 4) {
				kakeratotal = scenarios [i];
				kakerasuutotal = int.Parse ("kakeratotal");
				kakerasuutotal += 1;
				scenarios [i] = kakerasuutotal.ToString();//かけらの合計数に1をたす
			}
		}
		RecipeWritings ();
	}

	public void SetMinusKakeraToRecipe(int kakera){//かけら交換時　そのかけらをレシピからへらす（１～３）
		//1は赤　2が青　3が緑
		RecipeReadings();
		string kakerasce, kakeratotal;
		int kakerasuu, kakerasuutotal;
		int flagminus = 0;
		for (int i = 0; i < 80; i++) {
			if ((i % 10 == kakera)){//特定の色のかけらの数を1をへらす
				kakerasce = scenarios [i];
				kakerasuu = int.Parse ("kakerasce");
				if (kakerasuu > 1) {
					kakerasuu -= 1;
					flagminus = 1;
				}
				scenarios [i] = kakerasuu.ToString();
			}
			if (i % 10 == 4) {
				kakeratotal = scenarios [i];
				kakerasuutotal = int.Parse ("kakeratotal");
				if (kakerasuutotal > 1 && flagminus == 1) {
					kakerasuutotal -= 1;
				}
				scenarios [i] = kakerasuutotal.ToString();//かけらの合計数から1をへらす
			}
		}
		RecipeWritings ();
	}


}
