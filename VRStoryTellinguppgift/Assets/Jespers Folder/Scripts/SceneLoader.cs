using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    private int sceneIndex = 0;

    [SerializeField]
    private float timer;
    [SerializeField]
    private float fadeOutSetActiveTimer;

    [SerializeField]
    private GameObject obj;

    private void Start()
    {
        obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {            
            StartCoroutine(LoadSceneRoutine());
            StartCoroutine(FadeOutRoutine());
        }
    }


    private IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSeconds(timer);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex++);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(fadeOutSetActiveTimer);
        obj.SetActive(true);
    }
}
