using System.Collections;
using UnityEngine;

public class FightMode : MonoBehaviour
{
    public GameObject projectile;
    private AIController aiController;
    private GameObject attacker;
    private bool closingMode = false;
    private float closingSpeed = 0.06f;
    private float defaultMinCastDistance = 3f;
    private float defaultMinMeleeDistance = 1f;
    private AIController enemyAIController;
    private bool fightingMode = false;
    private Fireball fireball;
    private Sight goSight;
    private RandomWalking goWalking;
    private bool isCoroutineActive = false;
    private GameObject prey;
    private float pauseBetweenCast=2f;
    bool subscribed=false;

    private float DistanceBetweenObjects(ref GameObject obj1, ref GameObject obj2)
    {
        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
        /*  if (obj1 != null & obj1 != null)
          {
             // return Vector3.Distance(obj1.transform.position, obj2.transform.position);
          }
          else
          {
              return defaultMinCastDistance;
          }*/
    }

    private void EnemyKilled()
    {
        enemyAIController.DiedIHave -= EnemyKilled;
        goSight.seeAnything = false;
        fightingMode = false;
        goWalking.isWandering = true;

        closingMode = false;
        subscribed = false;
        //       Debug.Log("MY ENeMY IS DEAD");
    }

    private void MoveTowardsEnemy(ref GameObject attacker, ref GameObject prey)
    {
        //  Debug.Log("WORK");
        // Debug.Log(attackerPos + "--- " + preyPos);
        if (attacker != null && prey != null)
        {
            if (defaultMinCastDistance < DistanceBetweenObjects(ref attacker, ref prey))
            {
                this.transform.position = Vector3.MoveTowards(attacker.transform.position, prey.transform.position, closingSpeed); // тоже минут на 20 залип из-за того что забыл инициализировать closingSpeed ppc
            }
            else
            {
                closingMode = false;
                fightingMode = true;
            }
        }
        else
        {
            EnemyKilled();
        }
        
    }

    private void OnDisable()
    {
        aiController.startClosing -= StartClosingMode;
        if (subscribed)
          {
        enemyAIController.DiedIHave -= EnemyKilled;
       }
    }

    private void OnEnable()
    {
        aiController = this.GetComponent<AIController>();
        goSight = this.GetComponent<Sight>();

        aiController.startClosing += StartClosingMode;
        goWalking = this.GetComponent<RandomWalking>();
    }

    private void Start()
    {
    }

    private void StartClosingMode(GameObject attacker, GameObject prey)
    {
        goWalking.isWandering = false;
        goSight.seeAnything = true;
        goSight.circleCollider2.radius = goSight.defaultColliderSize;

        //   Debug.Log(prey.name);

        this.attacker = attacker;
        this.prey = prey;

        //   Debug.Log(DistanceBetweenObjects(ref attacker, ref prey));
        closingMode = true;
        /* if(prey.tag=="Castle1" || prey.tag == "Castle2")
         {
             return;
         }*/
        enemyAIController = prey.GetComponentInParent<AIController>();
        //Debug.Log(enemyAIController);
        enemyAIController.DiedIHave += EnemyKilled;
        subscribed = true;

 
    }

    private IEnumerator StartFighting(GameObject attacker, GameObject prey)
    {
        isCoroutineActive = true;
        fireball = projectile.GetComponent<Fireball>();

        fireball.SetCoordForFireball(attacker, prey);

        /*
        Instantiate(projectile, transform.position,transform.rotation);
        fireball = projectile.gameObject.GetComponent<Fireball>();

        fireball.attacker = attacker;
        fireball.prey = prey;
        fireball.haveCoords = true;
        */
        yield return new WaitForSeconds(pauseBetweenCast);
        isCoroutineActive = false;
    }

    private void Update()
    {
        if (closingMode)
        {
            //      var attackerPos = this.attacker.transform.position;
            //     var preyPos = this.prey.transform.position;
            MoveTowardsEnemy(ref attacker, ref prey);
        }

        if (fightingMode)
        {
            if (!isCoroutineActive)
            {
                //           if (attacker != null && prey != null)
                //          {
                StartCoroutine(StartFighting(attacker, prey));
                //          }
            }
        }
    }
}