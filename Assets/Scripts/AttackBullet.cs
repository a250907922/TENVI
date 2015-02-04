using UnityEngine;
using System.Collections;

public class AttackBullet : MonoBehaviour {
    public int speed;
    public static int power = 1;
    public static int bulletDir; //弾の進む方向(+右, -左)
    public int bulletDamage;

    void Start () {
        speed = 15;
        rigidbody2D.velocity = new Vector2(bulletDir * speed, 0);
        bulletDir = 1;
        bulletDamage = DamageCalc.fixedDamage("Bullet");
    }

    void Update() {
        /* 向いてる方向で弾の出る方向を変える */
        if (Player.facingRight)
          bulletDir = 1;
        else
          bulletDir = -1;
    }

    void OnCollisionEnter2D(Collision2D col){
      if(col.gameObject.tag == "Enemy"){
        Destroy (gameObject);
        col.gameObject.SendMessage("Damage", bulletDamage);
      }
    }
}
