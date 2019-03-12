using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlags : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LevelManager.isStart = false;	//isStartのフラグをfalseにする。public staticなので、どこからでも参照して変更できる
	}
}
