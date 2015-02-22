using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillShot : MonoBehaviour {
	public ParticleSystem energyBlast, erekiBall, erekiBall2, fireShot, frameBall, greenCore, skillAttack, skillAttack2, spark, whityBomb, whityBomb2;
	public GameObject swordFire; // 近接攻撃オブジェクト
	public int direction;
	private float DropPosX = 0f;
	private float DropPosY = 5.5f;
	private string skillName = "";
	public static bool isAttack = false; //攻撃してるか
	public float firePosX; //近接攻撃の出る場所
	private Animator anim;
	public Button skillButton;
	private float cd = 1.0f;
	private float cdr = 0.0f;

	// Use this for initialization
	void Start () {
		//DropPosY = Screen.height;
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		anim.SetBool("isAttack",isAttack); // アニメーション用
		if(Input.GetKeyDown("x")){ // 近接攻撃
			SwordFire();
		}

		if(Input.GetKeyDown("q")){
			//energyBlast.transform.position = this.gameObject.transform.position;
			//energyBlast.Play();
			EnergyBlast();
		}
		if(Input.GetKeyDown("w")){
			//ErekiBall.transform.position = this.gameObject.transform.position;
			//ErekiBall.Play();
			ErekiBall();
		}
		if(Input.GetKeyDown("e")){
			//ErekiBall2.transform.position = this.gameObject.transform.position;
			//ErekiBall2.Play();
			ErekiBall2();
		}
		if(Input.GetKeyDown("r")){
			//fireShot.transform.position = this.gameObject.transform.position;
			//fireShot.Play();
			FireShot();
		}
		if(Input.GetKeyDown("t")){
			//frameBall.transform.position = this.gameObject.transform.position;
			//frameBall.Play();
			FrameBall();
		}
		if(Input.GetKeyDown("y")){
			//GreenCore.transform.position = this.gameObject.transform.position;
			//GreenCore.Play();
			GreenCore();
		}
		if(Input.GetKeyDown("u")){
			//skillAttack.transform.position = this.gameObject.transform.position;
			//skillAttack.Play();
			SkillAttack();
		}
		if(Input.GetKeyDown("i")){
			//skillAttack2.transform.position = this.gameObject.transform.position;
			//skillAttack2.Play();
			SkillAttack2();
		}
		if(Input.GetKeyDown("o")){
			//Spark.transform.position = this.gameObject.transform.position;
			//Spark.Play();
			Spark();
		}
		if(Input.GetKeyDown("p")){
			//WhityBomb.transform.position = this.gameObject.transform.position;
			//WhityBomb.Play();
			WhityBomb();
		}
		if(Input.GetKeyDown("@")){
			WhityBomb2();
		}
	}

	private IEnumerator SparkStart() {
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
	}

	private void SwordFire(){
		cd = 0.5f;
		isAttack = true; // アニメーション用フラグ
		StartCoroutine("WaitForAttack");
		if(Player.facingRight){ // 向きとオブジェクトを出す場所を合わせる
			firePosX = AttackMelee.fireScale*2.7f;
		}else{
			firePosX = -AttackMelee.fireScale*2.7f;
		}
		Instantiate(swordFire, new Vector2(transform.position.x + firePosX, transform.position.y), Quaternion.identity);
	}

	/* 攻撃ディレイ */
	IEnumerator WaitForAttack() {
		yield return new WaitForSeconds(0.3f);
		isAttack = false;
	}

	private void EnergyBlast(){
		cd = 1.0f;
		Instantiate(energyBlast, this.gameObject.transform.position, Quaternion.identity);
	}

	private void ErekiBall(){
		cd = 0.5f;
		Instantiate(erekiBall, this.gameObject.transform.position, Quaternion.identity);
	}

	private void ErekiBall2(){
		cd = 0.5f;
		Instantiate(erekiBall2, this.gameObject.transform.position, Quaternion.identity);
	}

	private void FireShot(){
		cd = 1.0f;
		Instantiate(fireShot, this.gameObject.transform.position, Quaternion.identity);
	}

	private void FrameBall(){
		cd = 0.5f;
		Instantiate(frameBall, this.gameObject.transform.position, Quaternion.identity);
	}

	private void GreenCore(){
		cd = 1.0f;
		Instantiate(greenCore, this.gameObject.transform.position, Quaternion.identity);
	}

	private void SkillAttack(){
		cd = 0.5f;
		Instantiate(skillAttack, this.gameObject.transform.position, Quaternion.identity);
	}

	private void SkillAttack2(){
		cd = 0.3f;
		if(Player.facingRight){
			direction = 1;
		}else{
			direction = -1;
		}
		Instantiate(skillAttack2, new Vector2(this.gameObject.transform.position.x + (direction*2), this.gameObject.transform.position.y), Quaternion.identity);
	}

	private void Spark(){
		cd = 2.0f;
		StartCoroutine("SparkStart");
	}

	private void WhityBomb(){
		cd = 1.0f;
		Instantiate(whityBomb, this.gameObject.transform.position, Quaternion.identity);
	}

	private void WhityBomb2(){
		cd = 3.0f;
		DropPosX = Random.Range(-8.0f, 8.0f);
		DropPosY = Random.Range(-3.0f, 0.0f);
		Instantiate(whityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		DropPosY = Random.Range(-3.0f, 0.0f);
		Instantiate(whityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		DropPosY = Random.Range(-3.0f, 0.0f);
		Instantiate(whityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		DropPosY = Random.Range(-3.0f, 0.0f);
		Instantiate(whityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		DropPosY = Random.Range(-3.0f, 0.0f);
		Instantiate(whityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
	}

	public void SkillButton() {
		if(GameManager.challengeMode){
			skillName = PlayerPrefs.GetString("ChalSkill");
		}else{
			skillName = PlayerPrefs.GetString("skill");
		}
		Debug.Log(skillName);
		switch(skillName){
			default:
			SwordFire();
			break;
			case "energyBlast":
			EnergyBlast();
			break;
			case "erekiBall":
			ErekiBall();
			break;
			case "erekiBall2":
			ErekiBall2();
			break;
			case "fireShot":
			FireShot();
			break;
			case "frameBall":
			FrameBall();
			break;
			case "greenCore":
			GreenCore();
			break;
			case "skillAttack":
			SkillAttack();
			break;
			case "skillAttack2":
			SkillAttack2();
			break;
			case "spark":
			Spark();
			break;
			case "whityBomb":
			WhityBomb();
			break;
			case "whityBomb2":
			WhityBomb2();
			break;
		}
		StartCoroutine("CoolDown");
	}

	private IEnumerator CoolDown(){
		skillButton.interactable = false;
		yield return new WaitForSeconds(cd * (100.0f - cdr)/100.0f);
		skillButton.interactable = true;
	}
}
