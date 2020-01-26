using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMData
{

    public List<BPMPoint> keyBPMPoints;

    public BPMData(double BPM) { keyBPMPoints = new List<BPMPoint>() {new BPMPoint(0,BPM)}; }
    public BPMData(List<BPMPoint> keyBPMPoints) { 

        this.keyBPMPoints = keyBPMPoints;

        if(keyBPMPoints[0].time != 0) {

            Debug.Log("An invalid BPMData has been instantiated. Replacing invalid entries. . . ");
            keyBPMPoints[0].time = 0;

        }

     }

}
