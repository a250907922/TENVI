using UnityEngine;
using System.Collections;

public class Plat : MonoBehaviour {
    public int nowPlayerLevel;
    
    void OnGui () {
        GUI.BeginGroup (new Rect (0,0,30,30));
        GUI.Box (new Rect (0,0,20,20), nowPlayerLevel.ToString());
        GUI.EndGroup ();
    }

    public void UpdateLevel () {
        nowPlayerLevel++;
    }
}
