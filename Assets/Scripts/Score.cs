using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int nowScore = 0;
	
	void Update () {
		this.guiText.text =  " SCORE:" + nowScore.ToString();
	}

	public void UpdateScore(int getScore){
		nowScore += getScore;
	}
}