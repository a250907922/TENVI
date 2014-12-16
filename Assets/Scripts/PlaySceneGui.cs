using UnityEngine;
using System.Collections;

public class Plat : MonoBehaviour {
    void OnGui () {
        GUI.BeginGroup (new Rect (0,0,30,30));
        GUI.Box (new Rect (0,0,20,20), PlayerLevel.playerLevel.ToString());
        GUI.EndGroup ();
    }
}
