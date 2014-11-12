using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private int Point = 10;
	public int hp = 4;
	public GameObject score;
	public string TagetObjectName;

	void Start(){
		GameObject.Find(TagetObjectName);
		score = GameObject.Find ("Score");
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Bullet"){
			Destroy (col.gameObject);
			hp -= Bullet.power;
			if(hp <= 0){
				Destroy(gameObject);
				score.SendMessage("UpdateScore", Point);
			}
			Debug.Log(hp);
		}
		if(col.gameObject.tag == "SwordFire"){
			hp -= SwordFire.power;
			if(hp <= 0){
				Destroy(gameObject);
				score.SendMessage("UpdateScore", Point);
			}
		}
	}
}