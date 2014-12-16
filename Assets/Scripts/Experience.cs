using UnityEngine;
using System.Collections;

public class Experience : MonoBehaviour {
    public static int exp;

    void Awake () {
        exp = PlayerPrefs.GetInt("exp"); // 現在の経験値
    }

    public static void getExperience(string defeatedCharactor) { //敵を倒したときに経験値獲得のために呼び出す関数
        switch(defeatedCharactor) { //倒したキャラごとに獲得経験値を設定
            case "Slime": 
                exp += 1;
                PlayerPrefs.SetInt("exp", exp);
                break;
            case "Antallion":
                exp += 100;
                PlayerPrefs.SetInt("exp", exp);
                break;
        }
        if (exp >= PlayerLevel.requiredExpForLevelUp()){ //レベルアップ関数を呼び出す
            PlayerLevel.PlayerLevelUp();
        }
    }
}
