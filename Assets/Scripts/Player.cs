using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 5;
	public float moveForce = 200; 
	public float jumpForce = 200;

	public bool facingRight = true;
	public bool jump = false;
	public bool move = false;
	public bool isAttack = false;

	private Transform groundCheck;
	bool grounded = false;

	public GameObject Bullet;
	public static int bulletDir;

	void Update () {
		grounded = Physics2D.Linecast(transform.position, 
		                              transform.position - transform.up * 1.3f,
		                              1 << LayerMask.NameToLayer("Ground"));
		if (facingRight)
			bulletDir = 1;
		else
			bulletDir = -1;

		GetComponent<Animator>().SetBool("isAttack",isAttack);
	}

	void FixedUpdate () {
		if(Input.GetKeyDown("up") && grounded)
			jump = true;

		if(Input.GetKeyDown("b"))
			Instantiate(Bullet, new Vector2(transform.position.x + bulletDir, transform.position.y), Quaternion.identity);

		float h = Input.GetAxis("Horizontal");

		if(h * rigidbody2D.velocity.x < maxSpeed)
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if(h > 0 && !facingRight)
			Flip();
		else if(h < 0 && facingRight)
			Flip();

		if (jump) {
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		if(Input.GetKeyDown("return")){
			isAttack = true;
			StartCoroutine("WaitForAttack");
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator WaitForAttack()
	{
		yield return new WaitForSeconds(0.5f);
		isAttack = false;
	}
}
