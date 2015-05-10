using UnityEngine;
using System.Collections;

public class ArenaLizardStatus : MonoBehaviour {
	public int chalHp, chalPwr, chalDef, chalInt, chalWis;
	private string chalSkill;

	void Awake () {
		chalHp = PlayerPrefs.GetInt("ChalHp");
		chalPwr = PlayerPrefs.GetInt("ChalPwr");
		chalDef = PlayerPrefs.GetInt("ChalDef");
		chalInt = PlayerPrefs.GetInt("ChalInt");
		chalWis = PlayerPrefs.GetInt("ChalWis");
		chalSkill = PlayerPrefs.GetString("ChalSkill");
		Debug.Log("ChalHp" + chalHp);
	}

	void Update () {

	}
}
