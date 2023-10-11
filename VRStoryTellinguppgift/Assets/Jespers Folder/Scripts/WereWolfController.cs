using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using FMODUnity;
using UnityEngine.UIElements;

public class WereWolfController : MonoBehaviour
{

    private Animator m_anim;
    private GameManager m_GameManager;
    private AudioManager m_AudioManager;
    [SerializeField]
    private BoxCollider _boxCollider;

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private Transform _pointA, _pointB, _pointC;
    [SerializeField]
    private Transform _currentTarget;
    [SerializeField]
    private int m_EventIndex;
    public bool _triggerEnter = false;
    [SerializeField]
    private GameObject[] _triggerPoints;

    private Vector3 _currentPosition;
    private bool _coroutineTimerDone = false;
    private bool _triggerZone = false;


    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        m_anim = GetComponent<Animator>();
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        _currentTarget = _pointA;
    }

    void Update()
    {

        if (_triggerEnter == true)
        {
           Movement();
        }
        else if (_currentTarget == _pointC)
        {
            Movement2();
        }
        else
        {
            return;
        }
        AudioRoutine();
    }

    public void Movement()
    {
        float step = speed * Time.deltaTime;

        _currentPosition = transform.position;

        if (_coroutineTimerDone == false)
        {
            _currentTarget = _pointA;
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, step);
            m_anim.SetTrigger("StartWalking");
        }


        if (_currentPosition == _pointA.position && _coroutineTimerDone == false)
        {
            m_anim.ResetTrigger("StartWalking");
            m_anim.SetTrigger("StopWalking");
            StartCoroutine(ContinueToPointBRoutine(34.0f));
        }

        if (_currentTarget == _pointB && _coroutineTimerDone != false && _triggerZone != false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, step);
            transform.rotation = Quaternion.Euler(0.0f, 40.0f, 0f);

            m_anim.SetTrigger("StartWalking");
        }
        else if (_currentTarget == _pointB && _coroutineTimerDone != false && _triggerZone == false)
        {
            m_anim.ResetTrigger("StartWalking");
            m_anim.SetTrigger("StopWalking");
        }

        if (_currentPosition == _pointB.position)
        {
            transform.rotation = Quaternion.Euler(0.0f, -80.0f, 0f);
            m_anim.ResetTrigger("StartWalking");
            m_anim.SetTrigger("StopWalking");
            StartCoroutine(ContinueToPointCRoutine(22.0f));

        }
    }

    private void Movement2 ()
    {
        float step = speed * Time.deltaTime;
        _boxCollider.enabled = false;

        speed = 2.0f;
        m_anim.ResetTrigger("StopWalking");
        m_anim.SetTrigger("StartRunning");

        transform.rotation = Quaternion.Euler(0.0f, 10.0f, 0f);
        transform.position = Vector3.MoveTowards(transform.position, _pointC.position, step);
        StartCoroutine(DeactivateWolfRoutine());
    }

    private void AudioRoutine()
    {
        if (_currentPosition == _pointA.position)
        {
            if (GameManager.Instance.DialougeIsActive == false)
            {
                m_AudioManager.WolfSounds(m_EventIndex);
                m_AudioManager.RidingHoodSounds(m_EventIndex);
            }
            GameManager.Instance.DialougeIsActive = true;
        }

        if (_currentTarget == _pointB && _triggerZone == true && GameManager.Instance.DialougeIsActive2 == false)
        {
            if (GameManager.Instance.DialougeIsActive2 == false)
            {
                _triggerPoints[0].SetActive(true);
            }
            GameManager.Instance.DialougeIsActive2 = true;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            speed = 1.0f;
            _triggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.tag == "Player")
        {
            speed = 0f;
            _triggerZone = false;
        }
    }


    private IEnumerator ContinueToPointBRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _coroutineTimerDone = true;
        _currentTarget = _pointB;        
    }

    private IEnumerator ContinueToPointCRoutine(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        _triggerEnter = false;
        _currentTarget = _pointC;

    }

    IEnumerator DeactivateWolfRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        this.gameObject.SetActive(false);
    }
}
