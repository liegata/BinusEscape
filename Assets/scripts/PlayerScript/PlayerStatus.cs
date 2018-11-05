using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

    public Image hpImg;
    public float hp;
    public float maxhp;
    public bool refresh;

	// Use this for initialization
	void Start () {
        hp = maxhp;
        hpImg.fillAmount = hp / maxhp;
	}
	// Update is called once per frame
	void Update () {
        if (refresh == false) {
            return;
        }
        if (hp <= 0) {
            Destroy(gameObject);
        }
        hpImg.fillAmount = hp / maxhp;
        refresh = false;
	}

    void damaged() {
        refresh = true;
    }
}
