using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAudioTrigger : MonoBehaviour
{
    private AudioManager m_AudioManager;

    [SerializeField]
    private int _eventsSoundIndex;
    private BoxCollider boxCollider;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (other.tag == "Player")
        {
            m_AudioManager.WolfSounds(_eventsSoundIndex);
            boxCollider.enabled = false;
        }
    }

}
