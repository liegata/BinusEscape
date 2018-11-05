using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float speed;
    public float distance;

    public float damage;
    public float damageGap;

    private bool movingLeft = true;

    public Transform groundDetection;

    private void Start()
    {
        damageGap = 0;
    }

    void Update()
    {
        if(gameObject.name == "opossum-1")
        {
            opossumPatrol();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            if (damageGap == 0f)
            {
                collision.gameObject.GetComponent<PlayerStatus>().hp -= damage;
                collision.gameObject.SendMessageUpwards("damaged");
                damageGap = 1f;
                StartCoroutine(damageGapCount());
            }
            //Destroy(collision.gameObject);
        }
    }

    private void opossumPatrol()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

    public IEnumerator damageGapCount() {
        yield return new WaitForSeconds(0.5f);
        damageGap = 0f;
    }
}
