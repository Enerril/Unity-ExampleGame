using System.Collections;
using UnityEngine;

//not used anymore
public class RandomWalking : MonoBehaviour
{
    public GameObject go;
    static  bool isWandering = true;
    private bool isActiveWalking = true;
    private bool isCoroutineActive = false;
    [Range(0, 10)] public float walkSpeed = 1f;
    private Vector3 distUp, distDown, distRight, distLeft;
    private bool up, down, left, right = false;
  
    private int frameCounter = 51;
    private int maxFrameCounter;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    // Start is called before the first frame update
    private void Start()
    {
        //  Debug.Log(distUp.z);
        spriteRenderer = this.GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    private void Update()
    {
        if (isWandering)
        {
            if (up)
            {
                MoveUp();
                frameCounter++;
                spriteRenderer.sprite = sprites[0];
            }
            else if (down)
            {
                MoveDown();
                frameCounter++;
                spriteRenderer.sprite = sprites[1];
            }
            else if (right)
            {
                MoveRight();
                frameCounter++;
                spriteRenderer.sprite = sprites[3];
            }
            else if (left)
            {
                MoveLeft();
                frameCounter++;
                spriteRenderer.sprite = sprites[2];
            }

            if (frameCounter > maxFrameCounter)
            {
                up = false;
                down = false;
                right = false;
                left = false;

                SetRandomDistance();
                int a = Random.Range(1, 5);
              //  Debug.Log(a);
                switch (a)
                {
                    case 1:
                        up = true; break;

                    case 2:

                        down = true; break;
                    case 3:

                        left = true; break;
                    case 4:

                        right = true; break;
                }

                maxFrameCounter = Random.Range(50, 151);

                frameCounter = 0;
            }
        }
    }

    /*
     *      var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetmoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
     * */

    private IEnumerator PauseThreeSeconds()
    {
        yield return new WaitForSeconds(3f);
    }

    /*
    IEnumerator Move()
    {
        isCoroutineActive = true;
        SetRandomDistance();
        int a = Random.Range(1, 5);
        Debug.Log(a);
        switch (a)
        {
            case 1:
                for (int i = 0; i < 50; i++) { SetRandomDistance(); MoveUp();Debug.Log("up"); }

                break;

            case 2:

                for (int i = 0; i < 50; i++) { SetRandomDistance(); MoveDown(); }
                break;

            case 3:

                for (int i = 0; i < 50; i++) { SetRandomDistance(); MoveLeft(); }
                break;

            case 4:

                for (int i = 0; i < 50; i++) { SetRandomDistance(); MoveRight(); }
                break;
        }
        yield return new WaitForSeconds(3f);
        isCoroutineActive = false;
    }
    */

    private void MoveUp()
    {
        var targetPosition = distUp;
        var moveThisFrame = walkSpeed * Time.deltaTime;
        go.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, moveThisFrame);
       
        // Debug.Log(targetPosition);
    }

    private void MoveDown()
    {
        var targetPosition = distDown;
        var moveThisFrame = walkSpeed * Time.deltaTime;
        go.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, moveThisFrame);

        // Debug.Log(targetPosition);
    }

    private void MoveLeft()
    {
        var targetPosition = distLeft;
        var moveThisFrame = walkSpeed * Time.deltaTime;
        go.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, moveThisFrame);

        // Debug.Log(targetPosition);
    }

    private void MoveRight()
    {
        var targetPosition = distRight;
        var moveThisFrame = walkSpeed * Time.deltaTime;
        go.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, moveThisFrame);

        // Debug.Log(targetPosition);
    }

    private void SetRandomDistance()
    {
        var a = Random.Range(5, 15);

        distUp = go.transform.position + new Vector3(0, a, 0);
        distDown = go.transform.position + new Vector3(0, -a, 0);
        distRight = go.transform.position + new Vector3(a, 0, 0);
        distLeft = go.transform.position + new Vector3(-a, 0, 0);
    }

    public void ToggleWandering()
    {
        if (isWandering)
        {
            isWandering = false;
            return;
        }
        else if (!isWandering)
        {
            isWandering = true;
        }
    }

    public bool IsWandering()
    {
        return isWandering;
    }
    /*
    int RandomDistance()
    {
        int a = Random.Range(5, 10);
        return a;
    }*/
}