using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Pick : MonoBehaviour {
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
	private float[] probs;

	void Start () {
		leftButton.interactable = false;
		centerButton.interactable = false;
		rightButton.interactable = false;
		image.sprite = imageBlue;
		//出る確率
		probs = new float[] {1,1,1,1,1,1,1,1, 3,3,3,3,3};
	}

	void Update () {
		hpText.text = hpPoint.ToString();
		pwrText.text = pwrPoint.ToString();
		defText.text = defPoint.ToString();
		intText.text = intPoint.ToString();
		wisText.text = wisPoint.ToString();
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
		if(pickedPrefab == lizaBlue){
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
