using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Trigger : MonoBehaviour
{
    public bool playerClose;
    public GameObject popUp;
    public GameObject townCol;

    [SerializeField] private string parameterName;

    //public Boss_Look look;

    private GoblinShoot minAttack;
    private GoblinShoot minAttack2;
    private GoblinShoot minAttack3;
    private GoblinShoot minAttack4;

    private Animator run;

    private Animator shoot;
    private Animator shoot2;
    private Animator shoot3;
    private Animator shoot4;

    private  GameObject col;

    private PlayerController playerStateCombat;

    

    public GameObject tieDownPop;

    public GoblinBossStats bosshealthNum;
    public GobMinsStats minhealthNum;
    public GobMinsStats minhealthNum2;
    public GobMinsStats minhealthNum3;
    public GobMinsStats minhealthNum4;

    private Enemies bossEnemies;
    private Enemies minEnemies;
    private Enemies min2Enemies;
    private Enemies min3Enemies;
    private Enemies min4Enemies;

    public ParticleSystem[] enemyRing;
    public Canvas[] gobHealthBars; 
    //Boss_Run run;

    // public Boss stats; 


    // Start is called before the first frame update
    void Start()
    {
        
        playerClose = false;

        tieDownPop.SetActive(false);
        // popUp.SetActive(false);

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerStateCombat = p.GetComponent<PlayerController>();
        

        //look = GetComponent<Boss_Look>();

        GameObject r = GameObject.FindGameObjectWithTag("Boss");
        GameObject gob = GameObject.FindGameObjectWithTag("GobMinion");
        GameObject goot = GameObject.FindGameObjectWithTag("GobMoot");
        GameObject gax = GameObject.FindGameObjectWithTag("GobMax");
        GameObject gart = GameObject.FindGameObjectWithTag("GobMud");

        col = GameObject.FindGameObjectWithTag("Blocks");
        col.SetActive(false);

       townCol.SetActive(false);

        run = r.GetComponent<Animator>();

        
        bosshealthNum = r.GetComponent<GoblinBossStats>();
        minhealthNum = gob.GetComponent<GobMinsStats>();
        minhealthNum2 = goot.GetComponent<GobMinsStats>();
        minhealthNum3 = gax.GetComponent<GobMinsStats>();
        minhealthNum4 = gart.GetComponent<GobMinsStats>();

        bossEnemies = r.GetComponent<Enemies>();
        minEnemies = gob.GetComponent<Enemies>();
        min2Enemies = goot.GetComponent<Enemies>();
        min3Enemies = gax.GetComponent<Enemies>();
        min4Enemies = gart.GetComponent<Enemies>();

        bossEnemies.enabled = false;
        minEnemies.enabled = false;
        min2Enemies.enabled = false;
        min3Enemies.enabled = false;
        min4Enemies.enabled = false;

        shoot = gob.GetComponent<Animator>();
        shoot2 = goot.GetComponent<Animator>();
        shoot3 = gax.GetComponent<Animator>();
        shoot4 = gart.GetComponent<Animator>();


        minAttack = gob.GetComponent<GoblinShoot>();
        minAttack2 = goot.GetComponent<GoblinShoot>();
        minAttack3 = gax.GetComponent<GoblinShoot>();
        minAttack4 = gart.GetComponent<GoblinShoot>();

        //look.enabled = false; 
        run.SetBool("isFighting", false);

        shoot.SetBool("IsFighting", false);
        shoot2.SetBool("IsFighting", false);
        shoot3.SetBool("IsFighting", false);
        shoot4.SetBool("IsFighting", false);

        for (int i = 0; i < enemyRing.Length; i++)
        {

            // enemyRing[i].Stop(false);

            print(enemyRing.Length);
        }

        for (int i = 0; i < gobHealthBars.Length; i++)
        {

            // enemyRing[i].Stop(false)

            gobHealthBars[i].enabled = false;

            print(gobHealthBars.Length);
        }

        

    }

    // Update is called once per frame
    void Update()
    {

        if (playerClose == true)
        {

            BossActivate();
            
        }


        //if (bosshealthNum.health == 0 && minhealthNum.health == 0 && minhealthNum2.health == 0 && minhealthNum3.health == 0 && minhealthNum4.health == 0)
        //{
            
        //    // Debug.Log("boss music is cut");
        //    CutCombatMusic();
        //    col.SetActive(false);
        //    townCol.SetActive(true);

        //    Destroy(this, 5);
        //}

        if (bosshealthNum.isDead == true && minhealthNum.isDead == true && minhealthNum2.isDead == true && minhealthNum3.isDead == true && minhealthNum4.isDead == true)
        {

            // Debug.Log("boss music is cut");
            CutCombatMusic();
            col.SetActive(false);
            townCol.SetActive(true);

            Destroy(this, 5);
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("player in collider");

            playerClose = true;

        }

    }


  void OnTriggerExit(Collider other)
    { 
        {
            playerClose = false;

        }

    }

    public void BossActivate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            // look.enabled = true;
            //col.SetActive(true);
            // playerStateCombat.isExploring = false;

            col.SetActive(true);

            if (playerStateCombat.isExploring == true)
            {
                playerStateCombat.isExploring = false;
            }

            playerStateCombat.inCombat = true;
            //playerStateCombat.isExploring = false;


            if (playerStateCombat.hasRope == true)
            {
                tieDownPop.SetActive(true);
            }


           // col.SetActive(true);
            Destroy(popUp);

            bossEnemies.enabled = true;
            minEnemies.enabled = true;
            min2Enemies.enabled = true;
            min3Enemies.enabled = true;
            min4Enemies.enabled = true;

            for (int i = 0; i < enemyRing.Length; i++)
            {

                //enemyRing[i].SetActive(true);
                enemyRing[i].Play();
                Debug.Log("rings started");
            }

            for (int i = 0; i < gobHealthBars.Length; i++)
            {
                
                gobHealthBars[i].enabled = true;
                
            }

            //  col.SetActive(true);


            run.SetBool("isFighting", true);


            shoot.SetTrigger("IsFighting");
            shoot2.SetTrigger("IsFighting");
            shoot3.SetTrigger("IsFighting");
            shoot4.SetTrigger("IsFighting");


            minAttack.isAttack = true;
            minAttack2.isAttack = true;
            minAttack3.isAttack = true;
            minAttack4.isAttack = true;

        }


    }

    public void CutCombatMusic()
    {

        if (playerStateCombat.inCombat == true)
        {
            playerStateCombat.inCombat = false;
        }

        playerStateCombat.isExploring = true;

        

        //playerStateCombat.inCombat = false;
        //playerStateCombat.isExploring = true;
        // playerStateCombat.inCombat = false;
        Debug.Log("boss is dead");


    }
}

