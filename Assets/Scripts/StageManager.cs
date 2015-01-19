using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
	public int stageNum;
	public int slimeKillNum = 0;
	public int hogeKillNum = 0;
	public int draKillNum = 0;
	public int[] needKillEnemys = new int[] {0, 0, 0};//{slime, hoge, dragon}

	void Start () {

	}

	void Update () {

	}

	public int[] KillEnemyTable(int nStage) {
		switch(nStage){
			case 1:
			slimeKillNum = 5;
			break;
			case 2:
			slimeKillNum = 8;
			break;
			case 3:
			slimeKillNum = 10;
			break;
			case 4:
			slimeKillNum = 10;
			break;
			case 5:
			slimeKillNum = 10;
			break;
			case 6:
			slimeKillNum = 10;
			break;
		}
		needKillEnemys = new int[] {slimeKillNum, hogeKillNum, draKillNum};
		return needKillEnemys;
	}
}
