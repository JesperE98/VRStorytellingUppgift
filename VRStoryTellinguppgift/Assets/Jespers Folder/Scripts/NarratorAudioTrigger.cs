using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorAudioTrigger : MonoBehaviour
{
    private AudioManager m_AudioManager;
    private BoxCollider boxCollider;


    [SerializeField]
    private int _eventsSoundIndex;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (other.tag == "Player")
        {
            m_AudioManager.NarratorSound(_eventsSoundIndex);
            boxCollider.enabled = false;
        }
    }

}
