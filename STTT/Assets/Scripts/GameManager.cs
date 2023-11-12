using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool player = false;
    public int turn = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchPlayers()
    {
        player = !player;
        turn++;
    }

    public bool CheckSubGridWin(BoxSpace box)
    {
        Transform subGrid = box.gameObject.transform.parent;
        int box1 = -1;
        int box2 = -1;
        int box3 = -1;
        bool foundWin = false;
        if (box.subGridLocation % 4 == 0)
        {
            //left-->right diagonal
            box1 = subGrid.GetChild(0).gameObject.GetComponent<BoxSpace>().player;
            box2 = subGrid.GetChild(4).gameObject.GetComponent<BoxSpace>().player;
            box3 = subGrid.GetChild(8).gameObject.GetComponent<BoxSpace>().player;
            foundWin = box.player == box1 && box1 == box2 && box3 == box2;
        }
        if(!foundWin && box.subGridLocation % 2 == 0 && box.subGridLocation != 8)
        {
            //right-->left diagonal
            box1 = subGrid.GetChild(2).gameObject.GetComponent<BoxSpace>().player;
            box2 = subGrid.GetChild(4).gameObject.GetComponent<BoxSpace>().player;
            box3 = subGrid.GetChild(6).gameObject.GetComponent<BoxSpace>().player;
            foundWin = box.player == box1 && box1 == box2 && box3 == box2;
        }
        if(!foundWin)
        {
            box1 = box.player;
            box2 = subGrid.GetChild((box.subGridLocation + 3) % 9).gameObject.GetComponent<BoxSpace>().player;
            box3 = subGrid.GetChild((box.subGridLocation + 6) % 9).gameObject.GetComponent<BoxSpace>().player;
            if (box1 == box2 && box2 == box3)
            {
                foundWin = true;
            }
            else
            {
                int row = box.subGridLocation / 3;
                box1 = subGrid.GetChild(row * 3).gameObject.GetComponent<BoxSpace>().player;
                box2 = subGrid.GetChild(row * 3 + 1).gameObject.GetComponent<BoxSpace>().player;
                box3 = subGrid.GetChild(row * 3 + 2).gameObject.GetComponent<BoxSpace>().player;
                if (box1 == box2 && box2 == box3 && box1 == box.player)
                {
                    foundWin = true;
                }

            }
        }
        Debug.Log("Win");
        return foundWin;

    }

}
