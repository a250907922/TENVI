using UnityEngine;
using System.Collections;

public class Lesson2Score : MonoBehaviour {
	// 獲得ptの格納
	private int nowScore = 0;
	
	void Update () {
		// スコアの表示処理
		this.guiText.text =  " SCORE:" + nowScore;
	}

	public void UpdateScore(int getScore){
		// スコアの加算処理
		nowScore += getScore;
	}
}
