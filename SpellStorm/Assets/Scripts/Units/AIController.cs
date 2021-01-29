using UnityEngine;

public delegate void Born();

public delegate void Died();

public delegate void startClosing(GameObject attacker, GameObject prey);

public class AIController : MonoBehaviour
{
    public GameObject go;

    private Sight goSight;

    private RandomWalking goWalking;

    public event Born bornWasI;

    public event Died DiedIHave;

    public event startClosing startClosing;

    public void EnemyDetected(ref GameObject go, ref GameObject goe)
    {
        //   Debug.LogFormat("I SEE {0}",goe.tag);

        startClosing?.Invoke(go, goe);
    }

    private void OnDisable()
    {
        if (goSight != null)
        {
            goSight.SeeEnemy -= EnemyDetected;
        }
    //    Debug.Log("I HAVE DIED");
        DiedIHave?.Invoke();
    }

    private void OnEnable()
    {
        goSight = this.GetComponent<Sight>();
        goWalking = this.GetComponent<RandomWalking>();
        if (goSight != null)
        {
            goSight.SeeEnemy += EnemyDetected;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        bornWasI?.Invoke();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}