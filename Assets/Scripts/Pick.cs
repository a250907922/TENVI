using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pick : MonoBehaviour {
	private int pickKind; //ピックの種類数
	private float dropPosY = 4.0f;
	public GameObject lizaBlue, lizaGreen, lizaRed, lizaPurple, lizaYellow, lizaGray, lizaWhite, lizaPink;
	public Image image;
	public Sprite imageBlue, imageGreen, imageRed, imagePurple, imageYellow, imageGray, imageWhite, imagePink;
	private GameObject[] prefabs = new GameObject[3];
	private GameObject pickedPrefab;
	public ParticleSystem particle;
	public Button startButton, leftButton, centerButton, rightButton;

	void Start () {
		leftButton.interactable = false;
		centerButton.interactable = false;
		rightButton.interactable = false;
		pickKind = 8;
	}

	void Update () {
	}

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
		prefabs[0] = Instantiate(GetPrefabFromInt(randomInt[0]), new Vector2(-3, dropPosY), Quaternion.identity) as GameObject;
		prefabs[1] = Instantiate(GetPrefabFromInt(randomInt[1]), new Vector2(0, dropPosY), Quaternion.identity) as GameObject;
		prefabs[2] = Instantiate(GetPrefabFromInt(randomInt[2]), new Vector2(3, dropPosY), Quaternion.identity) as GameObject;
	}

	void NextPick() {
		//falseAllButton();
		//SetButtons();
		InstantiatePrefab();
	}

	//TODO Instantiateしてるから修正
	void ChangeImage(){
		if(pickedPrefab == lizaBlue)
			image.sprite = imageBlue;
		if(pickedPrefab == lizaGreen)
			image.sprite = imageGreen;
		if(pickedPrefab == lizaRed)
			image.sprite = imageRed;
		if(pickedPrefab == lizaPurple)
			image.sprite = imagePurple;
		if(pickedPrefab == lizaYellow)
			image.sprite = imageYellow;
		if(pickedPrefab == lizaGray)
			image.sprite = imageGray;
		if(pickedPrefab == lizaWhite)
			image.sprite = imageWhite;
		if(pickedPrefab == lizaPink)
			image.sprite = imagePink;
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
		ChangeImage();
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
