using UnityEngine;
using System.Collections;

public class SkillAttack : MonoBehaviour {
	public int damage = 5;
	private float lifeTime = 0.3f;

	void Start () {
	}

	void Update () {
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
