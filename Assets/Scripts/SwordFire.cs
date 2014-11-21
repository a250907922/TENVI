using UnityEngine;
using System.Collections;

public class SwordFire : MonoBehaviour {

    public static int power = 4;
    public int powerLevel;
    public static int fixedPower;
    public static float firePosX;
    public float fireScale = 0.7f;
    private bool flip = true;

    void Awake() {
        powerLevel = PlayerPrefs.GetInt("powerLevel");
    }

    void Start () {
        firePosX = fireScale/2;
        fixedPower = power + powerLevel;
    }

    void Update () {
        if(Player.facingRight){
            if(flip)
                flip = false;
        }else{
            if(flip){
                transform.localScale = new Vector3(-fireScale,  fireScale, 0); //反転
                flip = false;
            }
        }
        Destroy(gameObject, 0.1f); //消えるまでの時間
    }
}
