using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parameteranimal : MonoBehaviour {
	//必要なパラメーターS：　動物が持つ玉の色　なんの動きを何回したらいいか？　プレゼントの場合ほしいたまの色と数 動きにあわせたアニメーション
	public int animalnumber;
	public int s_kakera;//動物が持つ玉の色
	public int s_move;//してほしい動き
	public int s_times;//動きをしてほしい回数
	public int sflag_haveKakera;//かけらをもっているか？
	public int s_wantKakeraColor;//ほしいかけら　プレゼントの場合に使用　ない場合は"black"
	public int s_wantKakera;//ほしいかけらの数　プレゼントの場合に使用　ない場合は"0"
	public int s_wantParameter;//ほしい動きをしてもらえたときのパラメーター下降値
	public int s_NotwantParameter;//ほしい動きをしてもらえなかったときのパラメーター上昇値
	public int s_HP;//動物が持つHP これがなくなるとかけらがもらえる
	public float s_x;//動物が持つ位置x
	public float s_y;//動物が持つ位置y
	public float s_z;//動物が持つ位置z
	Vector3 Nballposition;
	public GameObject balls1,GameobjEmpty;

	RaycastHit hit_forward;

	public int flag_near;//動物がボールを感知したかどうか

	// Use this for initialization
	void Start () {
		s_x = this.transform.position.x;
		s_y = this.transform.position.y;
		s_z = this.transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {

		nearball ();
	}

	public int nearball(){
		Nballposition = balls1.GetComponent<ballCamera1> ().get_ballPosition();

		if ((s_x + 4) > Nballposition.x && (s_x - 4) < Nballposition.x && (s_z - 4) < Nballposition.z && (s_z + 4) > Nballposition.z) {
			Debug.Log ("Hit" + animalnumber);
			GameobjEmpty.GetComponent<kakerabuttonscript> ().Set_collision_number(animalnumber);
			return animalnumber;
		} else {
			GameobjEmpty.GetComponent<kakerabuttonscript> ().Set_collision_number(0);
			return 0;
		}
	}

	public int getter_animalnumber(){
		return animalnumber;
	}
	public int getter_s_Kakera(){
		return s_kakera;
	}
	public int getter_s_move(){
		return s_move;
	}
	public int getter_s_times(){
		return s_times;
	}
	public int getter_sflag_haveKakera(){
		return sflag_haveKakera;
	}
	public int getter_s_wantKakeraColor(){
		return s_wantKakeraColor;
	}
	public int getter_s_wantKakera(){
		return s_wantKakera;
	}
	public int getter_s_wantParameter(){
		return s_wantParameter;
	}
	public int getter_s_NotwantParameter(){
		return s_NotwantParameter;
	}
	public int getter_s_HP(){
		return s_HP;
	}


}
