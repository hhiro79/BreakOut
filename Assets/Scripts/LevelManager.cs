using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//レベルを表示するUIの取得用
	[SerializeField] Text levelText;	//インスペクタで指定可能
	[SerializeField] StartShot startShot;

	//レベルのカウント用
	public static int level;		//シーンをまたいでも引き継ぐようにpublicかつstaticにする

	//ゲーム開始かどうかを判断するフラグ
	public static bool isStart;		//trueならゲーム途中と判断する

	// Use this for initialization
	void Start ()
	{
		if(!isStart)		//isStartのフラグを確認し、Falseであれば実行される「!isStart」は「isStart == False」と同義。
		{
			//レベルを0にする
			level = 0;
			//ゲームがスタートしたフラグを立てる
			isStart = true;
		}
		levelText.text = level.ToString();
	}

	public void LevelUp()	//外部(GameMaster.cs)より呼ばれるメソッド
	{
		startShot.BallDestroy();
		level++;							//levelを加算する
		StartCoroutine("NextLevel");		//コルーチンの呼び出し
	}

	IEnumerator NextLevel()			//コルーチン
	{
		Debug.Log("Please press key");
		//while(!Input.GetKey("space")) yield return null;	//スペースキーの入力待ち
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("MainScene");						//スペースキーが押されたらMainシーンを呼び出す
		Debug.Log("Done!");
	}
}
