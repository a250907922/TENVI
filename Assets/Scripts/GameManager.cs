using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// EnemyPrefab設定GameObject
	public GameObject enemyPrefab;
	// ドロップするオブジェクトの位置指定
	private float DropPosY = -3.5f;
	public StageSelect stage;
	public int nStage;

	void Awake() {
		nStage = StageSelect.stageNum;
	}

	void Update () {
		if(Time.frameCount % 100 == 0){
			float tmpXpos = Random.Range(-8.0f, 8.0f);
			// EnemyObjectのInstantiate
			Instantiate(enemyPrefab, new Vector2(tmpXpos, DropPosY), Quaternion.identity);
		}
	}

	void StageClear() {
		stage.UnlockStage(nStage+1);
	}

	void GameOver() {
		Application.LoadLevel("Home");
	}
}
