using UnityEngine;
using System.Collections;

public class AttackMelee : MonoBehaviour {

    public static int power = 4;
    public static int fixedDamage;
    public static float fireScale = 0.5f;
    private bool flip = true;

    void Start () {
      fixedDamage = DamageCalc.fixedDamage("Melee");
      StartCoroutine("WaitForDirection");
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

    void OnCollisionEnter2D(Collision2D col){
      if(col.gameObject.tag == "Enemy"){
        col.gameObject.SendMessage("Damage", fixedDamage);
      }
    }

    private IEnumerator WaitForDirection() {
      renderer.enabled = false;
      yield return new WaitForSeconds(0.01f);
      renderer.enabled = true;
      yield break;
    }
}
