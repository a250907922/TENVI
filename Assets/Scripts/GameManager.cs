using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// ドロップ用のPrefab設定GameObject
	public GameObject targetPrefab;
	// ScoreのObject格納用
	private GameObject ScoreObj;
	// ドロップするオブジェクトの位置指定
	private float DropPosY = 8.0f;
	
	void Start () {
		// Scoreオブジェクトの取得
		ScoreObj = GameObject.Find("Score");
	}
	
	void Update () {
		if(Time.frameCount % 100 == 0){
			float tmpXpos = Random.Range(-8.0f, 8.0f);
			// ドロップ用ObjectのInstantiate
			Instantiate(targetPrefab,new Vector2(tmpXpos, DropPosY), Quaternion.identity);
		}
	}

	void GetScore(int GetPoint){
		// Scoreオブジェクトへのメッセージ送信処理
		ScoreObj.SendMessage("UpdateScore",GetPoint);
	}
}
