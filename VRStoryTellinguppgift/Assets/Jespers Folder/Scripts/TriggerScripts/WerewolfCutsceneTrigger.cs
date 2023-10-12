using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WerewolfCutsceneTrigger : MonoBehaviour
{
    private WereWolfController _enemy;
    void Start()
    {
        _enemy = GameObject.Find("WereWolf").GetComponent<WereWolfController>();
        _enemy._triggerEnter = false;
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Player")
        {
            _enemy._triggerEnter = true;
        }
    }
}
