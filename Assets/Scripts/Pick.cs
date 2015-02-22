using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Pick : MonoBehaviour {
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
	private int pickCount = 0;
	public Text pickCountText;
	private float[] probs;
	private string chalSkill = "default";
	public GameObject leftDropObj, centerDropObj, rightDropObj;

	private GameObject pickEndObjects, statusPanel;

	void Awake() {
		pickEndObjects = GameObject.Find("PickEndObjects");
		pickEndObjects.SetActive(false);
		statusPanel = GameObject.Find("StatusPanel");
		statusPanel.SetActive(false);
		leftButton.gameObject.SetActive(false);
		centerButton.gameObject.SetActive(false);
		rightButton.gameObject.SetActive(false);
		pickCountText.gameObject.SetActive(false);
	}

	void Start () {
		leftButton.interactable = false;
		centerButton.interactable = false;
		rightButton.interactable = false;
		image.sprite = imageBlue;
		//出る確率
		probs = new float[] {2,2,2,2,1,1,1,1, 5,5,5,5,5};
	}

	void Update () {
		hpText.text = hpPoint.ToString();
		pwrText.text = pwrPoint.ToString();
		defText.text = defPoint.ToString();
		intText.text = intPoint.ToString();
		wisText.text = wisPoint.ToString();
		pickCountText.text = pickCount.ToString() + " / 15";
	}

	//被らない3つの数字を0以上pickKind未満からランダムで取得
	int[] GetRandomNums(){
		int[] returnInt = new int[3];
		returnInt[0] = Choose(probs);
		returnInt[1] = Choose(probs);
		returnInt[2] = Choose(probs);
		while(returnInt[0] == returnInt[1]){
			returnInt[1] = Choose(probs);
		}
		while(returnInt[0] == returnInt[2] || returnInt[1] == returnInt[2]){
			returnInt[2] = Choose(probs);
		}
		return returnInt;
	}

	private int Choose(float[] probs){
		float total = 0.0f;
		foreach(float elem in probs) {
			total += elem;
		}
		float randomPoint = Random.value * total;
		for(int i=0; i<probs.Length; i++){
			if(randomPoint < probs[i])
				return i;
			else
				randomPoint -= probs[i];
		}
		return probs.Length - 1;
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
		prefabs[0] = Instantiate(oriPrefab[0], leftDropObj.transform.position, Quaternion.identity) as GameObject;
		prefabs[1] = Instantiate(oriPrefab[1], centerDropObj.transform.position, Quaternion.identity) as GameObject;
		prefabs[2] = Instantiate(oriPrefab[2], rightDropObj.transform.position, Quaternion.identity) as GameObject;
	}

	void NextPick() {
		//falseAllButton();
		//SetButtons();
		InstantiatePrefab();
	}

	void ChangeImage(){
		if(pickedPrefab == lizaBlue){
			chalSkill = "default";
			if(image.sprite == imageBlue){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imageBlue;
		}
		if(pickedPrefab == lizaGreen){
			chalSkill = "enegyBlast";
			if(image.sprite == imageGreen){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imageGreen;
		}
		if(pickedPrefab == lizaRed){
			chalSkill = "fireShot";
			if(image.sprite == imageRed){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imageRed;
		}
		if(pickedPrefab == lizaPurple){
			chalSkill = "erekiBall";
			if(image.sprite == imagePurple){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imagePurple;
		}
		if(pickedPrefab == lizaYellow){
			chalSkill = "skillAttack2";
			if(image.sprite == imageYellow){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imageYellow;
		}
		if(pickedPrefab == lizaGray){
			chalSkill = "whityBomb2";
			if(image.sprite == imageGray){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imageGray;
		}
		if(pickedPrefab == lizaWhite){
			chalSkill = "spark";
			if(image.sprite == imageWhite){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imageWhite;
		}
		if(pickedPrefab == lizaPink){
			chalSkill = "skillAttack";
			if(image.sprite == imagePink){
				hpPoint++;
				pwrPoint++;
				defPoint++;
				intPoint++;
				wisPoint++;
			}
			image.sprite = imagePink;
		}
		if(pickedPrefab == hp)
			hpPoint++;
		if(pickedPrefab == power)
			pwrPoint++;
		if(pickedPrefab == defence)
			defPoint++;
		if(pickedPrefab == intelligence)
			intPoint++;
		if(pickedPrefab == wisdom)
			wisPoint++;
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
	}

	public void CenterButton() {
		prefabs[1].layer = 17;
		pickedPrefab = oriPrefab[1];
		GameObject.Destroy(prefabs[0]);
		destroyPrefab = prefabs[1];
		GameObject.Destroy(prefabs[2]);
		StartCoroutine("Picked");
	}

	public void RightButton() {
		prefabs[2].layer = 17;
		pickedPrefab = oriPrefab[2];
		GameObject.Destroy(prefabs[0]);
		GameObject.Destroy(prefabs[1]);
		destroyPrefab = prefabs[2];
		StartCoroutine("Picked");
	}

	public void PickStartButton() {
		startButton.gameObject.SetActive(false);
		StartCoroutine("PickStart");
		NextPick();
	}

	private IEnumerator PickStart() {
		statusPanel.SetActive(true);
		leftButton.gameObject.SetActive(true);
		centerButton.gameObject.SetActive(true);
		rightButton.gameObject.SetActive(true);
		pickCountText.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.0f);
		ToggleAllButton();
		yield break;
	}

	private IEnumerator Picked() {
		ToggleAllButton();
		pickCount++;
		yield return new WaitForSeconds(0.9f);
		particle.transform.position = destroyPrefab.transform.position;
		particle.Play();
		Destroy(destroyPrefab);
		ChangeImage();
		if(pickCount == 15){
			PickEnd();
		}else{
			ToggleAllButton();
			NextPick();
		}
		yield break;
	}

	private void PickEnd(){
		leftButton.gameObject.SetActive(false);
		centerButton.gameObject.SetActive(false);
		rightButton.gameObject.SetActive(false);
		pickEndObjects.SetActive(true);
	}

	public void PlayButton(){
		Application.LoadLevel("Play");
		GameManager.challengeMode = true;
	}

	void OnDestroy(){
		PlayerPrefs.SetInt("ChalHp", hpPoint);
		PlayerPrefs.SetInt("ChalPwr", pwrPoint);
		PlayerPrefs.SetInt("ChalDef", defPoint);
		PlayerPrefs.SetInt("ChalInt", intPoint);
		PlayerPrefs.SetInt("ChalWis", wisPoint);
		PlayerPrefs.SetString("ChalSkill", chalSkill);
	}
}
