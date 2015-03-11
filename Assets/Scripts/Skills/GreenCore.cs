using UnityEngine;
using System.Collections;

public class GreenCore : MonoBehaviour {
	private float lifeTime = 3.5f;
	public float speed = 1.0f;
	private float explodeTime = 3.3f;
	public int damage = 10;
	public Vector2 acceleration;

	void Start () {
		gameObject.layer = 18;
		if (Player.facingRight) {
			speed = 0.01f;
		} else {
			speed = -0.01f;
		}
	}

	void Update () {
		transform.position = new Vector2(transform.position.x + speed, transform.position.y);

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
