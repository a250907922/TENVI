using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
	public int stageNum;
	public int rqSlimeKillNum = 0;
	public int rqHogeKillNum = 0;
	public int rqDraKillNum = 0;
	public int[] needKillEnemys = new int[] {0, 0, 0};//{slime, hoge, dragon}

	void Start () {

	}

	void Update () {

	}

	public int[] GetKillEnemys(int nStage) {
		switch(nStage){
			case 1:
			rqSlimeKillNum = 5;
			break;
			case 2:
			rqSlimeKillNum = 8;
			break;
			case 3:
			rqSlimeKillNum = 10;
			break;
			case 4:
			rqSlimeKillNum = 10;
			break;
			case 5:
			rqSlimeKillNum = 10;
			break;
			case 6:
			rqSlimeKillNum = 0;
			rqDraKillNum = 1;
			break;
		}
		needKillEnemys = new int[] {rqSlimeKillNum, rqHogeKillNum, rqDraKillNum};
		return needKillEnemys;
	}
}
