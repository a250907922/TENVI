using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Home : MonoBehaviour {
	private Button challengeConfirmButton;
	private Text coinText;
	public int coin;

	void Awake() {
		coinText = GameObject.Find("CoinText").GetComponent<Text>();
		coin = PlayerPrefs.GetInt("Coin");
		coinText.text = coin.ToString();
		challengeConfirmButton = GameObject.Find("ChallengeConfirmButton").GetComponent<Button>();
		challengeConfirmButton.gameObject.SetActive(false);
	}

	void Start () {

	}

	void Update () {

	}

	public void ChallengeButton() {
		if(coin>5){
			coin -= 5;
			PlayerPrefs.SetInt("Coin", coin);
			Application.LoadLevel("Pick");
		}else{
			challengeConfirmButton.gameObject.SetActive(true);
		}
	}

	public void ChallengeConfirmButton() {
		challengeConfirmButton.gameObject.SetActive(false);
	}
}
