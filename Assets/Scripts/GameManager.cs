using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	// EnemyPrefab設定GameObject
	public GameObject enemyPrefab;
	// ドロップするオブジェクトの位置指定
	private float DropPosY = -3.5f;
	StageSelect stageSelect;
	StageManager stageManager;
	public int nStage;
	public Text stageClearText;
	public Text gameOverText;
	public int slimeKillCount = 0;
	public int draKillCount = 0;
	private int[] requiredKillEnemys = new int[3];
	public Text enemyKillCountText;
	private int remainCount;

	void Awake() {
		nStage = StageSelect.stageNum;
		stageClearText.gameObject.SetActive(false);
		gameOverText.gameObject.SetActive(false);
		stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
		requiredKillEnemys = stageManager.GetKillEnemys(nStage);
		Debug.Log("ステージ"+nStage+"です");
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

		// ステージクリア判定
		if(requiredKillEnemys[0] < slimeKillCount && requiredKillEnemys[2] < draKillCount){
			StageClear();
		}

		remainCount = requiredKillEnemys[0] - slimeKillCount;
		if(remainCount < 0)
			remainCount = 0;
		enemyKillCountText.text = "残り" + remainCount.ToString() + "体";

		if(remainCount <= 0 && nStage!=0)
			StageClear();
	}

	public bool IsGameOver() {
		return gameOverText.gameObject.activeSelf == true;
	}

	public void StageClear() {
		Pauser.Pause();
		PlayerPrefs.SetInt("clearStage", nStage);
		stageClearText.gameObject.SetActive(true);
	}

	public void GameOver() {
		Pauser.Pause();
		gameOverText.gameObject.SetActive(true);
		//Application.LoadLevel("Home");
	}
}
