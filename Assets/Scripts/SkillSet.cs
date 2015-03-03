using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillSet : MonoBehaviour {
	public string skillName;
	public Button button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12;

	void Start () {
		skillName = PlayerPrefs.GetString("skill");
	}

	void Update () {

	}

	public void Skill1(){
		PlayerPrefs.SetString("skill", "default");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill2(){
		PlayerPrefs.SetString("skill", "energyBlast");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill3(){
		PlayerPrefs.SetString("skill", "erekiBall");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill4(){
		PlayerPrefs.SetString("skill", "erekiBall2");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill5(){
		PlayerPrefs.SetString("skill", "fireShot");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill6(){
		PlayerPrefs.SetString("skill", "frameBall");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill7(){
		PlayerPrefs.SetString("skill", "greenCore");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill8(){
		PlayerPrefs.SetString("skill", "skillAttack");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill9(){
		PlayerPrefs.SetString("skill", "skillAttack2");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill10(){
		PlayerPrefs.SetString("skill", "spark");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill11(){
		PlayerPrefs.SetString("skill", "whityBomb");
		skillName = PlayerPrefs.GetString("skill");
	}
	public void Skill12(){
		PlayerPrefs.SetString("skill", "whityBomb2");
		skillName = PlayerPrefs.GetString("skill");
	}
}
