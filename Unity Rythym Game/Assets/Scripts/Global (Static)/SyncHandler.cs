using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncHandler
{

    //SONG DATA//
    private static double startTime;
    private static BPMStructure bpmStructure;

    void startSong(BPMStructure BPMStructure, AudioClip song) { 

        startTime = Time.time;
        bpmStructure = BPMStructure;

    }

}
