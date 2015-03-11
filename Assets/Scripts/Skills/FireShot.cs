using UnityEngine;
using System.Collections;

public class FireShot : MonoBehaviour {
	private float lifeTime = 0.9f;
	private float explodeTime = 0.7f;
	public int damage = 10;
	public Vector2 acceleration;

	void Start () {
		gameObject.layer = 18;
		if(Player.facingRight){
			acceleration = new Vector2(15.81f, 0);
		}else{
			acceleration = new Vector2(-15.81f, 0);
		}
	}

	void Update () {
			GetComponent<Rigidbody2D>().AddForce(acceleration * GetComponent<Rigidbody2D>().mass);

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
