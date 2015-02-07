using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {
    void Start () {
    }

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Vector3    tapPoint   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider2d = Physics2D.OverlapPoint(tapPoint);
            if (collider2d) {
                GameObject obj = collider2d.transform.gameObject;
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

    public void SwitchPick() {
      Application.LoadLevel("Pick");
    }

    public void SwitchSkillSet() {
      Application.LoadLevel("SkillSet");
    }
}
