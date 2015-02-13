using UnityEngine;
using System.Collections;

public class SkillSet : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Skill1(){
		PlayerPrefs.SetString("skill", "default");
	}
	public void Skill2(){
		PlayerPrefs.SetString("skill", "energyBlast");
	}
	public void Skill3(){
		PlayerPrefs.SetString("skill", "erekiBall");
	}
	public void Skill4(){
		PlayerPrefs.SetString("skill", "erekiBall2");
	}
	public void Skill5(){
		PlayerPrefs.SetString("skill", "fireShot");
	}
	public void Skill6(){
		PlayerPrefs.SetString("skill", "frameBall");
	}
	public void Skill7(){
		PlayerPrefs.SetString("skill", "greenCore");
	}
	public void Skill8(){
		PlayerPrefs.SetString("skill", "skillAttack");
	}
	public void Skill9(){
		PlayerPrefs.SetString("skill", "skillAttack2");
	}
	public void Skill10(){
		PlayerPrefs.SetString("skill", "spark");
	}
	public void Skill11(){
		PlayerPrefs.SetString("skill", "whityBomb");
	}
	public void Skill12(){
		PlayerPrefs.SetString("skill", "whityBomb2");
	}
}
