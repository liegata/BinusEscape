using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public int direction;
    public PlayerShooting PlayerShoot;
    public Vector3 PlayerForward;

    // Use this for initialization
    void Start () {
        PlayerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        if (PlayerShoot.isFacingRight == true)
        {
            direction = 1;
        }
        else {
            direction = -1;
        }
	}

	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(direction*speed,0,0);
        Destroy(gameObject, 5);
	}
}
