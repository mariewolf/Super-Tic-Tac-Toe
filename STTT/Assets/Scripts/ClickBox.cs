using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBox : MonoBehaviour
{
    Ray ray;
	RaycastHit hit;
	
	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0))
				print(hit.collider.name);
                //change color of hit object
                hit.collider.GetComponent<Renderer>().material.color = Color.red;

		}
	}
}
