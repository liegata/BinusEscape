using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewriter : MonoBehaviour
{

    [TextArea]
    public string katakata;
    [SerializeField]
    private GameObject typewriterimage;

    public float intervalkata;

    private string partialkata;
    private float kumulativeDeltaTime;

    private Text label;

    void Awake()
    {
        label = GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {
        partialkata = "";
        kumulativeDeltaTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        kumulativeDeltaTime += Time.deltaTime;
        while (kumulativeDeltaTime >= intervalkata && partialkata.Length < katakata.Length)
        {
            partialkata += katakata[partialkata.Length];
            kumulativeDeltaTime -= intervalkata;
        }
        if (partialkata.Length == katakata.Length)
        {
            StartCoroutine(Wait(1.5f));
            
        }
        label.text = partialkata;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
        typewriterimage.SetActive(false);
    }
}