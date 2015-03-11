using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour {
  private RectTransform rectTransform;
  public Image image;
  GameManager gameManager;
  private int hitPoint; //現在のHP
  private int defence;
  private int maxHp; //HP最大値
  private float rectWidth; //HPゲージの長さ
  private float aDamageWidth; //1ダメージで減るHPゲージの長さ
  private int challengeMode;

  void Awake() {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    challengeMode = PlayerPrefs.GetInt("challengeMode");
    if(challengeMode == 1){
      hitPoint = PlayerPrefs.GetInt("ChalHp");
      defence = PlayerPrefs.GetInt("ChalDef");
    }else{
      hitPoint = PlayerPrefs.GetInt("hitPoint") + 5;
      defence = PlayerPrefs.GetInt("defence");
    }
  }

  void Start () {
    maxHp = hitPoint;
    rectWidth = image.rectTransform.sizeDelta.x; //HPゲージの長さ取得
    aDamageWidth = rectWidth/maxHp;
  }

  void Update () {
  }

  void OnDamage(int damage){
    //防御力計算
    /*
    if(damage > defence)
    damage -= defence;
    else
    damage = 0;
    */
    if(Block())
      damage = 0;

    //ダメージ
    hitPoint -= damage;
    //HP0以下になるとゲームオーバー
    if(hitPoint <= 0 && !gameManager.IsStageClear()){
      gameManager.GameOver();
    }
    // HPゲージ UI
    rectWidth = aDamageWidth * hitPoint;
    image.rectTransform.sizeDelta = new Vector2(rectWidth, image.rectTransform.sizeDelta.y);
  }

  private bool Block() {
    bool block = false;
    int randomInt = Random.Range(0,100);
    if(challengeMode == 1){
      if(defence*5 > randomInt)
        block = true;
    }else{
      if(defence > randomInt)
        block = true;
    }
    return block;
  }
}
