using UnityEngine;
using System.Collections;

public class AttackMelee : MonoBehaviour {

    public static int power = 4;
    public static int fixedPower;
    public static float fireScale = 0.5f;
    private bool flip = true;

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
