using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {
	void Start () {
	
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("Play");
		}
	}
}
