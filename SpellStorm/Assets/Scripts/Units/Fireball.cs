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

    public void SetCoordForFireball(GameObject attacker, GameObject prey)
    {
         attackerPos = attacker.transform.position;
         preyPos = prey.transform.position;

        haveCoords = true;
      //  Debug.Log(preyPos);
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
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
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

    private void MoveFireballTowardsEnemy(ref Vector3 attPos, ref Vector3 preyPosi)
    {
       // Debug.Log("preyPosi = " + preyPosi);

       // this.rb.AddForce(preyPosi);
       // this.rb.AddForceAtPosition(this.transform.position, preyPosi);
       this.transform.position = Vector3.MoveTowards(this.transform.position, preyPosi, fireballSpeed);
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

            MoveFireballTowardsEnemy(ref attackerPos, ref preyPos);
        }
    }
}