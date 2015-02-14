using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour {
    private RectTransform rectTransform;
    public Image image;
    public GameObject gameManager;
    public int hitPoint; //現在のHP
    private int maxHp; //HP最大値
    private float rectWidth; //HPゲージの長さ
    private float aDamageWidth; //1ダメージで減るHPゲージの長さ

    void Awake() {
        hitPoint = PlayerPrefs.GetInt("hitPoint");
        gameManager = GameObject.Find("GameManager");
    }

	void Start () {
        maxHp = hitPoint;
        rectWidth = image.rectTransform.sizeDelta.x; //HPゲージの長さ取得
        aDamageWidth = rectWidth/maxHp;
	}

	void Update () {
	}

    void OnDamage(int damage)
    {
        hitPoint -= damage;
        Debug.Log(hitPoint);
        if(hitPoint <= 0){ //HPが0以下になったら
            gameManager.SendMessage("GameOver"); //ゲームオーバー
        }
        /* HPゲージ UI */
        rectWidth = aDamageWidth * hitPoint;
        image.rectTransform.sizeDelta = new Vector2(rectWidth, image.rectTransform.sizeDelta.y);
    }
}
