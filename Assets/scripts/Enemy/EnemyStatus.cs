using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour {

    public float hp;
    public Image hpImg;
    public float maxhp;
    public bool refresh;
    
    public float damage;
    public float damageGap;

    // Use this for initialization
    void Start()
    {
        damageGap = 0;
        hp = maxhp;
        hpImg.fillAmount = hp / maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        if (refresh == false)
        {
            return;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        hpImg.fillAmount = hp / maxhp;
        refresh = false;
    }

    void damaged()
    {
        refresh = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageGap == 0f)
            {
                collision.gameObject.GetComponent<PlayerStatus>().hp -= damage;
                collision.gameObject.GetComponent<PlayerStatus>().SendMessageUpwards("damaged");
                damageGap = 1f;
                StartCoroutine(damageGapCount());
            }
        }
    }

    public IEnumerator damageGapCount()
    {
        yield return new WaitForSeconds(0.5f);
        damageGap = 0f;
    }
}
