using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TurnOffMouse : MonoBehaviour
{
    GameObject lastselect;



    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lastselect = new GameObject();

    }

    // Update is called once per frame
    void Update()
    {
        //if (EventSystem.current.currentSelectedGameObject == null)
        //    EventSystem.current.SetSelectedGameObject(myFirstSelectedGameObject);

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }

    }
}
