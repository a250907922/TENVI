using UnityEngine;
using System.Collections;

public class PlayerLevel : MonoBehaviour {
    public static int playerLevel, stsPoint;
    public static int requiredExp;

    public static int requiredExpForLevelUp () { //レベル毎のレベルアップに必要な経験値
        playerLevel = PlayerPrefs.GetInt("playerLevel");
        switch (playerLevel) { //現在のレベル
            case 1:
                requiredExp = 1;
                break;
            case 2:
                requiredExp = 2;
                break;
            case 3:
                requiredExp = 4;
                break;
        }
        return requiredExp; // レベルアップに必要な経験値
    }

    public static void PlayerLevelUp (){ //プレイヤーのレベルを一つあげる。
        playerLevel++;
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        stsPoint++; //ステータスポイントも一つあげる。
        PlayerPrefs.SetInt("stsPoint", stsPoint);
    }
}
