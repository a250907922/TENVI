using UnityEngine;
using System.Collections;

public class HpBar : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
	}

    void onDamage(int damage)
    {
        Rect hpRect = guiTexture.pixelInset;
        hpRect.width = (hpRect.width - damage); 

        if(hpRect.width <= 0){ //0以下にしない
            hpRect.width = 0;
        }
        guiTexture.pixelInset = hpRect;
    }
}
