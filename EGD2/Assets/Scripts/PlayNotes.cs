using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayNotes : MonoBehaviour
{
    public AudioClip clip;
    public AudioMixerGroup mixerChannel;
    private List<AudioSource> auds;
    private bool holdingDown = false;
    private List<KeyCode> currentKeys;
    private float semitone = 1.05946f;
    Move player;

    // Start is called before the first frame update
    void Start()
    {
        currentKeys = new List<KeyCode>();
        player = FindObjectOfType<Move>();
        auds = new List<AudioSource>();
        for(int i = 0; i < 4; i++)
        {
            AudioSource temp = gameObject.AddComponent<AudioSource>();
            temp.clip = clip;
            temp.outputAudioMixerGroup = mixerChannel;
            auds.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isPlayerControllable)
        {
            return;
        }
        if (Input.anyKeyDown)
        {
            foreach (char a in Input.inputString)
            {
                if (a == ' ')
                {
                    currentKeys.Add(KeyCode.Space);
                    playSound(Mathf.Pow(semitone, -1));
                }

                //LEFT SIDE
                if (a == 'j')
                {
                    currentKeys.Add(KeyCode.J);
                    playSound(1);
                }
                if (a == 'u')
                {
                    currentKeys.Add(KeyCode.U);
                    playSound(Mathf.Pow(semitone, 4));
                }
                if (a == 'h')
                {
                    currentKeys.Add(KeyCode.H);
                    playSound(Mathf.Pow(semitone, 7));
                }
                if (a == 'y')
                {
                    currentKeys.Add(KeyCode.Y);
                    playSound(Mathf.Pow(semitone, 11));
                }
                if (a == 'g')
                {
                    currentKeys.Add(KeyCode.G);
                    playSound(Mathf.Pow(semitone, 14));
                }
                if (a == 't')
                {
                    currentKeys.Add(KeyCode.T);
                    playSound(Mathf.Pow(semitone, 18));
                }
                if (a == 'f')
                {
                    currentKeys.Add(KeyCode.F);
                    playSound(Mathf.Pow(semitone, 21));
                }
                if (a == 'r')
                {
                    currentKeys.Add(KeyCode.R);
                    playSound(Mathf.Pow(semitone, 24));
                }

                //RIGHT SIDE
                if (a == 'k')
                {
                    currentKeys.Add(KeyCode.K);
                    playSound(Mathf.Pow(semitone, 2));
                }
                if (a == 'o')
                {
                    currentKeys.Add(KeyCode.O);
                    playSound(Mathf.Pow(semitone, 6));
                }
                if (a == 'l')
                {
                    currentKeys.Add(KeyCode.L);
                    playSound(Mathf.Pow(semitone, 9));
                }
                if (a == 'p')
                {
                    currentKeys.Add(KeyCode.P);
                    playSound(Mathf.Pow(semitone, 12));
                }
                if (a == ';')
                {
                    currentKeys.Add(KeyCode.Semicolon);
                    playSound(Mathf.Pow(semitone, 16));
                }
                if (a == '[')
                {
                    currentKeys.Add(KeyCode.LeftBracket);
                    playSound(Mathf.Pow(semitone, 19));
                }
                if (a == '\'')
                {
                    currentKeys.Add(KeyCode.Quote);
                    playSound(Mathf.Pow(semitone, 23));
                }
                if (a == ']')
                {
                    currentKeys.Add(KeyCode.RightBracket);
                    playSound(Mathf.Pow(semitone, 26));
                }
            }
        }
        if (!Input.anyKeyDown)
        {
            foreach(KeyCode key in currentKeys)
            {
                if(!Input.GetKey(key))
                {
                    bool temp = currentKeys.Remove(key);
                    Debug.Log(temp);
                }
            }
        }
    }

    private void playSound(float pitch)
    {
        if (currentKeys.Count <= auds.Count)
        {
            auds[currentKeys.Count - 1].pitch = pitch;
            auds[currentKeys.Count - 1].Play();
        }
    }
}
