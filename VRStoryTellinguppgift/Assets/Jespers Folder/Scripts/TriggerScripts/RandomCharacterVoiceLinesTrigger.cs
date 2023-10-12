using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacterVoiceLinesTrigger : MonoBehaviour
{
    private AudioManager m_AudioManager;
    private BoxCollider m_BoxCollider;

    [SerializeField]
    private int _eventsSoundIndex;

    private void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (other.tag == "Player")
        {
            m_AudioManager.RandomCharacterSounds(_eventsSoundIndex);
            m_BoxCollider.enabled = false;
        }
    }

}
