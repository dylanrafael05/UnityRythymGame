using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEventHandler
{

   public IEnumerable waitForNextBeat() {

        if( SyncHandler.getBeatNumber() == SyncHandler.getSongData().BPMData.keyBPMPoints.Count ) {

            yield return null;

        } else {
            
            yield return new WaitForSeconds( (float)(SyncHandler.getTimeOfNextBeat() + SyncHandler.getCurrentSongPosition()) );
            OnBeat();
            waitForNextBeat();

        }

    } 

    public delegate void beatEventHandler();
    public event beatEventHandler Beat;

    protected virtual void OnBeat() {

        if(Beat != null) {Beat();}

    }

}
