using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//private int Point = 10; //スコア用
	private int hp = 10;
	public int slimeExp = 1;
	private float maxSpeed = 1.0f;
	private float moveForce = 200; //加速力(移動時に加える力)

	public GameObject player;
	public GameObject score;
	public GameObject expObj;
	public string TagetObjectName;
	public static bool IsDeadEnemy = false;

	void Awake() {
		InvokeRepeating("Move", 2.0f, 1.0f);
		gameObject.layer = 16;
	}

	void Start(){
		GameObject.Find(TagetObjectName);
		score = GameObject.Find ("Score");
		expObj = GameObject.Find ("ExpObj");
		StartCoroutine ("SpawnEnemy");
	}

	void Update() {
	}

	//透明からだんだん出現する
	private IEnumerator SpawnEnemy() {
		Color updateColor = new Vector4(0, 0, 0, 0.1f);
		renderer.material.color = new Vector4(255, 255, 255, 0);
		while (renderer.material.color.a <= 1){
			renderer.material.color += updateColor;
			if(renderer.material.color.a == 0.6f)
				renderer.material.color = new Vector4(255,255,255,1);
			yield return new WaitForSeconds(0.3f);
		}
		gameObject.layer = 10;
	}

	void Move() {
		float hor;
		if((player.transform.position.x - this.transform.position.x) > 0){
			hor = 1;
		} else {
			hor = -1;
		}
		if(hor * rigidbody2D.velocity.x < maxSpeed) //maxSpeedより小さかったら力を加える
			rigidbody2D.AddForce(Vector2.right * hor * moveForce);
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed) //maxSpeedより大きかったら修正
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
	}

	public void Damage(int damage){
		hp -= damage;
		if(hp <= 0){ //死んだとき
			EnemyDead();
		}
	}

	void EnemyDead() {
		Destroy(gameObject);
		//score.SendMessage("UpdateScore", Point);
		expObj.SendMessage("GetExperience", slimeExp);
	}
}
