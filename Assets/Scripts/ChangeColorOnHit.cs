using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour {

	//Hierarchyからカラーをセット
	[SerializeField] Color[] Colors;

	Renderer Renderer;	//色の指定用
	private int CurrentColorIdx;

	void Awake()
	{
		//何度も呼ぶAPIはキャッシュしておく
		Renderer = GetComponent<Renderer>();
		//耐久力を元に色を設定する
		this.CurrentColorIdx = FindObjectOfType<Destroyer>().initHp;
		//始めのカラーを表示
		ChangeMaterialColor();
	}

	//弾が接触したら呼び出されるメソッド
	void OnCollisionEnter(Collision collision)
	{
		//色を変更するメソッドの呼び出し
		ChangeMaterialColor();
	}

	//色を変更するメソッド。Sizeで指定した数が色の変わる順番と内容になる
	public void ChangeMaterialColor()
	{
		if(this.CurrentColorIdx == 0)
		{
			return;
		}
		//Indexを次に送る
		this.CurrentColorIdx --;
		//BOXの色をIndexの色に変更する
		Renderer.material.color = Colors[this.CurrentColorIdx];
		//色の指定数がIndexの最大値を超えたら0にする
	}
}