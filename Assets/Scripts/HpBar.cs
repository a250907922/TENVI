using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour {
  private RectTransform rectTransform;
  public Image image;
  public GameObject gameManager;
  private int hitPoint; //現在のHP
  private int defence;
  private int maxHp; //HP最大値
  private float rectWidth; //HPゲージの長さ
  private float aDamageWidth; //1ダメージで減るHPゲージの長さ
  private bool challenge;

  void Awake() {
    challenge = GameManager.challengeMode;
    if(challenge){
      hitPoint = PlayerPrefs.GetInt("ChalHp");
      defence = PlayerPrefs.GetInt("ChalDef");
    }else{
      hitPoint = PlayerPrefs.GetInt("hitPoint");
      defence = PlayerPrefs.GetInt("defence");
    }
    gameManager = GameObject.Find("GameManager");
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
    if(hitPoint <= 0){
      gameManager.SendMessage("GameOver");
    }
    // HPゲージ UI
    rectWidth = aDamageWidth * hitPoint;
    image.rectTransform.sizeDelta = new Vector2(rectWidth, image.rectTransform.sizeDelta.y);
  }

  private bool Block() {
    bool block = false;
    int randomInt = Random.Range(0,100);
    if(challenge){
      if(defence*5 > randomInt)
        block = true;
    }else{
      if(defence > randomInt)
        block = true;
    }
    return block;
  }
}
