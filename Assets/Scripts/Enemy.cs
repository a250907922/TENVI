using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// SendMessageの送り先になるObject名
	public string TagetObjectName;
//	public int hp = 1;

	private int Point = 10;
	private GameObject GameManager;
	// 操作キャラに付与されているタグ名
	private string Tag = "Player";

	void Start(){
		GameManager =  GameObject.Find(TagetObjectName);
	}

//	void Update(){
//		hp = hp - Bullet.power;
//		if(hp <= 0 ){	
//			Destroy (gameObject);
//		}
//	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == Tag){
			// 衝突したのがTag(プレイヤー)だったら得点獲得＆自身はきえる
			Destroy(gameObject);
			GameManager.SendMessage ("GetScore",  10);
		}
	}
}
