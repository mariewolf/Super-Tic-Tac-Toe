using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject space;
    public GameObject subGridPrefab;
    public GameObject bigGridPrefab;
    void Start()
    {
        /*
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                GameObject newSpace = Instantiate(space, new Vector3(i, 0, j), Quaternion.identity);
                newSpace.transform.parent = transform;
            }
        }*/

        GameObject bigGrid = Instantiate(bigGridPrefab, new Vector3(3.6f, 0, 3.6f), Quaternion.identity);

        for(int i = 0; i < 3; i++)
        {
            int x = i * 4;
            for(int j = 0; j < 3; j++)
            {
                int z = j * 4;
                GameObject subGrid = Instantiate(subGridPrefab, new Vector3((x), 0, (z)), Quaternion.identity);
                subGrid.transform.parent = transform;
                subGrid.AddComponent<SubGrid>();
                subGrid.GetComponent<SubGrid>().gridIndex = i * 3 + j;
                for(int s = 0; s < 3; s++)
                {
                    for(int t = 0; t < 3; t++)
                    {
                        GameObject newSpace = Instantiate(space,new Vector3(x + s + 0.5f, 0, z + t + 0.5f), Quaternion.identity,  subGrid.transform);
                        newSpace.AddComponent<BoxSpace>();
                        newSpace.GetComponent<BoxSpace>().subGridLocation = s * 3 + t;
                    }
                }
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
