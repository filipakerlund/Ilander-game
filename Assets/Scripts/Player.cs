using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] PlayerUI playerUI;

    [SerializeField] private float upSpeed = 60.0f;
    [SerializeField] private float sideSpeed = 24.0f;
    [SerializeField] private float impactTolerance = -.17f;
    [SerializeField] private float boostSpeed = 30.0f;
    private float startSpeed;
    public bool crash;

    private Rigidbody2D rigidBody;

    // readonly and add physics into player physics
    private bool upBoosting;
    private bool rightBoosting;
    private bool leftBoosting;

    // maybe change to constant. this is not intended to be changed at runtime. 
    readonly float xMinMax = 8.5f;
    readonly float yMinMax = 4.5f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startSpeed = upSpeed;
    }

    private void Update()
    {
        upBoosting = Input.GetKey(KeyCode.UpArrow);
        rightBoosting = Input.GetKey(KeyCode.RightArrow);
        leftBoosting = Input.GetKey(KeyCode.LeftArrow);

        Boundary();
    }
    private void FixedUpdate()
    {
        if (upBoosting)
        {
            rigidBody.AddForce(this.transform.up * this.upSpeed * Time.fixedDeltaTime);
        }

        if (rightBoosting)
        {
            rigidBody.AddForce(this.transform.right * this.sideSpeed * Time.fixedDeltaTime);
        }

        if (leftBoosting)
        {
            rigidBody.AddForce(this.transform.right * -1 * this.sideSpeed * Time.fixedDeltaTime);
        }
        crash = CheckImpact();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // CompareTag with Ground then check if shuttle crashed or not.
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (crash == true)
            {
                Debug.Log("Shuttle Chrashed!");
                playerUI.LandingScore(0);
                playerUI.CrashScreen();
                // Destroy gameobject. Give scoring. Display "crash" + score and buttons: main menu/retry.
            }
            else if (crash == false)
            {
                Debug.Log("Shuttle Landed SAFELY!");
                playerUI.LandingScore(100);
                playerUI.LandScreen();
                // Destroy gameobject. Give scoring. Display "land" + score and buttons: main menu/next level.
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.transform.CompareTag("Boost"))
        {
            Debug.Log("Player boost true.");
            IncreasedSpeed();
        }
    }
    IEnumerator Boost()
    {
        upSpeed += boostSpeed;
        sideSpeed += boostSpeed;
        yield return new WaitForSeconds(1.5f);
        upSpeed = startSpeed;
        sideSpeed += boostSpeed;
    }
    private void IncreasedSpeed()
    {
        StartCoroutine(Boost());
    }

    // Clamp position of -x/x and -y/y. So that the player stays on the map.
    private void Boundary()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xMinMax, xMinMax), Mathf.Clamp(transform.position.y, -yMinMax, yMinMax));
    }
    public bool CheckImpact()
    {
        float fallVelocity = rigidBody.velocity.y;
        return fallVelocity < impactTolerance;
    }

}
