using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //Stop bullet ketika ganti ammo
    public bool StopBullet;

    //player facing / kemana player ngadep --> ngadep kanan = true;
    public bool isFacingRight;

    [Header("UI")]
    public Text[] BulletIndicator;
    public RawImage[] SelectBullet;

    // Use this for initialization
    void Start()
    {
        isShooting = false;
        StopBullet = false;

        BulletSelect = 0;

        BulletAmmo = new int[Bullets.Length];

        for (int i = 0; i < BulletAmmo.Length; i++) {
            BulletAmmo[i] = BulletMax[i];
            BulletIndicator[i].text = BulletAmmo[i].ToString();
        }
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
        if (BulletAmmo[BulletSelect] > 0)
        {
            Instantiate(Bullets[BulletSelect], gameObject.transform.position, Quaternion.identity);
            BulletAmmo[BulletSelect]--;
            BulletIndicator[BulletSelect].text = BulletAmmo[BulletSelect].ToString();
            isShooting = false;
        }
        else {
            isShooting = false;
            return;
        }
        StartCoroutine(BulletSpawn());
	}

    public void Shooting()
    {
        StopBullet = false;
        isShooting = true;
    }

    public void ChangeBullet() {
        StopBullet = true;
        if (BulletSelect != Bullets.Length-1) {
            BulletSelect++;
        }
        else if (BulletSelect == Bullets.Length-1) {
            BulletSelect = 0;
        }
        for (int i = 0; i < SelectBullet.Length; i++) {
            SelectBullet[i].gameObject.SetActive(false);
        }

        SelectBullet[BulletSelect].gameObject.SetActive(true);
    }

    public IEnumerator BulletSpawn() {
        for (int i = 0; i < BulletFrequency[BulletSelect]-1; i++)
        {
            yield return new WaitForSeconds(SpawnTime);
            if (StopBullet == true)
            {
                isShooting = false;
                StopBullet = false;
                break;
            }
            if (BulletAmmo[BulletSelect] > 0)
            {
                Instantiate(Bullets[BulletSelect], gameObject.transform.position, Quaternion.identity);
                BulletAmmo[BulletSelect]--;
                BulletIndicator[BulletSelect].text = BulletAmmo[BulletSelect].ToString();
            }
            else {
                isShooting = false;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammunition1")) {
            BulletAmmo[0] += 5;
            if (BulletAmmo[0] > BulletMax[0]) {
                BulletAmmo[0] = BulletMax[0];
            }
            BulletIndicator[0].text = BulletAmmo[0].ToString();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ammunition2"))
        {
            BulletAmmo[1] += 5;
            if (BulletAmmo[1] > BulletMax[1])
            {
                BulletAmmo[1] = BulletMax[1];
            }
            BulletIndicator[1].text = BulletAmmo[1].ToString();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ammunition3"))
        {
            BulletAmmo[2] += 5;
            if (BulletAmmo[2] > BulletMax[2])
            {
                BulletAmmo[2] = BulletMax[2];
            }
            BulletIndicator[2].text = BulletAmmo[2].ToString();
            Destroy(collision.gameObject);
        }
    }
}
