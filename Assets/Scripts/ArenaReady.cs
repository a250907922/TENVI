using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArenaReady : MonoBehaviour {
	public Image image;
	public Sprite imageBlue, imageGreen, imageRed, imagePurple, imageYellow, imageGray, imageWhite, imagePink;
	private int chalHp, chalPwr, chalDef, chalInt, chalWis;
	private string chalSkill;
	public Text hpText, pwrText, defText, intText, wisText;
	public Text stageText;
	public int arenaClearStage;

	void Awake() {
		arenaClearStage = PlayerPrefs.GetInt("ArenaClearStage");
		chalHp = PlayerPrefs.GetInt("ChalHp");
		chalPwr = PlayerPrefs.GetInt("ChalPwr");
		chalDef = PlayerPrefs.GetInt("ChalDef");
		chalInt = PlayerPrefs.GetInt("ChalInt");
		chalWis = PlayerPrefs.GetInt("ChalWis");
		chalSkill = PlayerPrefs.GetString("ChalSkill");
	}

	void Start() {
		stageText.text = "ステージ"+(arenaClearStage+1).ToString();
		hpText.text = chalHp.ToString();
		pwrText.text = chalPwr.ToString();
		defText.text = chalDef.ToString();
		intText.text = chalInt.ToString();
		wisText.text = chalWis.ToString();

		if(chalSkill=="default")
			image.sprite = imageBlue;
		else if(chalSkill=="enegyBlast")
			image.sprite = imageGreen;
		else if(chalSkill=="fireShot")
			image.sprite = imageRed;
		else if(chalSkill=="erekiBall")
			image.sprite = imagePurple;
		else if(chalSkill=="skillAttack2")
			image.sprite = imageYellow;
		else if(chalSkill=="whityBomb2")
			image.sprite = imageGray;
		else if(chalSkill=="spark")
			image.sprite = imageWhite;
		else if(chalSkill=="skillAttack")
			image.sprite = imagePink;
	}

	public void ArenaStartButton(){
		Application.LoadLevel("Arena");
	}
}
