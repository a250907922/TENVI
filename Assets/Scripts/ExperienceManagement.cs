using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExperienceManagement : MonoBehaviour {
    public int exp;//現在の経験値
    public int allExp;//総経験値
    public int getExp;//獲得経験値
    //public int upLevel = 1;
    public int playerLevel;
    public int stsPoint;
    public int requiredExp;
    //public GameObject levelUpPrefab;
    public GameObject particlePrefab;
    public GameObject player;
    public GameObject levelUpCanvas;//Canvas
    public Text levelUpText;//レベルアップ時に表示するレベルアップText
    public Image image;//経験値ゲージ画像
    float rectWidth;//経験値ゲージの最大長さ
    float aExpWidth;//1expの経験値ゲージの長さ
    public bool isLevelUp = false;

    void Awake () {
        exp = PlayerPrefs.GetInt("exp"); // 現在の経験値
        allExp = PlayerPrefs.GetInt("allExp");
        playerLevel = PlayerPrefs.GetInt("playerLevel");
        stsPoint = PlayerPrefs.GetInt("stsPoint");
        levelUpCanvas.SetActive(false);
    }

    void Start () {
        player = GameObject.Find ("Player");
        //EXPGUI
        aExpWidth = image.rectTransform.sizeDelta.x/requiredExpForLevelUp();
        rectWidth = aExpWidth * exp;
        image.rectTransform.sizeDelta = new Vector2(rectWidth, image.rectTransform.sizeDelta.y);
    }

    public void ExpManagement (string defeatedCharactor) {
        getExperience(defeatedCharactor);
        ShowExp();
        if (exp >= requiredExpForLevelUp()){ //レベルアップ関数を呼び出す
            LevelUpPlayer();
        }
        //EXP GUI
        rectWidth = aExpWidth * exp;
        image.rectTransform.sizeDelta = new Vector2(rectWidth, image.rectTransform.sizeDelta.y);
    }

    public void getExperience(string defeatedCharactorTag) { //敵を倒したときに経験値獲得のために呼び出す関数
        switch(defeatedCharactorTag) { //倒したキャラごとに獲得経験値を設定
            case "Slime":
                getExp = 1;
                break;
            case "Antallion":
                getExp = 100;
                break;
        }
        exp += getExp;
        allExp += getExp;
        PlayerPrefs.SetInt("exp", exp);
        PlayerPrefs.SetInt("allExp", allExp);
    }

    public void ShowExp () {

        Debug.Log("経験値を"+getExp+"獲得しました。");
    }

    public int requiredExpForLevelUp () { //レベル毎のレベルアップに必要な経験値
        /*
        switch (playerLevel) { //現在のレベル
            case 1:
                requiredExp = 1;
                break;
            case 2:
                requiredExp = 2;
                break;
            case 3:
                requiredExp = 4;
                break;
            case 4:
                requiredExp = 100;
                break;
        }*/
        requiredExp = playerLevel;
        return requiredExp; // レベルアップに必要な経験値
    }

    public void LevelUpPlayer() { //プレイヤーのレベルをあげる。(上げるレベル)
        //Instantiate (levelUpPrefab, player.transform.position, player.transform.rotation);
        StartCoroutine("ShowLevelUp");
        Instantiate (particlePrefab, player.transform.position, player.transform.rotation);
        exp = 0;
        PlayerPrefs.SetInt("exp", exp);
        playerLevel++; //+= upLevel;
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        stsPoint++; //+= upLevel; //ステータスポイントも一つあげる。
        PlayerPrefs.SetInt("stsPoint", stsPoint);
        aExpWidth = rectWidth/requiredExpForLevelUp(); //経験値バーの必要経験値更新
    }

    private IEnumerator ShowLevelUp() {
        levelUpText.transform.Translate(player.transform.position.x, player.transform.position.y, 0);
        levelUpCanvas.SetActive(true);
        isLevelUp = true;
        yield return new WaitForSeconds(1.5f);
        isLevelUp = false;
        levelUpCanvas.SetActive(false);
    }
}
