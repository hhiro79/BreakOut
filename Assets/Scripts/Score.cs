using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// スコアを表示するUIの取得用
	public Text scoreText;
	// ハイスコアを表示するUIの取得用
	public Text highScoreText;

	// スコアのカウント用
	private int score;

	//ハイスコアのカウント用
	private int highScore;

	// PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {

		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		// スコアがハイスコアより大きくなれば、ハイスコアを更新する
		if (highScore < score) {
			highScore = score;
		}

		//現在のスコアとハイスコアを画面に表示する
		scoreText.text = score.ToString ();
		highScoreText.text = highScore.ToString ();
	}

	// ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		// スコアを0に戻す
		score = 0;

		//ハイスコアを取得する。保存されていなければ0を取得する
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	//ポイントの追加。修飾子をpublicにしているので外部より参照できるメソッドになっている
	public void AddPoint (int point)	//外部より受け取ったint型の引数をpointとして受け取る
	{
		score = score + point;
	}

	//ハイスコアの保存
	public void Save()
	{
		//ハイスコアを保存する
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

		//ゲーム開始前の状態に戻す
		Initialize ();
	}
}
