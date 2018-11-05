using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour {

    public PlayerMovement PlayerMovement;
    bool walkleft;
    bool walkright;

	// Use this for initialization
	void Start () {
        PlayerMovement = GameObject.Find("player").GetComponent<PlayerMovement>();
        walkright = false;
        walkleft = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerMovement.ChooseControl == true) {
            return;
        }

        Debug.Log(PlayerMovement.horizontalMove);
        if (walkright == true)
        {
            PlayerMovement.moveTrigger = 1;
        }
        else if (walkleft == true)
        {
            PlayerMovement.moveTrigger = -1;
        }
        else if (walkleft == false && walkright == false)
        {
            PlayerMovement.moveTrigger = 0;
        }
    }

    public void onPointerDownMoveLeftButton()
    {
        walkleft = true;
    }

    public void onPointerUpMoveLeftButton()
    {
        walkleft = false;
    }

    public void onPointerDownMoveRightButton()
    {
        walkright = true;
    }

    public void onPointerUpMoveRightButton()
    {
        walkright = false;
    }
}
