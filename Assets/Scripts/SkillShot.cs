using UnityEngine;
using System.Collections;

public class SkillShot : MonoBehaviour {
	public ParticleSystem energyBlast, ErekiBall, ErekiBall2, fireShot, frameBall, GreenCore, skillAttack, skillAttack2, Spark, WhityBomb, WhityBomb2;
	public int direction;
	private float DropPosX = 0f;
	private float DropPosY = 5.5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")){
			//energyBlast.transform.position = this.gameObject.transform.position;
			energyBlast.Play();
			Instantiate(energyBlast, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("w")){
			//ErekiBall.transform.position = this.gameObject.transform.position;
			//ErekiBall.Play();
			Instantiate(ErekiBall, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("e")){
			//ErekiBall2.transform.position = this.gameObject.transform.position;
			//ErekiBall2.Play();
			Instantiate(ErekiBall2, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("r")){
			//fireShot.transform.position = this.gameObject.transform.position;
			//fireShot.Play();
			Instantiate(fireShot, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("t")){
			//frameBall.transform.position = this.gameObject.transform.position;
			//frameBall.Play();
			Instantiate(frameBall, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("y")){
			//GreenCore.transform.position = this.gameObject.transform.position;
			//GreenCore.Play();
			Instantiate(GreenCore, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("u")){
			//skillAttack.transform.position = this.gameObject.transform.position;
			//skillAttack.Play();
			Instantiate(skillAttack, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("i")){
			//skillAttack2.transform.position = this.gameObject.transform.position;
			//skillAttack2.Play();
			if(Player.facingRight){
				direction = 1;
			}else{
				direction = -1;
			}
			Instantiate(skillAttack2, new Vector2(this.gameObject.transform.position.x + (direction*2), this.gameObject.transform.position.y), Quaternion.identity);
		}
		if(Input.GetKeyDown("o")){
			//Spark.transform.position = this.gameObject.transform.position;
			//Spark.Play();
			StartCoroutine("SparkStart");
		}
		if(Input.GetKeyDown("p")){
			//WhityBomb.transform.position = this.gameObject.transform.position;
			//WhityBomb.Play();
			Instantiate(WhityBomb, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("@")){
			DropPosX = Random.Range(-8.0f, 8.0f);
			DropPosY = Random.Range(-3.0f, 0.0f);
			Instantiate(WhityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
			DropPosX = Random.Range(-8.0f, 8.0f);
			DropPosY = Random.Range(-3.0f, 0.0f);
			Instantiate(WhityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
			DropPosX = Random.Range(-8.0f, 8.0f);
			DropPosY = Random.Range(-3.0f, 0.0f);
			Instantiate(WhityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
			DropPosX = Random.Range(-8.0f, 8.0f);
			DropPosY = Random.Range(-3.0f, 0.0f);
			Instantiate(WhityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
			DropPosX = Random.Range(-8.0f, 8.0f);
			DropPosY = Random.Range(-3.0f, 0.0f);
			Instantiate(WhityBomb2, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		}
	}

	private IEnumerator SparkStart() {
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
		DropPosX = Random.Range(-8.0f, 8.0f);
		Instantiate(Spark, new Vector2(DropPosX, DropPosY), Quaternion.identity);
	}

	public void SkillButton() {

	}
}
