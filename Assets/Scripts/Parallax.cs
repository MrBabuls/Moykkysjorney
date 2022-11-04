using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform MainCam;
    public Transform MiddleBG;
    public Transform SideBG;

    public float Length = 38.4f;

    void Update()
    {
        if (MainCam.position.x > MiddleBG.position.x)
            SideBG.position = MiddleBG.position + Vector3.right * Length;

        if (MainCam.position.x < MiddleBG.position.x)
            SideBG.position = MiddleBG.position + Vector3.left * Length;

        if (MainCam.position.x > SideBG.position.x || MainCam.position.x < SideBG.position.x)
        {
            Transform Z = MiddleBG;
            MiddleBG = SideBG;
            SideBG = Z;
        }
    }
}
