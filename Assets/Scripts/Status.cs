using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Status : MonoBehaviour {

    public int playerLevel, skillPoint;
    public int stsPoint, hpLevel, pwrLevel, defLevel, intLevel, wisLevel;
    public int hitPoint, power, defence, intelligence, wisdom;
    public int exp;
    public Text playerLevelText, stsPointText, hpText, pwrText, defText, intText, wisText;
    public Button hpButton, pwrButton, defButton, intButton, wisButton;
    public Button skillSetButton;

    void Awake() {
      skillSetButton.interactable = false;
        playerLevel = PlayerPrefs.GetInt("playerLevel"); //プレイヤのレベル
        stsPoint = PlayerPrefs.GetInt("stsPoint"); //残りステータスポイント
        hpLevel = PlayerPrefs.GetInt("hpLevel"); //HPに振ったポイント
        pwrLevel = PlayerPrefs.GetInt("pwrLevel"); //Powerに振ったポイント
        defLevel = PlayerPrefs.GetInt("defLevel"); //Defenceに振ったポイント
        intLevel = PlayerPrefs.GetInt("intLevel"); //Intelligenceに振ったポイント
        wisLevel = PlayerPrefs.GetInt("wisLevel"); //Wisdomに振ったポイント
        hitPoint = PlayerPrefs.GetInt("hitPoint"); //HPの実数値
        power = PlayerPrefs.GetInt("power"); //Powerの実数値
        defence = PlayerPrefs.GetInt("defence"); //Defenceの実数値
        intelligence = PlayerPrefs.GetInt("intelligence");//Intelligenceの実数値
        wisdom = PlayerPrefs.GetInt("wisdom");//Wisdomの実数値
        exp = PlayerPrefs.GetInt("exp");
    }

    void Start() {
        playerLevelText.text = "LEVEL " + playerLevel.ToString();
    }

    void Update() {
        stsPointText.text = "STATUS POINT " + stsPoint.ToString();
        hpText.text = hpLevel.ToString();
        pwrText.text = pwrLevel.ToString();
        defText.text = defLevel.ToString();
        intText.text = intLevel.ToString();
        wisText.text = wisLevel.ToString();

        if(stsPoint <= 0){
          hpButton.interactable = false;
          pwrButton.interactable = false;
          defButton.interactable = false;
          intButton.interactable = false;
          wisButton.interactable = false;
        }else{
          hpButton.interactable = true;
          pwrButton.interactable = true;
          defButton.interactable = true;
          intButton.interactable = true;
          wisButton.interactable = true;
        }
    }

    void OnDestroy() {
        SetHitPoint();
        SetPower();
        SetDefence();
        SetIntelligence();
        SetWisdom();
        SetStatusPoint();
    }
/*
    void GetHitPoint() {

    }

    void GetPower() {

    }

    void GetDefence() {

    }

    void GetIntelligence() {

    }

    void GetWisdom() {

    }
    */

    void SetHitPoint() {
        hitPoint = playerLevel + hpLevel;
        PlayerPrefs.SetInt("hitPoint", hitPoint);
    }

    void SetPower() {
        power = playerLevel + pwrLevel;
        PlayerPrefs.SetInt("power", power);
    }

    void SetDefence() {
        defence = playerLevel + defLevel;
        PlayerPrefs.SetInt("defence", defence);
    }

    void SetIntelligence() {
        intelligence = playerLevel + intLevel;
        PlayerPrefs.SetInt("intelligence", intelligence);
    }

    void SetWisdom() {
        wisdom = playerLevel + wisLevel;
        PlayerPrefs.SetInt("wisdom", wisdom);
    }

    void SetStatusPoint() {
        PlayerPrefs.SetInt("stsPoint", stsPoint);
    }

    public void ClickHp() {
        hpLevel++;
        stsPoint--;
        PlayerPrefs.SetInt("hpLevel", hpLevel);
        //PlayerPrefs.SetInt("stsPoint" stsPoint);
    }
    public void ClickPower() {
        pwrLevel++;
        stsPoint--;
        PlayerPrefs.SetInt("pwrLevel", pwrLevel);
        //PlayerPrefs.SetInt("stsPoint" stsPoint);
    }
    public void ClickDefence() {
        defLevel++;
        stsPoint--;
        PlayerPrefs.SetInt("defLevel", defLevel);
        //PlayerPrefs.SetInt("stsPoint" stsPoint);
    }
    public void ClickIntelligence() {
        intLevel++;
        stsPoint--;
        PlayerPrefs.SetInt("intLevel", intLevel);
        //PlayerPrefs.SetInt("stsPoint" stsPoint);
    }
    public void ClickWisdom() {
        wisLevel++;
        stsPoint--;
        PlayerPrefs.SetInt("wisLevel", wisLevel);
        //PlayerPrefs.SetInt("stsPoint" stsPoint);
    }

    public void OnReset() {
        playerLevel = 1;
        stsPoint = 0;
        hpLevel = 0;
        pwrLevel = 0;
        defLevel = 0;
        intLevel = 0;
        wisLevel = 0;
        PlayerPrefs.SetInt("playerLevel", 1);
        PlayerPrefs.SetInt("stsPoint", 0);
        PlayerPrefs.SetInt("hpLevel", 0);
        PlayerPrefs.SetInt("pwrLevel", 0);
        PlayerPrefs.SetInt("defLevel", 0);
        PlayerPrefs.SetInt("intLevel", 0);
        PlayerPrefs.SetInt("wisLevel", 0);
        PlayerPrefs.SetInt("exp", 0);
        PlayerPrefs.SetInt("allExp", 0);
    }
}
