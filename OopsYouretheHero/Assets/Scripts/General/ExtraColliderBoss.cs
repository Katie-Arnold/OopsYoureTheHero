using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraColliderBoss : MonoBehaviour
{
    GameObject b;

    private GoblinBossStats bossStat;
    private GobMinsStats minhealthNum;
    private GobMinsStats minhealthNum2;
    private GobMinsStats minhealthNum3;
    private GobMinsStats minhealthNum4;

    // Start is called before the first frame update
    void Start()
    {
        b = GameObject.FindGameObjectWithTag("Boss");
        GameObject gob = GameObject.FindGameObjectWithTag("GobMinion");
        GameObject goot = GameObject.FindGameObjectWithTag("GobMoot");
        GameObject gax = GameObject.FindGameObjectWithTag("GobMax");
        GameObject gart = GameObject.FindGameObjectWithTag("GobMud");

        bossStat = b.GetComponent<GoblinBossStats>();
        minhealthNum = gob.GetComponent<GobMinsStats>();
        minhealthNum2 = goot.GetComponent<GobMinsStats>();
        minhealthNum3 = gax.GetComponent<GobMinsStats>();
        minhealthNum4 = gart.GetComponent<GobMinsStats>();

        //this.gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {

        if(bossStat.isDead == true && minhealthNum.isDead == true && minhealthNum2.isDead == true && minhealthNum3.isDead == true && minhealthNum4.isDead == true)
        {
            Destroy(this.gameObject); 
        }
        
    }
}
