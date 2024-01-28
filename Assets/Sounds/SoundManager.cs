using UnityEngine;

class SoundManager : MonoBehaviour
{
    public AudioSource Drums;
    public AudioSource Bass;
    public AudioSource Harmony_1;
    public AudioSource Harmony_2;
    public AudioSource Melody_Space;
    public AudioSource Melody_Ground;
    public AudioSource Melody_Sewers;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ResetLevel()
    {
        Drums.mute = false;
        Bass.mute = false;
        Harmony_1.mute = true;
        Harmony_2.mute = true;
        Melody_Space.mute = true;
        Melody_Ground.mute = true;
        Melody_Sewers.mute = true;
    }

    public void Choice_1_1()
    {
        Harmony_1.mute = false;
    }

    public void Choice_1_2()
    {
        Harmony_2.mute = false;
    }

    public void Choice_2_Space()
    {
        Melody_Space.mute = false;
    }

    public void Choice_2_Ground()
    {
        Melody_Ground.mute = false;
    }

    public void Choice_2_Sewers()
    {
        Melody_Sewers.mute = false;
    }
}
