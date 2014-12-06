using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    public int playerLevel;
    public int hpLevel;
    public int powerLevel;
    public int defenceLevel;
    private float statusWidth;
    private float statusHeight;


    void Awake() {
        playerLevel = PlayerPrefs.GetInt("playerLevel");
        playerLevel = PlayerPrefs.GetInt("hpLevel");
        powerLevel = PlayerPrefs.GetInt("powerLevel");
        playerLevel = PlayerPrefs.GetInt("defenceLevel");
    }

    void Start() {
        statusWidth = 200.0f;
        statusHeight = 280.0f;
    }

    void OnGUI () {
        /* GUIグループの生成*/
        GUI.BeginGroup (new Rect ((Screen.width/2) - (statusWidth/2), (Screen.height/2) - (statusHeight/2), statusWidth, statusWidth)); // 真ん中に100*140のグループ
        GUI.Box (new Rect (0,0, statusWidth, statusWidth), "Player Level");

        /* Power */
        GUI.Label (new Rect (0,statusHeight/5,100,30), "Power");
        if(GUI.Button (new Rect (statusWidth/3,statusHeight/5,100,30), "Level Up")){
            powerLevel++;
            PlayerPrefs.SetInt("powerLevel", powerLevel);
        }
        if (GUI.Button (new Rect(statusWidth*2/3, statusHeight/5, 100, 30), "Reset")) {
            powerLevel = 0;
            PlayerPrefs.DeleteKey("powerLevel");
        }
        GUI.Label (new Rect (10,120,80,30), powerLevel.ToString());
        GUI.EndGroup ();
        /* GUIグループ終了*/
    }
}
