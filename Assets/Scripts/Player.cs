using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // Floats
    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 150f;

    // Bools
    public bool grounded;
    public bool canDoubleJump;
    public bool wallSliding;
    public bool facingRight = true;
    public bool wallCheck;

    // Stats
    public int curHealth;
    public int maxHealth = 6;

    // References
    private Rigidbody2D rbody;
    private Animator anim;
    private GameMaster gm;
    private Transform playerGraphics;
    public Transform wallCheckPoint;
    public LayerMask wallLayerMask;
    public Color textColor;

    void Awake()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        playerGraphics = transform.FindChild("Graphics");

        ColorUtility.TryParseHtmlString("#CCB222FF", out textColor);

        curHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CombatTextManager.Instance.CreateText(transform.position, "Damage Number.", textColor);
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rbody.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            //transform.rotation = Quaternion.Euler(180, 0, 180);
            //transform.localScale = new Vector3(-1, 1, 1);
            if (facingRight == true)
            {
                Flip();
            }
            facingRight = false;
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //transform.localScale = new Vector3(1, 1, 1);
            if (facingRight == false)
            {
                Flip();
            }
            facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && !wallSliding)
        {
            if (grounded) { 
                rbody.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            } else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rbody.velocity = new Vector2(rbody.velocity.x, 0);
                    rbody.AddForce(Vector2.up * jumpPower / 1.25f);
                }
            }
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }

        if (!grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);

            if (facingRight && Input.GetAxis("Horizontal") > 0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f)
            {
                if (wallCheck)
                {
                    HandleWallSliding();
                }
            }
        }
        if (wallCheck == false || grounded)
        {
            wallSliding = false;
        }
    }

    void HandleWallSliding()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, -0.7f);
        wallSliding = true;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (facingRight)
            {
                rbody.AddForce(new Vector2(-2, 2) * jumpPower);
            } else
            {
                rbody.AddForce(new Vector2(2, 2) * jumpPower);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rbody.velocity;
        easeVelocity.y = rbody.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        if(grounded)
        {
            rbody.velocity = easeVelocity;
        }

        if(grounded)
        {
            rbody.AddForce((Vector2.right * speed) * h);
        } else
        {
            rbody.AddForce((Vector2.right * speed / 2) * h);
        }

        if(rbody.velocity.x >= maxSpeed)
        {
            rbody.velocity = new Vector2(maxSpeed, rbody.velocity.y);
        }

        if(rbody.velocity.x <= -maxSpeed)
        {
            rbody.velocity = new Vector2(-maxSpeed, rbody.velocity.y);
        }
    }

    void Die()
    {
        // Restart. (Add death scene later)
        SceneManager.LoadScene("Dev_Room");
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }

    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockDir)
    {
        float timer = 0;
        rbody.velocity = new Vector2(rbody.velocity.x, 0);

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rbody.AddForce(new Vector3(knockDir.x * -100, knockDir.y + knockPwr, transform.position.z));
        }

        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GoldNugget"))
        {
            Destroy(col.gameObject);
            gm.gNuggets += 1;

        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
