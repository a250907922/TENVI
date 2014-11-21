using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    public int  powerLevel;

    void Awake() {
        powerLevel = PlayerPrefs.GetInt("powerLevel");
    }

    void OnGUI () {
        /* GUIグループの生成*/
        GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 70, 100, 140));
        GUI.Box (new Rect (0,0,100,140), "Power");
        if(GUI.Button (new Rect (10,30,80,30), "Level up")){
            powerLevel++;
            PlayerPrefs.SetInt("powerLevel", powerLevel);
        }
        if (GUI.Button (new Rect(10, 70, 80, 30), "Reset")) {
            powerLevel = 0;
            PlayerPrefs.DeleteKey("powerLevel");
        }
        GUI.Box (new Rect (10,120,80,30), powerLevel.ToString());
        GUI.EndGroup ();
        /* GUIグループ終了*/
    }
}
