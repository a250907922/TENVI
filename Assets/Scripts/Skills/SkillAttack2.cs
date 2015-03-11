using UnityEngine;
using System.Collections;

public class SkillAttack2 : MonoBehaviour {
	private float lifeTime = 0.3f;
	public int damage = 10;
	public Vector2 acceleration;

	void Start () {
		if(Player.facingRight){
			acceleration = new Vector2(19.81f, 0);
		}else{
			acceleration = new Vector2(-19.81f, 0);
		}
	}

	void Update () {
		GetComponent<Rigidbody2D>().AddForce(acceleration * GetComponent<Rigidbody2D>().mass);

		lifeTime -= Time.deltaTime;
		if(lifeTime < 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.SendMessage("Damage", damage);
		}
	}
}
