using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 5.0f; //プレイヤーの移動最高速度
	public float moveForce = 200.0f; //加速力(移動時に加える力)
	public float jumpForce = 200.0f; //ジャンプ力
	public float damageForce = 100.0f;

	public static bool facingRight = true; //方向判定用 右向いてるときはtrue
	public bool jump = false; //ジャンプしてるか
	public bool isAttack = false; //攻撃してるか
	public bool bulletAttack = false;
	public bool meleeAttack = false;
	bool grounded = false; //地面についてるか
	private Animator anim; //アニメーション用
	public static bool isRightEnemy; //自分より敵が右にいるか
	public bool isDamaged; //ダメージを受けてる状態

	public GameObject BulletPrefab; // 弾オブジェクト
	public GameObject Sword_Fire; // 近接攻撃オブジェクト
	public GameObject hpBar; //HPバー
	public float firePosX; //近接攻撃の出る場所
	public float mutekiTime = 1.0f;
	public float flashInterval = 0.02f;

	void Start() {
		anim = GetComponent<Animator> (); //アニメーション用
	}

	void Update () {
		/* 地面に接触しているか */
		grounded = Physics2D.Linecast(transform.position,
		transform.position - transform.up * 1.0f,
		1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetKeyDown("up") && grounded)
		jump = true;

		anim.SetBool("isAttack",isAttack); // アニメーション用
		if(Input.GetKeyDown("x")){ // 近接攻撃
			isAttack = true; // アニメーション用フラグ
			meleeAttack = true; // 攻撃フラグ
			if(facingRight){ // 向きとオブジェクトを出す場所を合わせる
				firePosX = AttackMelee.fireScale*2.7f;
			}else{
				firePosX = -AttackMelee.fireScale*2.7f;
			}
		}

		if(Input.GetKeyDown("b")){ // 弾攻撃
			bulletAttack = true;
			if(facingRight)
			AttackBullet.bulletDir = 1;
			else
			AttackBullet.bulletDir = -1;
		}
	}

	void FixedUpdate () {
		/* ジャンプ */
		if (jump) {
			//anim.SetTrigger("Jump");
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		/* 移動速度 */
		float h = Input.GetAxis("Horizontal");
		if(h * rigidbody2D.velocity.x < maxSpeed)
		rigidbody2D.AddForce(Vector2.right * h * moveForce);
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (rigidbody2D.velocity.x)); //アニメーション用

		/* 左右反転 */
		if(h > 0 && !facingRight)
		Flip();
		else if(h < 0 && facingRight)
		Flip();

		/* 攻撃 */
		if(meleeAttack){
			StartCoroutine("WaitForAttack");
			Instantiate(Sword_Fire, new Vector2(transform.position.x + firePosX, transform.position.y), Quaternion.identity);
			meleeAttack = false;
		}

		/* 弾発射 */
		if(bulletAttack){
			StartCoroutine("WaitForAttack");
			Instantiate(BulletPrefab, new Vector2(transform.position.x + AttackBullet.bulletDir, transform.position.y), Quaternion.identity);
			bulletAttack = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		/* ダメージ判定 */
		if(col.gameObject.tag == "Enemy"){
			if(!isDamaged){
				//TODO : キャラによって変える, Damage関数を作る
				hpBar.SendMessage("OnDamage", 1); //HPバーにダメージメッセージを送る
				if((col.gameObject.transform.position.x - this.transform.position.x) > 0) {
					isRightEnemy = true;
					rigidbody2D.AddForce(-Vector2.right * damageForce);
					rigidbody2D.AddForce(Vector2.up * damageForce);
				} else {
					isRightEnemy = false;
					rigidbody2D.AddForce(Vector2.right * damageForce);
					rigidbody2D.AddForce(Vector2.up * damageForce);
				}
				isDamaged = true;
				StartCoroutine("WaitForDamage");
			}
		}
	}

	/* 左右反転 */
	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/* 攻撃ディレイ */
	IEnumerator WaitForAttack() {
		yield return new WaitForSeconds(0.3f);
		isAttack = false;
	}

	/* ダメージ受けた後の無敵時間 */
	IEnumerator WaitForDamage() {
		float flashTime = 0f;
		Color color = renderer.material.color;
		bool inv = false;
		while (mutekiTime > flashTime){
			if(!inv){
				color.a = 0.5f;
				renderer.material.color = color;
				inv = true;
			}else{
				color.a = 1.0f;
				renderer.material.color = color;
				inv = false;
			}
			yield return new WaitForSeconds(flashInterval);
			flashTime += flashInterval;
		}
		color.a = 1.0f;
		renderer.material.color = color;
		isDamaged = false;
	}

	void OnDestroy() {
		facingRight = true;
	}
}
