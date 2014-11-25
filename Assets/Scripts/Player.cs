using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 5; //プレイヤーの移動最高速度
	public float moveForce = 200; //加速力(移動時に加える力)
	public float jumpForce = 200; //ジャンプ力

	public static bool facingRight = true; //方向判定用 右向いてるときはtrue
	public bool jump = false; //ジャンプしてるか
	public bool isAttack = false; //攻撃してるか
	public bool bulletAttack = false;
	public bool swordAttack = false;
	bool grounded = false; //地面についてるか
	private Animator anim; //アニメーション用

	public GameObject BulletPrefab; // 弾オブジェクト
	public GameObject Sword_Fire; // 近接攻撃オブジェクト

	void Start() {
		anim = GetComponent<Animator> (); //アニメーション用
	}

	void Update () {
		/* 地面に接触しているか */
		grounded = Physics2D.Linecast(transform.position, 
		                              transform.position - transform.up * 1.3f,
		                              1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetKeyDown("up") && grounded)
			jump = true;

		anim.SetBool("isAttack",isAttack); // アニメーション用
		if(Input.GetKeyDown("x")){ // 近接攻撃
			isAttack = true; // アニメーション用フラグ
			swordAttack = true; // 攻撃フラグ
			if(facingRight){ // 向きとオブジェクトを出す場所を合わせる
				SwordFire.firePosX = 2.0f;
			}else{
				SwordFire.firePosX = -2.0f;
			}
		}

		if(Input.GetKeyDown("b")){ // 弾攻撃
			bulletAttack = true;
			if(facingRight)
				Bullet.bulletDir = 1;
			else
				Bullet.bulletDir = -1;
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
		anim.SetFloat ("Speed", Mathf.Abs (rigidbody2D.velocity.x));

		/* 左右反転 */
		if(h > 0 && !facingRight)
			Flip();
		else if(h < 0 && facingRight)
			Flip();

		/* 攻撃 */
		if(swordAttack){
			StartCoroutine("WaitForAttack");
			Instantiate(Sword_Fire, new Vector2(transform.position.x + SwordFire.firePosX, transform.position.y), Quaternion.identity);
			swordAttack = false;
		}

		/* 弾発射 */
		if(bulletAttack){
			StartCoroutine("WaitForAttack");
			Instantiate(BulletPrefab, new Vector2(transform.position.x + Bullet.bulletDir, transform.position.y), Quaternion.identity);
			bulletAttack = false;
		}
	}

	/* 左右反転 */
	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/* 攻撃 */
	IEnumerator WaitForAttack(){
		yield return new WaitForSeconds(0.5f);
		isAttack = false;
	}

	void OnDestroy() {
		facingRight = true;
	}
}
