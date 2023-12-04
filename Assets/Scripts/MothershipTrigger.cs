using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipTrigger : MonoBehaviour
{
    [SerializeField] private AudioManager _audioMgr;

    // Start is called before the first frame update
    void Start()
    {
       _audioMgr = GameObject.Find("AudioMgr").GetComponent<AudioManager>(); 
    }

    public void MothershipLoop()
    {
        _audioMgr.PlayMothershipLoop();
    }

    public void MothershipCutscene()
    {
        _audioMgr.PlayMothershipCutscene();
    }
}
