using UnityEngine;
using System.Collections;

public class DamageCalc : MonoBehaviour {
   public static int damage;
   public static int pwrLevel;

   void Start() {
        pwrLevel = PlayerPrefs.GetInt("pwrLevel");
    }

    public static int fixedDamage(string weponType) {
        pwrLevel = PlayerPrefs.GetInt("pwrLevel");
        switch(weponType) {
            case "Bullet": 
                damage = AttackBullet.power + pwrLevel;
                break;
            case "Melee":
                damage = AttackMelee.power + pwrLevel;
                break;
        }
        return damage;
    }
}
