using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Arena : MonoBehaviour {
	private Vector2[] positions = new Vector2[6];
	private float[] distances = new float[5];
	public GameObject slime;
	public int clearNum = 10;
	GameObject[] enemys;
	public int killCount = 0;
	public int newEnemyNumber;
	public Button killButton;
	public int arenaClearStage;
	public ArenaLizardStatus arenaLizardStatus;
	Animator anim;

	void Awake() {
		arenaClearStage = PlayerPrefs.GetInt("ArenaClearStage");
		arenaLizardStatus = GameObject.Find("Lizard").GetComponent<ArenaLizardStatus>();
		enemys = new GameObject[clearNum];
		killButton = GameObject.Find("KillButton").GetComponent<Button>();

		anim = GameObject.Find("Lizard").GetComponent<Animator>();
	}

	void Start () {
		for(int i=0; i<6; i++){
			if(i==0)
				positions[i] = GameObject.Find("Pos1").transform.position;
			else
				positions[i] = positions[i-1]+new Vector2(2.5f, 0);
		}
		for(int j=0; j<6; j++){
			enemys[j] = Instantiate(slime, positions[j], Quaternion.identity) as GameObject;
		}
		for(int k=0; k<5; k++){
			distances[k] = positions[k+1].x - positions[k].x;
		}
	}

	void Update () {
		if(killCount >= clearNum){
			killButton.interactable = false;
			StageClear();
		}else if(arenaLizardStatus.chalHp <= 0){
			GameOver();
		}
	}

	public void KillEnemyButton() {
		KillAnimation();
		killCount++;
		Debug.Log(killCount);
		SpawnEnemy();
		StartCoroutine("AttackAnim");
	}

	void SpawnEnemy() {
		newEnemyNumber = 5 + killCount;
		if(newEnemyNumber < enemys.Length)
			enemys[newEnemyNumber] = Instantiate(slime, positions[5], Quaternion.identity) as GameObject;

		for(int i=0; i<5; i++){
			if(killCount+i < enemys.Length)
			StartCoroutine("MoveEnemys", i);
		}
	}

	IEnumerator MoveEnemys(int num){
		float length = 0;
		while(length < distances[num]){
			enemys[killCount+num].transform.position += new Vector3(-distances[num]/5, 0, 0);
			length += distances[num]/5;
			yield return new WaitForSeconds(0.001f);
		}
	}

	IEnumerator AttackAnim(){
		anim.SetBool("Attack", true);
		yield return new WaitForSeconds(0.3f);
		anim.SetBool("Attack", false);
	}

	void KillAnimation(){
		enemys[killCount].GetComponent<Rigidbody2D>().isKinematic = false;
		enemys[killCount].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.0f, 1.0f), Random.value) * 500);
	}

	void StageClear() {
		PlayerPrefs.SetInt("ArenaClearStage", arenaClearStage+1);
		Application.LoadLevel("ArenaReady");
	}

	void GameOver() {
		//PlayerPrefs.SetInt("ArenaClearStage", 0);
		Application.LoadLevel("Home");
	}
}
