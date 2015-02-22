using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelect : MonoBehaviour {
	public Button button1, button2, button3, button4, button5, button6;
	public bool clrStg1, clrStg2, clrStg3, clrStg4, clrStg5, clrStg6 = false;
	public static int stageNum;

	void Start () {
		if(!clrStg1)
			button2.interactable = false;
		if(!clrStg2)
			button3.interactable = false;
		if(!clrStg3)
			button4.interactable = false;
		if(!clrStg4)
			button5.interactable = false;
		if(!clrStg5)
			button6.interactable = false;
	}

	void Update () {
	}

	public void UnlockStage(int clrStg) { //引数にクリアしたステージ
		switch(clrStg){
			case 1:
			clrStg1 = true;
			break;
			case 2:
			clrStg2 = true;
			break;
			case 3:
			clrStg3 = true;
			break;
			case 4:
			clrStg4 = true;
			break;
			case 5:
			clrStg5 = true;
			break;
			case 6:
			clrStg6 = true;
			break;
		}
		ChangeStageUI();
	}

	public void ChangeStageUI() {//クリアしたステージの次のステージのボタンを押せるように変更
		if(clrStg1)
			button2.interactable = true;
		if(clrStg2)
			button3.interactable = true;
		if(clrStg3)
			button4.interactable = true;
		if(clrStg4)
			button5.interactable = true;
		if(clrStg5)
			button6.interactable = true;
	}

	public void Stage1Button() {
		stageNum = 1;
		Application.LoadLevel("Play");
		GameManager.challengeMode = false;
	}
	public void Stage2Button() {
		stageNum = 2;
	}
	public void Stage3Button() {
		stageNum = 3;
	}
	public void Stage4Button() {
		stageNum = 4;
	}
	public void Stage5Button() {
		stageNum = 5;
	}
	public void Stage6Button() {
		stageNum = 6;
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
