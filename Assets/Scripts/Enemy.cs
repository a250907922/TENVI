using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {
	//private int Point = 10; //スコア用
	public int startHp = 10;
	public int currentHp;
	private GameObject hpBar;
	private Vector2 scale = new Vector2(1.5f, 1.5f);
	public int slimeExp = 1;
	private float maxSpeed = 1.0f;
	private float moveForce = 200; //加速力(移動時に加える力)
	private bool facingRight = false;

	private GameObject player;
	//private GameObject score;
	private GameObject expObj;
	public string TagetObjectName;
	public static bool IsDeadEnemy = false;
	public Text damageText;

	private int challengeMode;
	private int chalPwr;
	private int chalInt;
	private int power;
	private int intelligence;

	GameManager gameManager;

	void Awake() {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		challengeMode = PlayerPrefs.GetInt("challengeMode");
		InvokeRepeating("Move", 2.0f, 1.0f);
		gameObject.layer = 16;
		if(challengeMode == 1){
			chalPwr = PlayerPrefs.GetInt("ChalPwr");
			chalInt = PlayerPrefs.GetInt("ChalInt");
		}else{
			power = PlayerPrefs.GetInt("power");
			intelligence = PlayerPrefs.GetInt("intelligence");
		}
	}

	void Start(){
		currentHp = startHp;
		GameObject.Find(TagetObjectName);
		player = GameObject.Find("Player");
		//score = GameObject.Find ("Score");
		expObj = GameObject.Find ("ExpObj");
		StartCoroutine ("SpawnEnemy");
		hpBar = gameObject.transform.FindChild("HP").gameObject;
		hpBar.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update() {
	}

	//透明からだんだん出現する
	private IEnumerator SpawnEnemy() {
		Color updateColor = new Vector4(0, 0, 0, 0.1f);
		GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, 0);
		while (GetComponent<Renderer>().material.color.a <= 1){
			GetComponent<Renderer>().material.color += updateColor;
			if(GetComponent<Renderer>().material.color.a == 0.6f)
				GetComponent<Renderer>().material.color = new Vector4(1,1,1,1);
			yield return new WaitForSeconds(0.3f);
		}
		gameObject.layer = 10;
	}

	void Move() {
		float hor;
		if((player.transform.position.x - this.transform.position.x) > 0){
			hor = 1;
			if(!facingRight)
				Flip();
		} else {
			hor = -1;
			if(facingRight)
				Flip();
		}
		if(hor * GetComponent<Rigidbody2D>().velocity.x < maxSpeed) //maxSpeedより小さかったら力を加える
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * hor * moveForce);
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed) //maxSpeedより大きかったら修正
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Damage(int damage){
		hpBar.GetComponent<SpriteRenderer>().enabled = true;
		hpBar.transform.localScale = scale;
		if(Critical()){
			currentHp -= (damage+chalPwr) * 2;
		}else{
			currentHp -= damage + power;
		}
		float currentSize;
		currentSize = (float)currentHp/startHp * 1.5f;
		hpBar.transform.localScale = new Vector2(currentSize, currentSize);
		if(currentHp <= 0){ //死んだとき
			EnemyDead();
		}
	}

	private bool Critical() {
		bool critical = false;
		int randomInt = Random.Range(0,100);
		if(challengeMode == 1){
			if(chalInt > randomInt)
				critical = true;
		}else{
			if(intelligence > randomInt)
				critical = true;
		}
		return critical;
	}

	void EnemyDead() {
		Destroy(gameObject);
		//score.SendMessage("UpdateScore", Point);
		if(challengeMode == 0){
			expObj.SendMessage("GetExperience", slimeExp);
			gameManager.slimeKillCount++;
		}
	}
}
