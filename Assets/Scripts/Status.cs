using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Status : MonoBehaviour {

    public int playerLevel, skillPoint;
    public int stsPoint, hpLevel, pwrLevel, defLevel, intLevel, wisLevel;
    public int hitPoint, power, defence, intelligence, wisdom;
    public int exp;
    public Text playerLevelText, stsPointText, hpText, pwrText, defText, intText, wisText;
    /*
    private float stsWd, stsHt; //外側の枠
    private float stsLeft, stsUp; //外側の枠の左と上
    private float abiWd, abiHt; //ステータス1個分の幅と高さ
    */


    void Awake() {
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
        /*
        stsWd = Screen.width -200;
        stsHt= Screen.height - 100;
        stsLeft = Screen.width/2 - stsWd/2;
        stsUp = Screen.height/2 - stsHt/2;
        abiWd = stsWd/6;
        abiHt = stsHt/6;
        */
    }

    void Update() {
        stsPointText.text = "STATUS POINT " + stsPoint.ToString();
        hpText.text = hpLevel.ToString();
        pwrText.text = pwrLevel.ToString();
        defText.text = defLevel.ToString();
        intText.text = intLevel.ToString();
        wisText.text = wisLevel.ToString();
    }

    void OnDestroy() {
        SetHitPoint();
        SetPower();
        SetDefence();
        SetIntelligence();
        SetWisdom();
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


    /* GUI */
    /*
    void OnGUI () {
        // 外枠のグループ
        GUI.BeginGroup (new Rect (stsLeft, stsUp, stsWd, stsHt)); // 真ん中にstsWd*stsHtのグループ
        GUI.Box (new Rect (0,0, stsWd, stsHt), "Level");
        GUI.Label (new Rect (stsWd/2+50, 0, 50, 20), playerLevel.ToString() + " (" + exp.ToString() + "/" + playerLevel.ToString() + ")");

        // ステータスのグループ
        GUI.BeginGroup (new Rect (stsWd/12, stsHt*2/3 + 30, stsWd - stsWd/6, abiHt));
        GUI.Box (new Rect (0,0,stsWd-stsWd/6,abiHt), "Status Point");
        GUI.Box (new Rect (stsWd/2, 5, 50, 20), stsPoint.ToString());

        // HP
        GUI.BeginGroup (new Rect (0, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "HP");
        GUI.Box (new Rect (20,30,50,30), hpLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            hpLevel++;
            PlayerPrefs.SetInt("hpLevel", hpLevel);
        }
        GUI.EndGroup ();

        // Power
        GUI.BeginGroup (new Rect (abiWd, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Power");
        GUI.Box (new Rect (20,30,50,30), pwrLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            pwrLevel++;
            PlayerPrefs.SetInt("pwrLevel", pwrLevel);
        }
        GUI.EndGroup ();

        // Defence
        GUI.BeginGroup (new Rect (abiWd*2, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Defence");
        GUI.Box (new Rect (20,30,50,30), defLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            defLevel++;
            PlayerPrefs.SetInt("defLevel", defLevel);
        }
        GUI.EndGroup ();

        // Intelligence
        GUI.BeginGroup (new Rect (abiWd*3, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Intelligence");
        GUI.Box (new Rect (20,30,50,30), intLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            intLevel++;
            PlayerPrefs.SetInt("intLevel", intLevel);
        }
        GUI.EndGroup ();

        // Wisdom
        GUI.BeginGroup (new Rect (abiWd*4, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Wisdom");
        GUI.Box (new Rect (20,30,50,30), wisLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            wisLevel++;
            PlayerPrefs.SetInt("wisLevel", wisLevel);
        }
        GUI.EndGroup ();
        GUI.EndGroup ();

        // Reset
        if (GUI.Button (new Rect(10, 70, 80, 30), "Reset")) {
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

        GUI.EndGroup ();
    }
    */

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
