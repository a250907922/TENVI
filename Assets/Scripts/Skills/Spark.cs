using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {
	public Vector2 acceleration;
	private float lifeTime = 4.0f;
	public int damage = 3;

	void Start () {
		float tempGraX = Random.Range(0f, 10.0f);
		float tempGraY = Random.Range(0f, 5.0f);
		if(Player.facingRight){
			acceleration = new Vector2(tempGraX, tempGraY);
		}else{
			acceleration = new Vector2(-tempGraX, tempGraY);
		}
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce(acceleration * GetComponent<Rigidbody2D>().mass);
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.SendMessage("Damage", damage);
		}
	}
}
