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
                        /* ここから何が押されたか指定 */
                        if(obj.name == "ぷれい")
                            Application.LoadLevel ("Play");
                    }
                }
            }
}
