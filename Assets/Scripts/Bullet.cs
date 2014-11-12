using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public int speed;
    public static int power = 1;
    public static int bulletDir; /* 弾の進む方向(+右, -左)*/

    void Start () {
        speed = 10;
        rigidbody2D.velocity = new Vector2(bulletDir * speed, 0);
        bulletDir = 1;
    }

    void Update() {
        /* 向いてる方向で弾の出る方向を変える */
        if (Player.facingRight) 
          bulletDir = 1;
        else
          bulletDir = -1;
        }
}