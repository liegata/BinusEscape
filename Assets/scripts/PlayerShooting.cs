using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [Header("Isi Prefab Bulletnya")]
    public Transform[] Bullets;


    [Header("Isi Max Ammo")]
    public int[] BulletMax;

    //Ammo yg dipunya
    public int[] BulletAmmo;

    [Header("Isi Frequency Bulletnya")]
    //frekuensi tembakan sekali click
    public int[] BulletFrequency;

    //selisih waktu spawn
    public float SpawnTime;

    //pilih bulletnya
    public int BulletSelect;

    //trigger
    public bool isShooting;

    //player facing / kemana player ngadep --> ngadep kanan = true;
    public bool isFacingRight;
	// Use this for initialization
	void Start () {
        BulletSelect = 0;
        isShooting = false;
        
        BulletAmmo = new int[Bullets.Length];
    }
	
	// Update is called once per frame
	void Update () {
        if (isShooting == false) {
            return;
        }

        if (gameObject.transform.localScale.x > 0)
        {
            isFacingRight = true;
        }
        else {
            isFacingRight = false;
        }

        //instantiate bullet sesuai frequency
        Instantiate(Bullets[BulletSelect], gameObject.transform.position, Quaternion.identity);
        StartCoroutine(BulletSpawn());

        isShooting = false;
	}

    public void Shooting() {
        isShooting = true;
        Debug.Log(BulletFrequency[BulletSelect]);
    }

    public void ChangeBullet() {
        if (BulletSelect != Bullets.Length-1) {
            BulletSelect++;
        }
        else if (BulletSelect == Bullets.Length-1) {
            BulletSelect = 0;
        }
    }

    public IEnumerator BulletSpawn() {
        for (int i = 0; i < BulletFrequency[BulletSelect]-1; i++)
        {
            yield return new WaitForSeconds(SpawnTime);
            Instantiate(Bullets[BulletSelect], gameObject.transform.position, Quaternion.identity);
        }
    }
}
