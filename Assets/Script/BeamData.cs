using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamData : MonoBehaviour
{
    public LineRenderer beamLine;
    // Start is called before the first frame update
    void Start()
    {
        beamLine = GetComponent<LineRenderer>();

        Vector3[] myPointsInLine;
        myPointsInLine = new Vector3[beamLine.positionCount];// array vector3 muss be created first with myLine.positionCount before using  myLine.GetPositions

        beamLine.GetPositions(myPointsInLine);

        for (int i = 0; i < myPointsInLine.Length; i++)
        {
            Debug.Log(myPointsInLine[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
