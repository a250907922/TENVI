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

/*
ステージメモ
* タリー
 - 夜の庭
 - 精霊のゆりかご
* アンドラス
 - オオハシの洞窟
 - コーリーのアジト
 - ドクターKのアジト
* シルヴァ
 - キャプテンジャックの飛行船
 - アンタリオン神殿
* ファントム
 - ネクロマンション

ヘルシュの自由運動場（普通） - リブラ
Lv10 オオハシの洞窟（普通） 10～14 リブラ
Lv12 夜の庭(普通) 12～16 タリーB1
選択の森（普通） 12~16 シルヴァ
Lv13 Dr.Kの研究所（普通） 13～16 リブラ
Lv15 ヘルシュの自由運動場(難しい) 15～17 リブラ
オオハシの洞窟（難しい） 15～19 リブラ
Lv17 夜の庭（難しい） 17～21 タリーB1
コーリーのアジト（普通） 17～20 リブラ
Lv18 ヘルシュの自由運動場（超難しい） 18～22 リブラ
Lv20 精霊のゆりかご(普通） 20～23 タリーB1
闘争の門 20～29のみ可能 アイテム
決戦の門 20～29のみ可能 アイテム
Lv21 コーリーのアジト（難しい） 21～24 リブラ
Lv22 夜の庭（超難しい） 22～27 タリーB1
Lv24 精霊のゆりかご(難しい) 24～27 タリーB1
Lv25 コーリーのアジト（超難しい） 25～29 リブラ
Lv28 精霊のゆりかご（超難しい） 28～32 タリーB1
Lv29 ネクロマンション（普通） 29～33 ファントム
Lv30 Dr.Kの研究所（難しい） 30～34 リブラ
水晶鉱山探検門 30～39のみ可能 アイテム
Lv35 キャプテンジャックの飛行船（普通） 35～39 シルヴァ
オオハシの洞窟（超難しい） 35～39 リブラ
Lv39 ネクロマンション（難しい） 39～43 ファントム
Lv40 キャプテンジャックの飛行船（難しい） 40～44 シルヴァ
Lv45 Dr.Kの研究所（超難しい） 45～49 リブラ
Lv50 アンタリオン神殿（普通） 50～??? シルヴァ
Lv55 アンタリオン神殿（難しい） 55～ シルヴァ
Lv60 夜の庭(達人) 60～ タリーB1
Lv60 Dr.Kの研究所（達人） 60～ リブラ
Lv70 アンタリオン神殿（超難しい） 70～ シルヴァ
*/
