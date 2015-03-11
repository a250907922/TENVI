using UnityEngine;
using System.Collections;

public class WhityBomb2 : MonoBehaviour {
	private float lifeTime = 2.1f;
	private float explodeTime = 2.0f;
	public int damage = 10;

	void Start () {
		gameObject.layer = 18;
	}

	void Update () {

		lifeTime -= Time.deltaTime;
		explodeTime -=Time.deltaTime;
		if(lifeTime < 0) {
			Destroy(gameObject);
		}
		if(explodeTime < 0){
			gameObject.layer = 10;
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.SendMessage("Damage", damage);
		}
	}
}
