using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FadeOutTriggerRoutine());
        }
    }

    private IEnumerator FadeOutTriggerRoutine()
    {
        yield return new WaitForSeconds(timer);
        obj.SetActive(true);
    }
}
