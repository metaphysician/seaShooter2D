using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] trackSources;
    public bool gameMusicPlay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameMusicPlay = true;
        StartCoroutine(RepeatMusicLoop());
    }

    void CueNextLoop()
    {
        for(int track = 0; track < trackSources.Length; track++)
        {
            int diceroll = Random.Range(0,5);
            Debug.Log("For "+trackSources[track].gameObject.name+":"+diceroll);
            if(diceroll > 2)
                trackSources[track].mute = false;
            else 
                trackSources[track].mute = true;
            trackSources[track].Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RepeatMusicLoop()
    {
        while(gameMusicPlay)
        {
            CueNextLoop();
            yield return new WaitForSeconds(trackSources[0].clip.length);
            Debug.Log("waited for clip length");
            yield return null;
        }
    }
}
