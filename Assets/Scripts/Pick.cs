using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pick : MonoBehaviour {
	//public Button taneButton, kumaButton, lizaButton;
	//RectTransform taneRect, kumaRect, lizaRect;
	//Vector2 leftPickPos, centerPickPos, rightPickPos;
	//public GameObject buttons;
	private int pickKind; //ピックの種類数
	private float dropPosY = 4.0f;
	public GameObject lizaBlue, lizaGreen, lizaRed, lizaPurple, lizaYellow, lizaGray, lizaWhite, lizaPink;
	private GameObject[] prefabs = new GameObject[3];
	private GameObject pickedPrefab;
	public ParticleSystem particle;
	public Button startButton, leftButton, centerButton, rightButton;

	void Start () {
		/*
		leftPickPos = new Vector2(-165, 125);
		centerPickPos = new Vector2(-165, 125);
		rightPickPos = new Vector2(-165, 125);
		taneRect = taneButton.GetComponent<RectTransform>();
		kumaRect = kumaButton.GetComponent<RectTransform>();
		lizaRect = lizaButton.GetComponent<RectTransform>();
		falseAllButton();
		pickKind = buttons.transform.childCount;
		SetButtons();
		*/
		leftButton.interactable = false;
		centerButton.interactable = false;
		rightButton.interactable = false;
		pickKind = 8;
	}

	void Update () {
	}
/*
	void falseAllButton() {
		taneButton.gameObject.SetActive(false);
		kumaButton.gameObject.SetActive(false);
		lizaButton.gameObject.SetActive(false);
	}
*/

	//被らない3つの数字を0以上pickKind未満からランダムで取得
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
		return returnInt;
	}

	GameObject GetPrefabFromInt(int num) {
		GameObject returnPrefab = lizaBlue;
		switch(num){
			case 0:
			returnPrefab = lizaBlue;
			break;
			case 1:
			returnPrefab = lizaGreen;
			break;
			case 2:
			returnPrefab = lizaRed;
			break;
			case 3:
			returnPrefab = lizaPurple;
			break;
			case 4:
			returnPrefab = lizaYellow;
			break;
			case 5:
			returnPrefab = lizaGray;
			break;
			case 6:
			returnPrefab = lizaWhite;
			break;
			case 7:
			returnPrefab = lizaPink;
			break;
		}
		return returnPrefab;
	}

	void InstantiatePrefab() {
		int[] randomInt = new int[3];
		randomInt = GetRandomNums();
		prefabs[0] = Instantiate(GetPrefabFromInt(randomInt[0]), new Vector2(-4, dropPosY), Quaternion.identity) as GameObject;
		prefabs[1] = Instantiate(GetPrefabFromInt(randomInt[1]), new Vector2(0, dropPosY), Quaternion.identity) as GameObject;
		prefabs[2] = Instantiate(GetPrefabFromInt(randomInt[2]), new Vector2(4, dropPosY), Quaternion.identity) as GameObject;
	}
/*
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
*/
	void NextPick() {
		//falseAllButton();
		//SetButtons();
		InstantiatePrefab();
	}

	void ToggleAllButton() {
		leftButton.interactable = !leftButton.interactable;
		centerButton.interactable = !centerButton.interactable;
		rightButton.interactable = !rightButton.interactable;
	}

	public void LeftButton() {
		prefabs[0].layer = 17;
		pickedPrefab = prefabs[0];
		GameObject.Destroy(prefabs[1]);
		GameObject.Destroy(prefabs[2]);
		StartCoroutine("Picked");
		NextPick();
	}

	public void CenterButton() {
		prefabs[1].layer = 17;
		GameObject.Destroy(prefabs[0]);
		pickedPrefab = prefabs[1];
		GameObject.Destroy(prefabs[2]);
		StartCoroutine("Picked");
		NextPick();
	}

	public void RightButton() {
		prefabs[2].layer = 17;
		GameObject.Destroy(prefabs[0]);
		GameObject.Destroy(prefabs[1]);
		pickedPrefab = prefabs[2];
		StartCoroutine("Picked");
		NextPick();
	}

	public void PickStartButton() {
		startButton.gameObject.SetActive(false);
		StartCoroutine("PickStart");
		NextPick();
	}

	private IEnumerator PickStart() {
		yield return new WaitForSeconds(1.0f);
		ToggleAllButton();
		yield break;
	}

	private IEnumerator Picked() {
		ToggleAllButton();
		yield return new WaitForSeconds(0.9f);
		particle.transform.position = pickedPrefab.transform.position;
		particle.Play();
		Destroy(pickedPrefab);
		ToggleAllButton();
		yield break;
	}
}
