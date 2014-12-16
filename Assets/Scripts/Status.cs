using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    public int playerLevel, skillPoint;
    public int stsPoint, hpLevel, pwrLevel, defLevel, intLevel, wisLevel;
    private float stsWd, stsHt; //外側の枠
    private float stsLeft, stsUp; //外側の枠の左と上
    private float abiWd, abiHt; //ステータス1個分の幅と高さ
    

    void Awake() {
        playerLevel = PlayerPrefs.GetInt("playerLevel"); //プレイヤのレベル
        stsPoint = PlayerPrefs.GetInt("stsPoint"); //残りステータスポイント
        hpLevel = PlayerPrefs.GetInt("hpLevel"); //HPに振ったポイント
        pwrLevel = PlayerPrefs.GetInt("pwrLevel"); //Powerに振ったポイント
        defLevel = PlayerPrefs.GetInt("defLevel"); //Defenceに振ったポイント
        intLevel = PlayerPrefs.GetInt("intLevel"); //Intelligenceに振ったポイント
        wisLevel = PlayerPrefs.GetInt("wisLevel"); //Wisdomに振ったポイント
    }

    void Start() {
        stsWd = Screen.width -200;
        stsHt= Screen.height - 100;
        stsLeft = Screen.width/2 - stsWd/2;
        stsUp = Screen.height/2 - stsHt/2;
        abiWd = stsWd/6;
        abiHt = stsHt/6;
    }

    void OnGUI () {
        /* 外枠のグループ*/
        GUI.BeginGroup (new Rect (stsLeft, stsUp, stsWd, stsHt)); // 真ん中にstsWd*stsHtのグループ
        GUI.Box (new Rect (0,0, stsWd, stsHt), "Level");
        GUI.Label (new Rect (stsWd/2+50, 0, 50, 20), playerLevel.ToString());

        /* ステータスのグループ */
        GUI.BeginGroup (new Rect (stsWd/12, stsHt*2/3 + 30, stsWd - stsWd/6, abiHt));
        GUI.Box (new Rect (0,0,stsWd-stsWd/6,abiHt), "Status Point");
        GUI.Box (new Rect (stsWd/2, 5, 50, 20), stsPoint.ToString());

        /* HP */
        GUI.BeginGroup (new Rect (0, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "HP");
        GUI.Box (new Rect (20,30,50,30), hpLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            hpLevel++;
            PlayerPrefs.SetInt("hpLevel", hpLevel);
        }
        GUI.EndGroup ();

        /* Power */
        GUI.BeginGroup (new Rect (abiWd, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Power");
        GUI.Box (new Rect (20,30,50,30), pwrLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            pwrLevel++;
            PlayerPrefs.SetInt("pwrLevel", pwrLevel);
        }
        GUI.EndGroup ();

        /* Defence */
        GUI.BeginGroup (new Rect (abiWd*2, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Defence");
        GUI.Box (new Rect (20,30,50,30), defLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            defLevel++;
            PlayerPrefs.SetInt("defLevel", defLevel);
        }
        GUI.EndGroup ();

        /* Intelligence */
        GUI.BeginGroup (new Rect (abiWd*3, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Intelligence");
        GUI.Box (new Rect (20,30,50,30), intLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            intLevel++;
            PlayerPrefs.SetInt("intLevel", intLevel);
        }
        GUI.EndGroup ();

        /* Wisdom */
        GUI.BeginGroup (new Rect (abiWd*4, 30, abiWd, abiHt));
        GUI.Box (new Rect (0,0,abiWd, abiHt), "Wisdom");
        GUI.Box (new Rect (20,30,50,30), wisLevel.ToString());
        if(GUI.Button (new Rect (100,30,30,30), "+")){
            wisLevel++;
            PlayerPrefs.SetInt("wisLevel", wisLevel);
        }
        GUI.EndGroup ();
        GUI.EndGroup ();

        /* Reset */
        if (GUI.Button (new Rect(10, 70, 80, 30), "Reset")) {
            playerLevel = 1;
            stsPoint = 0;
            hpLevel = 0;
            pwrLevel = 0;
            defLevel = 0;
            intLevel = 0;
            wisLevel = 0;
            PlayerPrefs.DeleteKey("playerLevel");
            PlayerPrefs.DeleteKey("statusPoint");
            PlayerPrefs.DeleteKey("hpLevel");
            PlayerPrefs.DeleteKey("pwrLevel");
            PlayerPrefs.DeleteKey("defLevel");
            PlayerPrefs.DeleteKey("intLevel");
            PlayerPrefs.DeleteKey("wisLevel");
        }

        GUI.EndGroup ();
        /* GUIグループ終了*/
    }
}
