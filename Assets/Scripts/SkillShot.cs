using UnityEngine;
using System.Collections;

public class SkillShot : MonoBehaviour {
	public ParticleSystem energyBlast, ErekiBall, ErekiBall2, fireShot, frameBall, GreenCore, skillAttack, skillAttack2, Spark, WhityBomb;

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
			Debug.Log("e");
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
			Instantiate(skillAttack2, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("o")){
			//Spark.transform.position = this.gameObject.transform.position;
			//Spark.Play();
			Instantiate(Spark, this.gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown("p")){
			//WhityBomb.transform.position = this.gameObject.transform.position;
			//WhityBomb.Play();
			Instantiate(WhityBomb, this.gameObject.transform.position, Quaternion.identity);
		}
	}

	public void SkillButton() {

	}
}
