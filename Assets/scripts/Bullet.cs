using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public int direction;
    public PlayerShooting PlayerShoot;
    public Vector3 PlayerForward;
    public float damage;

    public RaycastHit2D BulletRaycast;
    public float distance;

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

        BulletRaycast = Physics2D.Raycast(transform.position, Vector2.right, distance);

        if (BulletRaycast.collider.CompareTag("Enemy"))
        {
            Debug.Log("enemy damaged");
            BulletRaycast.collider.gameObject.GetComponent<EnemyStatus>().hp -= damage;
            BulletRaycast.collider.GetComponent<EnemyStatus>().SendMessageUpwards("damaged");
            Destroy(gameObject);
        }
    }
}
