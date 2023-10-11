using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRidingHoodAudioTrigger : MonoBehaviour
{
    private AudioManager m_AudioManager;

    [SerializeField]
    private int _eventsSoundIndex;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (other.tag == "Player")
        {
            m_AudioManager.RidingHoodSounds(_eventsSoundIndex);
            this.gameObject.SetActive(false);
        }
    }

}
