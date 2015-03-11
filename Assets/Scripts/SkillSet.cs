using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillSet : MonoBehaviour {
	public string skillName;
	public int playerLevel;
	public Button button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12;
	public Text button1text, button2text, button3text, button4text, button5text, button6text, button7text, button8text, button9text, button10text, button11text, button12text;
	public int skill1RequireLevel, skill2RequireLevel, skill3RequireLevel, skill4RequireLevel, skill5RequireLevel, skill6RequireLevel, skill7RequireLevel, skill8RequireLevel, skill9RequireLevel, skill10RequireLevel, skill11RequireLevel, skill12RequireLevel;

	void Start () {
		skillName = PlayerPrefs.GetString("skill");
		playerLevel = PlayerPrefs.GetInt("playerLevel");
		button1text = GameObject.Find("Button1").transform.FindChild("Button1Text").gameObject.GetComponent<Text>();
		button2text = GameObject.Find("Button2").transform.FindChild("Button2Text").gameObject.GetComponent<Text>();
		button3text = GameObject.Find("Button3").transform.FindChild("Button3Text").gameObject.GetComponent<Text>();
		button4text = GameObject.Find("Button4").transform.FindChild("Button4Text").gameObject.GetComponent<Text>();
		button5text = GameObject.Find("Button5").transform.FindChild("Button5Text").gameObject.GetComponent<Text>();
		button6text = GameObject.Find("Button6").transform.FindChild("Button6Text").gameObject.GetComponent<Text>();
		button7text = GameObject.Find("Button7").transform.FindChild("Button7Text").gameObject.GetComponent<Text>();
		button8text = GameObject.Find("Button8").transform.FindChild("Button8Text").gameObject.GetComponent<Text>();
		button9text = GameObject.Find("Button9").transform.FindChild("Button9Text").gameObject.GetComponent<Text>();
		button10text = GameObject.Find("Button10").transform.FindChild("Button10Text").gameObject.GetComponent<Text>();
		button11text = GameObject.Find("Button11").transform.FindChild("Button11Text").gameObject.GetComponent<Text>();
		button12text = GameObject.Find("Button12").transform.FindChild("Button12Text").gameObject.GetComponent<Text>();
		skill1RequireLevel = 1;
		skill2RequireLevel = 2;
		skill3RequireLevel = 4;
		skill4RequireLevel = 6;
		skill5RequireLevel = 8;
		skill6RequireLevel = 10;
		skill7RequireLevel = 13;
		skill8RequireLevel = 16;
		skill9RequireLevel = 19;
		skill10RequireLevel = 22;
		skill11RequireLevel = 26;
		skill12RequireLevel = 30;
		if(playerLevel < skill1RequireLevel)
			button1.interactable = false;
		if(playerLevel < skill2RequireLevel)
			button2.interactable = false;
		if(playerLevel < skill3RequireLevel)
			button3.interactable = false;
		if(playerLevel < skill4RequireLevel)
			button4.interactable = false;
		if(playerLevel < skill5RequireLevel)
			button5.interactable = false;
		if(playerLevel < skill6RequireLevel)
			button6.interactable = false;
		if(playerLevel < skill7RequireLevel)
			button7.interactable = false;
		if(playerLevel < skill8RequireLevel)
			button8.interactable = false;
		if(playerLevel < skill9RequireLevel)
			button9.interactable = false;
		if(playerLevel < skill10RequireLevel)
			button10.interactable = false;
		if(playerLevel < skill11RequireLevel)
			button11.interactable = false;
		if(playerLevel < skill12RequireLevel)
			button12.interactable = false;
		button1text.text = "レベル" + skill1RequireLevel.ToString();
		button2text.text = "レベル" + skill2RequireLevel.ToString();
		button3text.text = "レベル" + skill3RequireLevel.ToString();
		button4text.text = "レベル" + skill4RequireLevel.ToString();
		button5text.text = "レベル" + skill5RequireLevel.ToString();
		button6text.text = "レベル" + skill6RequireLevel.ToString();
		button7text.text = "レベル" + skill7RequireLevel.ToString();
		button8text.text = "レベル" + skill8RequireLevel.ToString();
		button9text.text = "レベル" + skill9RequireLevel.ToString();
		button10text.text = "レベル" + skill10RequireLevel.ToString();
		button11text.text = "レベル" + skill11RequireLevel.ToString();
		button12text.text = "レベル" + skill12RequireLevel.ToString();
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
