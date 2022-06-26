
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D RB;
    // Start is called before the first frame update

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        maju();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
    public void jump()
    {
        
            if (isGrounded == true)
            {
                RB.AddForce(Vector3.up * JumpForce);
                isGrounded = false;
            }
        
    }
    void maju()
    {
        if (isGrounded == true)
        {
            RB.AddForce(Vector2.right * 100);
        }
    }
}