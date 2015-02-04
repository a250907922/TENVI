using UnityEngine;
using System.Collections;

public class ErekiBall : MonoBehaviour {
	public int damage = 5;
	public float speed = 1.0f;
	private float lifeTime = 1.0f;

	void Start () {
		if (Player.facingRight) {
			speed = 0.1f;
		} else {
			speed = -0.1f;
		}
	}

	void Update () {
		//移動
		transform.position = new Vector2(transform.position.x + speed, transform.position.y);
		//時間経過で消滅
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
