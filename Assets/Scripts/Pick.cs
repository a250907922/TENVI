using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pick : MonoBehaviour {
	private int pickKind; //ピックの種類数
	private float dropPosY = 4.0f;
	public GameObject lizaBlue, lizaGreen, lizaRed, lizaPurple, lizaYellow, lizaGray, lizaWhite, lizaPink;
	public GameObject hp, power, defence, intelligence, wisdom;
	public Image image;
	public Sprite imageBlue, imageGreen, imageRed, imagePurple, imageYellow, imageGray, imageWhite, imagePink;
	private GameObject[] oriPrefab = new GameObject[3];
	private GameObject[] prefabs = new GameObject[3];
	private GameObject destroyPrefab, pickedPrefab;
	public ParticleSystem particle;
	public Button startButton, leftButton, centerButton, rightButton;
	private int hpPoint, pwrPoint, defPoint, intPoint, wisPoint = 0;
	public Text hpText, pwrText, defText, intText, wisText;

	void Start () {
		leftButton.interactable = false;
		centerButton.interactable = false;
		rightButton.interactable = false;
		pickKind = 13;//case + 1
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
			case 8:
			returnPrefab = hp;
			break;
			case 9:
			returnPrefab = power;
			break;
			case 10:
			returnPrefab = defence;
			break;
			case 11:
			returnPrefab = intelligence;
			break;
			case 12:
			returnPrefab = wisdom;
			break;
		}
		return returnPrefab;
	}

	void InstantiatePrefab() {
		int[] randomInt = new int[3];
		randomInt = GetRandomNums();
		oriPrefab[0] = GetPrefabFromInt(randomInt[0]);
		oriPrefab[1] = GetPrefabFromInt(randomInt[1]);
		oriPrefab[2] = GetPrefabFromInt(randomInt[2]);
		prefabs[0] = Instantiate(oriPrefab[0], new Vector2(-3, dropPosY), Quaternion.identity) as GameObject;
		prefabs[1] = Instantiate(oriPrefab[1], new Vector2(0, dropPosY), Quaternion.identity) as GameObject;
		prefabs[2] = Instantiate(oriPrefab[2], new Vector2(3, dropPosY), Quaternion.identity) as GameObject;
	}

	void NextPick() {
		//falseAllButton();
		//SetButtons();
		InstantiatePrefab();
	}

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
		if(pickedPrefab == hp){
			hpPoint++;
			hpText.text = hpPoint.ToString();
		}
		if(pickedPrefab == power){
			pwrPoint++;
			pwrText.text = pwrPoint.ToString();
		}
		if(pickedPrefab == defence){
			defPoint++;
			defText.text = defPoint.ToString();
		}
		if(pickedPrefab == intelligence){
			intPoint++;
			intText.text = intPoint.ToString();
		}
		if(pickedPrefab == wisdom){
			wisPoint++;
			wisText.text = wisPoint.ToString();
		}
	}

	void ToggleAllButton() {
		leftButton.interactable = !leftButton.interactable;
		centerButton.interactable = !centerButton.interactable;
		rightButton.interactable = !rightButton.interactable;
	}

	public void LeftButton() {
		prefabs[0].layer = 17;
		pickedPrefab = oriPrefab[0];
		destroyPrefab = prefabs[0];
		GameObject.Destroy(prefabs[1]);
		GameObject.Destroy(prefabs[2]);
		StartCoroutine("Picked");
		NextPick();
	}

	public void CenterButton() {
		prefabs[1].layer = 17;
		pickedPrefab = oriPrefab[1];
		GameObject.Destroy(prefabs[0]);
		destroyPrefab = prefabs[1];
		GameObject.Destroy(prefabs[2]);
		StartCoroutine("Picked");
		NextPick();
	}

	public void RightButton() {
		prefabs[2].layer = 17;
		pickedPrefab = oriPrefab[2];
		GameObject.Destroy(prefabs[0]);
		GameObject.Destroy(prefabs[1]);
		destroyPrefab = prefabs[2];
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
		particle.transform.position = destroyPrefab.transform.position;
		particle.Play();
		Destroy(destroyPrefab);
		ChangeImage();
		ToggleAllButton();
		yield break;
	}
}
