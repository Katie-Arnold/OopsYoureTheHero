using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float roteSpeed = 100f;

    private bool isWander;
    private bool isRoteLeft;
    private bool isRoteRight;
    private bool isBounce;

   public Animator anim; 


    void Awake()
    {

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (isWander == false)
        {
            StartCoroutine(Wander());
        }
        if (isRoteRight == true)
        {
            anim.Play("Idle");
            transform.Rotate(transform.up * Time.deltaTime * -roteSpeed);
        }
        if (isRoteLeft == true)
        {
            anim.Play("Idle");
            transform.Rotate(transform.up * Time.deltaTime * roteSpeed);
        }
        if (isBounce == true)
        {
            //dDebug.Log("Walking forward");
            anim.Play("Moving");
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }


    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isWander = true;

        yield return new WaitForSeconds(walkWait);
        isBounce = true;
        yield return new WaitForSeconds(walkTime);
        isBounce = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRoteRight = true;
            yield return new WaitForSeconds(rotTime);
            isRoteRight = false;
        }
        if (rotateLorR == 2)
        {
            isRoteLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRoteLeft = false;
        }

        isWander = false;
    }


}
