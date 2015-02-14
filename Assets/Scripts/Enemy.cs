using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {
	//private int Point = 10; //スコア用
	public int startHp = 10;
	public int currentHp;
	private GameObject hpBar;
	private Vector2 scale = new Vector2(1.5f, 1.5f);
	public int slimeExp = 1;
	private float maxSpeed = 1.0f;
	private float moveForce = 200; //加速力(移動時に加える力)
	private bool facingRight = false;

	private GameObject player;
	//private GameObject score;
	private GameObject expObj;
	public string TagetObjectName;
	public static bool IsDeadEnemy = false;
	public Text damageText;

	void Awake() {
		InvokeRepeating("Move", 2.0f, 1.0f);
		gameObject.layer = 16;
	}

	void Start(){
		currentHp = startHp;
		GameObject.Find(TagetObjectName);
		player = GameObject.Find("Player");
		//score = GameObject.Find ("Score");
		expObj = GameObject.Find ("ExpObj");
		StartCoroutine ("SpawnEnemy");
		hpBar = gameObject.transform.FindChild("HP").gameObject;
		hpBar.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update() {
	}

	//透明からだんだん出現する
	private IEnumerator SpawnEnemy() {
		Color updateColor = new Vector4(0, 0, 0, 0.1f);
		renderer.material.color = new Vector4(255, 255, 255, 0);
		while (renderer.material.color.a <= 1){
			renderer.material.color += updateColor;
			if(renderer.material.color.a == 0.6f)
				renderer.material.color = new Vector4(255,255,255,1);
			yield return new WaitForSeconds(0.3f);
		}
		gameObject.layer = 10;
	}

	void Move() {
		float hor;
		if((player.transform.position.x - this.transform.position.x) > 0){
			hor = 1;
			if(!facingRight)
				Flip();
		} else {
			hor = -1;
			if(facingRight)
				Flip();
		}
		if(hor * rigidbody2D.velocity.x < maxSpeed) //maxSpeedより小さかったら力を加える
			rigidbody2D.AddForce(Vector2.right * hor * moveForce);
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed) //maxSpeedより大きかったら修正
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Damage(int damage){
		//damageText.transform.parent = canvas.transform;
		//damageText.text = "" + damage.ToString();
		//Instantiate(damageText, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0), Quaternion.identity);
		hpBar.GetComponent<SpriteRenderer>().enabled = true;
		hpBar.transform.localScale = scale;
		currentHp -= damage;
		float currentSize;
		currentSize = (float)currentHp/startHp * 1.5f;
		hpBar.transform.localScale = new Vector2(currentSize, currentSize);
		if(currentHp <= 0){ //死んだとき
			EnemyDead();
		}
	}

	void EnemyDead() {
		Destroy(gameObject);
		//score.SendMessage("UpdateScore", Point);
		expObj.SendMessage("GetExperience", slimeExp);
	}
}
