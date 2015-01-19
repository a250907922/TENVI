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
                            SwitchPlay();
                        if(obj.name == "Status")
                            SwitchStatus();
                        if(obj.name == "Home")
                            SwitchHome();
                    }
                }
                if(Input.GetKeyDown ("h"))
                Application.LoadLevel ("Home");
            }

    public void SwitchPlay() {
        Application.LoadLevel("StageSelect");
    }

    public void SwitchStatus() {
        Application.LoadLevel("Status");
    }

    public void SwitchHome() {
        Application.LoadLevel("Home");
    }

    public void SwitchStageSelect() {
        Application.LoadLevel("StageSelect");
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
