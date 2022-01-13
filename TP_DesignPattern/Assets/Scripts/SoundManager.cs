using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Sound
{
    public string Key;
    public AudioClip Clip;

}
public class SoundManager : MonoBehaviour
{
    private Game _game;
    private AudioSource _source;

    public List<Sound> Sounds;

    public void Init(Game g)
    {
        _game = g;
        _source = GetComponent<AudioSource>();

        _game.controller.OnJump += PlayJumpSound;
    }

    void PlayJumpSound()
    {
        foreach (Sound pair in Sounds)
        {
            if (pair.Key.Equals("JUMP"))
            {
                _source.clip = pair.Clip;
                _source.Play();
            }
        }
        
    }
}
