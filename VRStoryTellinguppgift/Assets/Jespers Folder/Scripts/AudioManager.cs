using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AudioManager :  MonoBehaviour
{
    [SerializeField]
    private EventReference[] m_WolfEvents;
    [SerializeField]
    private EventReference[] m_RidingHoodEvents;
    [SerializeField]
    private EventReference[] m_NarratorEvents;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _wolf;

    public FMOD.Studio.EventInstance m_WolfInstance;
    public FMOD.Studio.EventInstance m_RidingHoodInstance;
    public FMOD.Studio.EventInstance m_NarratorInstance;

    private void Awake()
    {

    }

    public void NarratorSound(int i)
    {
        RuntimeManager.PlayOneShotAttached(m_NarratorEvents[i], _player);
    }

    public void WolfSounds(int i)
    {
        RuntimeManager.PlayOneShotAttached(m_WolfEvents[i], _wolf);
    }

    public void RidingHoodSounds(int i)
    {
        RuntimeManager.PlayOneShotAttached(m_RidingHoodEvents[i], _player);
    }

    /*
    public void StartInstances()
    {
        m_WolfInstance.start();
        m_RidingHoodInstance.start();
        m_NarratorInstance.start();
    }

    public void PauseInstances()
    {
        m_WolfInstance.setPaused(true);
        m_RidingHoodInstance.setPaused(true);
        m_NarratorInstance.setPaused(true);
    }

    public void UnPauseInstances()
    {
        m_WolfInstance.setPaused(false);
        m_RidingHoodInstance.setPaused(false);
        m_NarratorInstance.setPaused(false);
    }
    */

}
