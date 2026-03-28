using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class SimpleAudio : MonoBehaviour
{
    [Header("Referencias")]

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button nextAudio;


    [SerializeField] List<AudioClip> listClips=new List<AudioClip>();

    [SerializeField] bool loopPlaylist = true;

    private int index = -1;

    private void Awake()
    {
        if (nextAudio != null)
        {
            nextAudio.onClick.AddListener(PlayNext);
        }
    }

    private void OnDestroy()
    {
        if (nextAudio != null)
        {
            nextAudio.onClick.RemoveListener(PlayNext);
        }
    }

    public void PlayNext()
    {
        if (listClips == null || listClips.Count == 0 || audioSource == null) return;

        index++;

        if (index >= listClips.Count)
        {
            if(loopPlaylist)
            {
                index = 0;
            }
            else
            {
                index=listClips.Count-1;
            }
        }

        audioSource.Stop();
        audioSource.clip = listClips[index];
        audioSource.Play();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
