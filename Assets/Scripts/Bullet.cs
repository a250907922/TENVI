﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int speed;
	public static int power = 1;

	void Start () {
		speed = 10;
		rigidbody2D.velocity = new Vector2(Player.bulletDir * speed, 0);
	}
}