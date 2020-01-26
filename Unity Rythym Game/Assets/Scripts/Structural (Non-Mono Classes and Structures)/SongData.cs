using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData
{

    public BPMData BPMData;
    public AudioClip audio;

    public SongData(BPMData BPMData, AudioClip audio) {

        this.BPMData = BPMData;
        this.audio = audio;

    }

}