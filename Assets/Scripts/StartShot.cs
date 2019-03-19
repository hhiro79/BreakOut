using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShot : MonoBehaviour {

	public float addSpeed;	//加算される係数を設定する

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);
		gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (500 + (LevelManager.level * addSpeed)));	//修正
		
	}

	public void BallDestroy()
	{
		this.gameObject.SetActive(false);
	}
}
