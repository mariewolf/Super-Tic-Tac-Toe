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
			if(Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent<BoxSpace>(out BoxSpace box)){
                SubGrid sg = hit.collider.transform.parent.GetComponent<SubGrid>();
                if(!(gm.currentBox == -1 || gm.currentBox == sg.gridIndex))
                {
                    return;
                }
                if(hit.collider.GetComponent<BoxSpace>().player != -1)
                {
                    return;
                }
                hit.collider.GetComponent<BoxSpace>().Capture(gm.player ? 1 : 0);
                bool gridCaptured = gm.CheckSubGridWin(hit.collider.GetComponent<BoxSpace>());
                int boxLocation = hit.collider.GetComponent<BoxSpace>().subGridLocation;
                gm.currentBox = boxLocation;
                if(gridCaptured)
                {   sg.captured = true;
                    for(int i = 1; i <=9; i++)
                    {
                        hit.collider.transform.parent.GetChild(i).GetComponent<BoxSpace>().Capture(gm.player ? 1 : 0);
                    }
                    
                    
                }
                if(sg.gameObject.transform.parent.GetChild(boxLocation).GetComponent<SubGrid>().captured)
                    {
                        gm.currentBox = -1;
                    }
                gm.SwitchPlayers();
                
                
            }

		}
	}
}
