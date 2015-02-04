using UnityEngine;
using System.Collections;

public class WhityBomb : MonoBehaviour {
	private float lifeTime = 2.1f;
	public float speed = 1.0f;
	private float explodeTime = 2.0f;
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
			rigidbody2D.isKinematic = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.SendMessage("Damage", damage);
		}
	}
}
