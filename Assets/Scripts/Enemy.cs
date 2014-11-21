using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private int Point = 10;
	public int hp = 10;
	public GameObject score;
	public string TagetObjectName;
	public static bool IsDeadEnemy = false;

	void Start(){
		GameObject.Find(TagetObjectName);
		score = GameObject.Find ("Score");
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

	void EnemyDead() {
		Destroy(gameObject);
		score.SendMessage("UpdateScore", Point);
	}
}