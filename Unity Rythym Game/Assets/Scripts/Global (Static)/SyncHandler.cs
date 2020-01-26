using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncHandler
{

    //SONG DATA//
    private static double startTime;
    private static int beatNumber;
    private static BPMStructure bpmStructure;

    public static void startSong(BPMStructure BPMStructure) { 

        startTime = Time.time;
        bpmStructure = BPMStructure;
        beatNumber = 0;

    }

    //DELEGATES AND EVENTS//
    public delegate void beatEventHandler(int beatNumber);
    public event beatEventHandler Beat;

    protected virtual void OnBeat() {

        if(Beat != null) {Beat(beatNumber);}

    }

}
