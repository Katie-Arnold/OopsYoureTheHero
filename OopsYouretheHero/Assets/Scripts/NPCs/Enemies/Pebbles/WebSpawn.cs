using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpawn : MonoBehaviour
{

    [SerializeField]
    public GameObject webPrefab;
    public Transform spawnPoint;


    public float timer;
    public float webTime;
    float disappearTime = 8f;

    public bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WebSpawnInstantiate();
    }

    public void WebSpawnInstantiate()
    {

        webTime -= Time.deltaTime;

        if (webTime > 0)
        {
            return;
        }

        webTime = timer;

        GameObject webObj = Instantiate(webPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;


        Destroy(webObj, disappearTime);
    }


}
