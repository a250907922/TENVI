using UnityEngine;
using System.Collections;

public class ArenaHp : MonoBehaviour {
	float maxWid;
	float curWid;
	float damageWid;
	ArenaLizardStatus arenaLizardStatus;
	GameObject currentHpPanel;
	
	void Awake() {
		arenaLizardStatus = GetComponent<ArenaLizardStatus>();
	}

	void Start () {
		maxWid = GameObject.Find("MaxHpPanel").GetComponent<RectTransform>().sizeDelta.x;
		curWid = GameObject.Find("CurrentHpPanel").GetComponent<RectTransform>().sizeDelta.x;
		damageWid = curWid / arenaLizardStatus.chalHp;
		currentHpPanel = GameObject.Find("CurrentHpPanel");
	}
	
	void Update () {
		
	}
	
	public void Damage(){
		curWid -= damageWid;
		currentHpPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(curWid, currentHpPanel.GetComponent<RectTransform>().sizeDelta.y);
	}
}
