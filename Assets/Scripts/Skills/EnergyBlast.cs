using UnityEngine;
using System.Collections;

public class EnergyBlast : MonoBehaviour {
	public Vector2 acceleration;
	private float lifeTime = 1.5f;
	public int damage = 3;

	void Start () {
		if(Player.facingRight){
			acceleration = new Vector2(9.81f, 0);
		}else{
			acceleration = new Vector2(-9.81f, 0);
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
