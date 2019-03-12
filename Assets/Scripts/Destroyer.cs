using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public int point;

	public int initHp;			//耐久力の最大値
	private int currentHp;		//耐久力の現在地

	public AudioClip hitSE;		//破壊されない場合のSE
	public AudioClip DestroySE;	//破壊された場合のSE

	public GameObject masterObj;

	// Use this for initialization
	void Start () {
		//Boxの耐久力を初期化します（現在地＝最大値にする）
		this.currentHp = initHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision) {

		//ボールが接触するたびに、耐久力を1ずつ減らします
		this.currentHp -= 1;

		//壊れる場合
		if(this.currentHp <= 0)
		{
			//破壊されるSEを再生
			AudioSource.PlayClipAtPoint(DestroySE, transform.position);

			//スコア処理を追加
			FindObjectOfType<Score>().AddPoint(point);
			masterObj.GetComponent<GameMaster>().boxNum--;
			Destroy(gameObject);

		}

		//まだ壊れない場合
		else{
			//ボールを跳ね返すSEを再生
			AudioSource.PlayClipAtPoint(hitSE, transform.position);
		}
	}
}