using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private int Point = 10;
	public int hp = 10;
	public float maxSpeed = 1.0f;
	public float moveForce = 200; //加速力(移動時に加える力)

	public GameObject player;
	public GameObject score;
	public string TagetObjectName;
	public static bool IsDeadEnemy = false;

	void Awake() {
		InvokeRepeating("Move", 2.0f, 1.0f);
	}

	void Start(){
		GameObject.Find(TagetObjectName);
		score = GameObject.Find ("Score");
	}

	void Update() {
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Bullet"){
			Destroy (col.gameObject);
			hp -= Bullet.fixedPower;
			if(hp <= 0){
				EnemyDead();
			}
		}
		if(col.gameObject.tag == "SwordFire"){
			hp -= SwordFire.fixedPower;
			if(hp <= 0){
				EnemyDead();
			}
		}
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

	void EnemyDead() {
		Destroy(gameObject);
		score.SendMessage("UpdateScore", Point);
	}
}