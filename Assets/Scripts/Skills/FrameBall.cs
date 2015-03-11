using UnityEngine;
using System.Collections;

public class FrameBall : MonoBehaviour {
	public int damage = 5;
	public float speed = 1.0f;
	private float lifeTime = 1.0f;
	public Vector2 acceleration;

	void Start () {
		if(Player.facingRight){
			acceleration = new Vector2(9.81f, 0);
		}else{
			acceleration = new Vector2(-9.81f, 0);
		}
	}

	void Update () {
		GetComponent<Rigidbody2D>().AddForce(acceleration * GetComponent<Rigidbody2D>().mass);
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
