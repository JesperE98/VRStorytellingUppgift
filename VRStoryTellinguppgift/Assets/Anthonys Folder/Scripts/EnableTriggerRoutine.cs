using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTriggerRoutine : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float timer;

    private void Start()
    {
        obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(EnableObjectRoutine());
        }
    }

    private IEnumerator EnableObjectRoutine()
    {
        yield return new WaitForSeconds(timer);
        obj.SetActive(true);
    }
}
