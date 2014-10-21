using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private int Point = 10;
	public int hp = 2;
	private GameObject GameManager;
	public string TagetObjectName;
	private string Tag = "Bullet";

	void Start(){
		GameManager =  GameObject.Find(TagetObjectName);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == Tag){
			Destroy (col.gameObject);
			hp = hp - Bullet.power;
			if(hp <= 0 ){
				Destroy(gameObject);
			}
		}
	}
}