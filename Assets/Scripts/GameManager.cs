using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	// EnemyPrefab設定GameObject
	public GameObject enemyPrefab;
	// ドロップするオブジェクトの位置指定
	private float DropPosY = -3.5f;
	public StageSelect stage;
	public int nStage;
	public static bool challengeMode;
	public static int enemyDeadCount = 0;
	public Text stageClearText;
	public Text gameOverText;


	void Awake() {
		nStage = StageSelect.stageNum;
		stageClearText.gameObject.SetActive(false);
		gameOverText.gameObject.SetActive(false);
	}

	void Update () {
		if(!IsGameOver()){
			if(Time.frameCount % 100 == 0){
				float tmpXpos = Random.Range(-8.0f, 8.0f);
				// EnemyObjectのInstantiate
				Instantiate(enemyPrefab, new Vector2(tmpXpos, DropPosY), Quaternion.identity);
			}
		}

		for (int i = 0; i < Input.touchCount; i++) {
			// タッチ情報を取得する
			Touch touch = Input.GetTouch (i);

			// ゲーム中ではなく、タッチ直後であればtrueを返す。
			if (IsGameOver() == true && touch.phase == TouchPhase.Began) {
				Application.LoadLevel("Home");
			}
		}
	}

	public static void EnemyDeadCount(){
		enemyDeadCount++;
	}

	public bool IsGameOver() {
		return gameOverText.gameObject.activeSelf == true;
	}

	void StageClear() {
		Pauser.Pause();
		stage.UnlockStage(nStage+1);
		stageClearText.gameObject.SetActive(true);
	}

	void GameOver() {
		Pauser.Pause();
		gameOverText.gameObject.SetActive(true);
		//Application.LoadLevel("Home");
	}
}
