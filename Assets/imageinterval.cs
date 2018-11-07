using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageinterval : MonoBehaviour
{

    public GameObject panel;
    [SerializeField]
    private GameObject typewriterimage;
    public float intervalimage = 2f;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        intervalimage = intervalimage - 1 * Time.deltaTime;
        if (intervalimage <= 0)
        {
            panel.SetActive(true);
            intervalimage = 2f;
        }else
        {
            typewriterimage.SetActive(false);
        }
        

    }
}