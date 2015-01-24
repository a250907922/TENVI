using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pick : MonoBehaviour {
	public Button taneButton, kumaButton, lizaButton;
	RectTransform taneRect, kumaRect, lizaRect;
	Vector2 leftPickPos, centerPickPos, rightPickPos;
	public GameObject buttons;
	int pickKind; //ピックの種類数

	void Start () {
		leftPickPos = new Vector2(-165, 125);
		centerPickPos = new Vector2(-165, 125);
		rightPickPos = new Vector2(-165, 125);
		taneRect = taneButton.GetComponent<RectTransform>();
		kumaRect = kumaButton.GetComponent<RectTransform>();
		lizaRect = lizaButton.GetComponent<RectTransform>();
		falseAllButton();
		pickKind = buttons.transform.childCount;
		SetButtons();
		Debug.Log("pickkind: "+pickKind);
	}

	void Update () {
	}

	void falseAllButton() {
		taneButton.gameObject.SetActive(false);
		kumaButton.gameObject.SetActive(false);
		lizaButton.gameObject.SetActive(false);
	}

	int[] GetRandomNums(){
		int[] returnInt = new int[3];
		int tmpInt;
		returnInt[0] = Random.Range(0, pickKind);
		returnInt[1] = Random.Range(0, pickKind);
		returnInt[2] = Random.Range(0, pickKind);
		tmpInt = returnInt[0];
		while(returnInt[0] == tmpInt){
			tmpInt = Random.Range(0, pickKind);
		}
		returnInt[1] = tmpInt;
		while(returnInt[0] == tmpInt || returnInt[1] == tmpInt){
			tmpInt = Random.Range(0, pickKind);
		}
		returnInt[2] = tmpInt;
		Debug.Log(returnInt[0]);
		Debug.Log(returnInt[1]);
		Debug.Log(returnInt[2]);
		return returnInt;
	}

	Button GetButtonFromInt(int num) {
		Button returnButton = taneButton;
		switch(num){
			case 0:
				returnButton = taneButton;
				break;
			case 1:
				returnButton = kumaButton;
				break;
			case 2:
				returnButton = lizaButton;
				break;
		}
		return returnButton;
	}

	void SetButtons() {
		int[] nums = new int[3];
		nums = GetRandomNums();
		Button setLeftButton;
		Button setCenterButton;
		Button setRightButton;
		setLeftButton = GetButtonFromInt(nums[0]);
		setCenterButton = GetButtonFromInt(nums[1]);
		setRightButton = GetButtonFromInt(nums[2]);
		setLeftButton.gameObject.SetActive(true);
		setCenterButton.gameObject.SetActive(true);
		setRightButton.gameObject.SetActive(true);
		setLeftButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-165, 50);
		setCenterButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 50);
		setRightButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(165, 50);
	}

	void NextPick() {
		falseAllButton();
		SetButtons();
	}

	public void TaneButton() {
		NextPick();
	}

	public void KumaButton() {
		NextPick();
	}

	public void LizardButton() {
		NextPick();
	}

}
