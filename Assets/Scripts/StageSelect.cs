using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelect : MonoBehaviour {
	public Button button1, button2, button3, button4, button5, button6;
	public bool clrStg1, clrStg2, clrStg3, clrStg4, clrStg5, clrStg6 = false;
	public static int stageNum;
	private int clearStage;

	void Start () {
		clearStage = PlayerPrefs.GetInt("clearStage");
		Debug.Log("クリアしているステージは"+clearStage.ToString());
		if(clearStage < 1)
			button2.interactable = false;
		else
			button2.interactable = true;
		if(clearStage < 2)
			button3.interactable = false;
		else
			button3.interactable = true;
		if(clearStage < 3)
			button4.interactable = false;
		else
			button4.interactable = true;
		if(clearStage < 4)
			button5.interactable = false;
		else
			button5.interactable = true;
		if(clearStage < 5)
			button6.interactable = false;
		else
			button6.interactable = true;

	}

	void Update () {
	}

	public void Stage1Button() {
		stageNum = 1;
		Application.LoadLevel("Play");
		PlayerPrefs.SetInt("challengeMode", 0);//false
	}
	public void Stage2Button() {
		stageNum = 2;
		Application.LoadLevel("Play");
		PlayerPrefs.SetInt("challengeMode", 0);//false
	}
	public void Stage3Button() {
		stageNum = 3;
		Application.LoadLevel("Play");
		PlayerPrefs.SetInt("challengeMode", 0);//false
	}
	public void Stage4Button() {
		stageNum = 4;
		Application.LoadLevel("Play");
		PlayerPrefs.SetInt("challengeMode", 0);//false
	}
	public void Stage5Button() {
		stageNum = 5;Application.LoadLevel("Play");
		PlayerPrefs.SetInt("challengeMode", 0);//false
	}
	public void Stage6Button() {
		stageNum = 6;
		Application.LoadLevel("Play");
		PlayerPrefs.SetInt("challengeMode", 0);//false
	}
}
