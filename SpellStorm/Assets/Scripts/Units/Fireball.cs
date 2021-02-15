using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 attackerPos;
    public bool haveCoords = false;
    public Vector3 preyPos;
    public GameObject projectile;
    private List<string> enemyTags = new List<string>();
    private float fireballSpeed = 0.1f;
    private string goTag;
    private int initialDamage = 35;
    private Rigidbody2D rb;
    float fireballLifeTime = 10f;

    public void SetCoordForFireball(GameObject attacker, GameObject prey)
    {
         attackerPos = attacker.transform.position;
         preyPos = prey.transform.position;

        haveCoords = true;
        //  Debug.Log(preyPos);
        /*
        if (attacker.tag == "Enemy1")
        {
            GameObject fb1 = Pool.singleton.Get("Fireball1");
            if (fb1 != null)
            {
                fb1.transform.position = attackerPos;
                fb1.SetActive(true);
            }
        }else if (attacker.tag == "Enemy2")
        {
            GameObject fb2 = Pool.singleton.Get("Fireball2");
            if (fb2 != null)
            {
                fb2.transform.position = attackerPos;
                fb2.SetActive(true);
            }
        }
        
                
                */
                
                
                Instantiate(projectile, attackerPos, transform.rotation);
   
        /*
        this.attacker = attacker;
        this.prey = prey;
        Debug.Log(this.attacker);
        Debug.Log(this.prey);
        //  projectile.transform.position = Vector3.MoveTowards(attacker.transform.position, prey.transform.position, fireballSpeed);
    */
    }

    private void Awake()
    {
        GetEnemyTags();
    }

    private IEnumerator DestroyFireball()
    {
        yield return new WaitForSeconds(fireballLifeTime);
        Destroy(this.gameObject);
    }

    private void GetEnemyTags()
    {
        goTag = this.gameObject.tag;

        if (goTag == "Fireball1")
        {
            enemyTags.Add("EnemyBody2");
            enemyTags.Add("Castle2");
        }
        else if (goTag == "Fireball2")
        {
            enemyTags.Add("EnemyBody1");
            enemyTags.Add("Castle1");
        }
    }

    private void MoveFireballTowardsEnemy( )
    {
        // Debug.Log("preyPosi = " + preyPosi);
       //  var k = (preyPosi - this.transform.position);
        //   Debug.Log(k);
        //  this.rb.MovePosition(k);
        // this.rb.AddForceAtPosition(this.transform.position, preyPosi);

        

       // rb.velocity = preyPos - this.transform.position;


         this.transform.position = Vector3.MoveTowards(this.transform.position, preyPos, fireballSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  Debug.LogFormat("{0} HIT {1}", this, collision.gameObject);
        if (collision.gameObject.tag == enemyTags[0] || collision.gameObject.tag == enemyTags[1])
        {
            var health = collision.gameObject.GetComponentInParent<Health>();
            health.DecreaseHealth(initialDamage);
        }

        Destroy(this.gameObject);
    }

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyFireball());
      //  rb.velocity = preyPos - this.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (haveCoords)
        {
            //Debug.Log(haveCoords);

            MoveFireballTowardsEnemy();
        }
    }
}