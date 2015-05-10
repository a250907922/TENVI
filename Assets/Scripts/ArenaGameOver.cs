using UnityEngine;
using System.Collections;

public class ArenaGameOver : MonoBehaviour {
	public float time = 0;

	void Start () {
	
	}
	
	void Update () {
		time += Time.deltaTime;
		if(time > 3.0f)
			Application.LoadLevel("Home");
	}
}
