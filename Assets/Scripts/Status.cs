using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    public int playerLevel;
    public int hpLevel;
    public int powerLevel;
    public int defenceLevel;
    private float stsWd;
    private float stsHt;

    void Awake() {
        playerLevel = PlayerPrefs.GetInt("playerLevel");
        playerLevel = PlayerPrefs.GetInt("hpLevel");
        powerLevel = PlayerPrefs.GetInt("powerLevel");
        playerLevel = PlayerPrefs.GetInt("defenceLevel");
    }

    void Start() {
        stsWd = Screen.width -200;
        stsHt= Screen.height - 100;
    }

    void OnGUI () {
        /* GUIグループの生成*/
        GUI.BeginGroup (new Rect (Screen.width/2 - stsWd/2, Screen.height/2 - stsHt/2, stsWd, stsHt)); // 真ん中に100*140のグループ
        GUI.Box (new Rect (0,0, stsWd, stsHt), "Player Level");

        /* Power */
        GUI.Label (new Rect (0,30,100,30), "Power");
        GUI.Box (new Rect (10,30,80,30), powerLevel.ToString());
        if(GUI.Button (new Rect (100,30,80,30), "Level up")){
            powerLevel++;
            PlayerPrefs.SetInt("powerLevel", powerLevel);
        }
        if (GUI.Button (new Rect(10, 70, 80, 30), "Reset")) {
            powerLevel = 0;
            PlayerPrefs.DeleteKey("powerLevel");
        }
        GUI.EndGroup ();
        /* GUIグループ終了*/
    }
}
