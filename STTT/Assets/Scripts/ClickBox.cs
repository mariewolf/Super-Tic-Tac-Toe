using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBox : MonoBehaviour
{
    Ray ray;
	RaycastHit hit;
	GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
    }

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0)){
				print(hit.collider.name);
                if(gm.player){
                    hit.collider.GetComponent<Renderer>().material.color = Color.blue;
                }
                else
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.red;
                }
                
                gm.SwitchPlayers();
            }

		}
	}
}
