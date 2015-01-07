using UnityEngine;
using System.Collections;

public class DamageManagement : MonoBehaviour {
    public GameObject slime;
    public GameObject antallion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetEnemyAttackDamage(string enemyTag){
        int damage = 0;
        switch(enemyTag){
            case "Slime":
                damage = 10;
                break;
            case "Antallion":
                damage = 100;
                break;
        }
        return damage;
    }
}
