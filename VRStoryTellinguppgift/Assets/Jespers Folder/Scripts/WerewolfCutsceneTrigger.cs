using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WerewolfCutsceneTrigger : MonoBehaviour
{
    private WereWolfAnimationController _enemy;
    void Start()
    {
        _enemy = GameObject.Find("WereWolf").GetComponent<WereWolfAnimationController>();
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
