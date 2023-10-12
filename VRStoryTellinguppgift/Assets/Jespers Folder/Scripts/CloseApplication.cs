using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApplication : MonoBehaviour
{
    [SerializeField]
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CloaseApplicationRoutine());
    }

    private IEnumerator CloaseApplicationRoutine()
    {
        yield return new WaitForSeconds(timer);
        Application.Quit();
    }
}
