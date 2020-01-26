using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncHandler
{

    private static BeatEventHandler beatEventHandler;

    //SONG DATA//
    private static double startTime;
    private static int beatNumber;
    private static SongData songData;
    private static AudioSource audioPlayer;

    public static void startSong(SongData songData) { 

        startTime = Time.time;
        SyncHandler.songData = songData;
        beatNumber = 0;

        audioPlayer.clip = songData.audio;
        audioPlayer.Play();

        beatEventHandler.waitForNextBeat();

    }

    public static double getStartTime() {return startTime;}

    public static double getBeatNumber() {return beatNumber;}

    public static SongData getSongData() {return songData;}

    public static AudioSource getAudioPlayer() {return audioPlayer;}

    public static double getCurrentSongPosition() {

        if (audioPlayer.clip == songData.audio && audioPlayer.isPlaying) { return audioPlayer.time; }
        else {Debug.LogWarning("Attempted access to current song position when no song was found."); return 0;}

    }

    public static double getCurrentBPM() {

        for(int i = 0; i < songData.BPMData.keyBPMPoints.Count; i++) {

            if(songData.BPMData.keyBPMPoints[i].time >= getCurrentSongPosition()) {

                return songData.BPMData.keyBPMPoints[i-1].bpm;

            }

        }

        Debug.LogWarning("No CurrentBPM data was found. . .");
        return 0;

    }

    public static BPMPoint getCurrentBPMPoint() {

        for(int i = 0; i < songData.BPMData.keyBPMPoints.Count; i++) {

            if(songData.BPMData.keyBPMPoints[i].time >= getCurrentSongPosition()) {

                return songData.BPMData.keyBPMPoints[i-1];

            }

        }

        Debug.LogWarning("No CurrentBPM data was found. . .");
        return new BPMPoint(0,0);

    }

    public static double getTimeOfLastBeat() {

        double subtractedTime = getCurrentBPMPoint().time;
        double currentSongPosition = getCurrentSongPosition();

        return (double)Mathf.Floor( (float)( getCurrentBPM() / (currentSongPosition) - subtractedTime) ) * (currentSongPosition - subtractedTime) + subtractedTime;

    }

    public static double getTimeOfNextBeat() {

        double subtractedTime = getCurrentBPMPoint().time;
        double currentSongPosition = getCurrentSongPosition();

        return (double)Mathf.Ceil( (float)( getCurrentBPM() / (currentSongPosition) - subtractedTime) ) * (currentSongPosition - subtractedTime) + subtractedTime;

    }

}