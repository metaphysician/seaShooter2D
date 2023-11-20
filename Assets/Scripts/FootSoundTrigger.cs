using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioManager _audioMgr;

    // Start is called before the first frame update
    void Start()
    {
       _audioMgr = GameObject.Find("AudioMgr").GetComponent<AudioManager>(); 
    }

    public void PlayFootSound(string foot)
    {
        if(foot == "rightFoot")
            _audioMgr.PlayFootSound_R();
        else if(foot == "leftFoot")
            _audioMgr.PlayFootSound_L();
    }
}
