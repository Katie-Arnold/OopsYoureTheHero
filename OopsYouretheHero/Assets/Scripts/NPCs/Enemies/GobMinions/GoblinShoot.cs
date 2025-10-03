using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinShoot : MonoBehaviour
{
    public PlayerStats playerHealth;
    public GobMinsStats enemyHealth; 


    public int attackDmg;


    public float attackRange = 1f;

    public LayerMask attackMask;
    public Vector3 attackOffset;

    [SerializeField] private float timer = 5;
    private float arrowTime;

    public GameObject enemyArrow;
    public Transform spawnPoint;

    private Animator fight;

    public bool isAttack = false;

    public ParticleSystem arrowTrail; 


    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        enemyHealth = this.GetComponent<GobMinsStats>(); 

        playerHealth = p.GetComponent<PlayerStats>();

        fight = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == true)
        {
            Shoot();

           
        }

        if(enemyHealth.isDead == true)
        {
            Destroy(this);
        }
        
    }


    public void Shoot()
    {
        arrowTime -= Time.deltaTime; 

        if(arrowTime > 0 )
        {
            return;
        }

        arrowTime = timer;

        GameObject arrowObj = Instantiate(enemyArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody arrowRig = arrowObj.GetComponent<Rigidbody>();
        arrowRig.AddForce(arrowRig.transform.forward * 1500f);
        arrowTrail.Play();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.arrowAttack, this.transform.position);

        //1000+ needed for arrows to fly fast

        //player hit/take damage code

        Vector3 pos = transform.position;

        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        Collider[] colInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        foreach (Collider nearbyObj in colInfo)
        {
            if (nearbyObj.CompareTag("Player") && playerHealth != null)
            {

                playerHealth.TakeDamage(attackDmg);
            }



        }

        Destroy(arrowObj, 3);


      
    }

}
