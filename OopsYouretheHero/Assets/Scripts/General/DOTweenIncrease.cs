using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenIncrease : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.SetTweensCapacity(2000, 100);
        Debug.Log("tweens upgradeed?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
