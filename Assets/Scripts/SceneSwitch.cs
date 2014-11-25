using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {
    //private int w;
    //private int h;

    void Start () {
        //w = Screen.width;
        //h = Screen.height;
    }

	void Update () {
                if (Input.GetMouseButtonDown (0)) {
                    Vector3    tapPoint   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Collider2D collider2d = Physics2D.OverlapPoint(tapPoint);
                    if (collider2d) {
                        GameObject obj = collider2d.transform.gameObject;
                        Debug.Log(obj.name);
                        //ここから何が押されたか指定 
                        if(obj.name == "Play")
                            Application.LoadLevel ("Play");
                        if(obj.name == "Status")
                            Application.LoadLevel ("Status");
                        if(obj.name == "Home")
                            Application.LoadLevel ("Home");
                    }
                }
                if(Input.GetKeyDown ("h"))
                        Application.LoadLevel ("Home");
            }

/*
            void OnGUI() {
                GUI.Box(new Rect(w/4, h/4, w/2, h/2), "Menu");
                if(GUI.Button(new Rect(20,40,80,20), "Game Start !")) {
                    Application.LoadLevel("Play");
                }
            }
            */
}
