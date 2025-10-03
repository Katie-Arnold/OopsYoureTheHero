using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(LoadYourAsyncScene());

        Debug.Log("Loading next scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void LoadLevel()
    //{
    //    StartCoroutine(LoadYourAsyncScene());

    //    Debug.Log("Loading next scene");

    //}

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        yield return new WaitForSeconds(5);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
