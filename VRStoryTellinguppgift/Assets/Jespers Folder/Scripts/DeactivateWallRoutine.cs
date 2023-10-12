using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWallRoutine : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WallRoutine());
        }
    }

    private IEnumerator WallRoutine()
    {
        yield return new WaitForSeconds(timer);
        obj.SetActive(false);
    }
}
