using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorAnimation : MonoBehaviour
{
    private Animator m_anim, m_anim2;

    private void Start()
    {
        m_anim = GameObject.Find("leftDoor").GetComponent<Animator>();
        m_anim2 = GameObject.Find("rightDoor").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_anim.SetTrigger("LeftDoorOpen");
            m_anim2.SetTrigger("DoorOpen");
        }
    }
}
