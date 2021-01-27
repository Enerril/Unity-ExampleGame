using UnityEngine;

public class Drive : MonoBehaviour
{
    public GameObject go;
    public float speed = 1f;
    public Sprite[] sprites;
    private Animator animator;
    private Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        if (Input.GetKey("w"))
        {
            {
                go.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                spriteRenderer.sprite = sprites[0];
                //   animator.SetTrigger("m_UP");
            }
        }
        else if (Input.GetKey("s"))
        {
            {
                go.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
                spriteRenderer.sprite = sprites[1];
                //  animator.SetTrigger("m_DOWN");
            }
        }
        else if (Input.GetKey("a"))
        {
            {
                go.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                spriteRenderer.sprite = sprites[2];
                //  animator.SetTrigger("m_LEFT");
            }
        }
        else if (Input.GetKey("d"))
        {
            {
                go.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                spriteRenderer.sprite = sprites[3];
                //  animator.SetTrigger("m_RIGHT");
            }
        }
        /*
        animator.SetBool("m_Up", false);
        animator.SetBool("m_Down", false);
        animator.SetBool("m_Left", false);
        animator.SetBool("m_Right", false);
        */

        //spriteRenderer.sprite = defaultSprite;
    }
}