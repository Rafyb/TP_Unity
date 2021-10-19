using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFeedback : GameFeedback
{
    public AudioSource source;
    public float volume = 1.0f;
    
    public override IEnumerator Execute(GameEventInstance gameEvent)
    {
        if(source == null) yield break;
        source.volume = volume;
        source.Play();
        yield break;
    }

    public override Color color()
    {
        return Color.gray;
    }

    public override string ToString()
    {
        string r = base.ToString() + " ";
        if (source != null) r += source.name;
        else r += "(NoAudioSource)";
        r += " " + volume * 100 + "%";
        return r;
    }
}
