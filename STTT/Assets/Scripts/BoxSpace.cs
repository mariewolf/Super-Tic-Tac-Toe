using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BoxSpace : MonoBehaviour
{
    public int player = -1;
    public int subGridLocation = -1;

    public void Capture(int player)
    {
        this.player = player;
        if(player == 0)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if(player == 1)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        //Bloom b = GetComponent<PostProcessVolume>().profile.GetSetting<Bloom>();
        //set bloom intensity
       // b.intensity.Override(1);
    }
}
