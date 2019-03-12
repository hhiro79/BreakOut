using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public int boxNum;
	public float nowTime;
	public Text resultMessageText;	//	クリアした際に「クリア」と表示するテキスト
	private bool isClear;

	// Use this for initialization
	void Start () {
		nowTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		nowTime += Time.deltaTime;
		if(!isClear){
			if(boxNum <= 0) {
				StageClear(nowTime.ToString("F0") + "秒でクリアできた！");	//秒数をstring型にキャストして引数へ。<=ここの呼び出すメソッドを変更する
				isClear = true;
			}
		}
	}

	void StageClear(string resultMessage)
	{
		//DataSender.resultMessage = resultMessage;	//受け取った引数を変数に格納する
		resultMessageText.text = resultMessage;	//画面にクリア状態を表示する
		FindObjectOfType<LevelManager>().LevelUp();
		Debug.Log("Clear!");
	}

	public void GameOver(string resultMessage) {	//引数を持たせた
			DataSender.resultMessage = resultMessage;	//受け取った引数をstatic変数へ格納
			SceneManager.LoadScene("ResultScene");
	}
}
