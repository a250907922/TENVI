using UnityEngine;
using System.Collections;

public class LevelUpEffect : MonoBehaviour {

    public float life = 1.0f;

    // Use this for initialization
    void Start () {
      
    }

    // Update is called once per frame
    void Update () {
        life -= Time.deltaTime;
        if(life < 0)
        {
            Destroy(this.gameObject);
        }

    }
}
