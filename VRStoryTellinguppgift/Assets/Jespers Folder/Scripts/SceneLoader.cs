using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int sceneIndex = 0;

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
            obj.SetActive(true);
            StartCoroutine(LoadSceneRoutine());
        }
    }


    private IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex++);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }


    }
}
