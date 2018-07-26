using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedForAxis = 10.0f;
    public float speedForTransform = 10.0f;
    public float padding = 1.0f;
    public GameObject laserProjectile;
    public float laserProjectileSpeed = 10.0f;
    public float firingRate = 0.2f;
    public float health = 250;
    public AudioClip laserAudio;
    public LevelManager levelManager;

    float xMinPosition;
    float xMaxPosition;
    
	// Use this for initialization
	void Start () {

        GetWorldSpaceBoundries();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        { InvokeRepeating("FireLaser", 0.00001f, firingRate); }
        else if(Input.GetKeyUp(KeyCode.Space))
        { CancelInvoke(); }

        MoveWithTransform();
        ClampPlayerPositionX();
    }

    // to Calculate the boundaries of the Game World Space 
    void GetWorldSpaceBoundries()
    {
        // to calculate the distance between the player and the main camera
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        // to calculate the leftMost and the rightMost points (boundaries) of the screen
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

        xMinPosition = leftMost.x + padding;
        xMaxPosition = rightMost.x - padding;

    }

    // Function taught in UDEMY Course
    void MoveWithTransform()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        { gameObject.transform.position += Vector3.left * speedForTransform * Time.deltaTime; }

        else if (Input.GetKey(KeyCode.RightArrow))
        { gameObject.transform.position += Vector3.right * speedForTransform * Time.deltaTime; }
    }

     // Function written by Irfan-Ayub
    void MoveWithAxes()
    {
        float hMovement = (Input.GetAxis("Horizontal"));
        Vector3 movement = new Vector3(hMovement, gameObject.transform.position.y, 0.0f);
        gameObject.transform.position += movement * speedForAxis * Time.deltaTime;
    }

    // To clamp the position of the player in between the screen right and left corners
    void ClampPlayerPositionX()
    {
        float clampX = Mathf.Clamp(transform.position.x, xMinPosition, xMaxPosition);
        transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
    }

    // Fires the laser on y-axis
    void FireLaser()
    {
        Instantiate(laserProjectile, gameObject.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(laserAudio, transform.position); 
    }

    // called when the collider trigger event is called
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyLaser")
        {
            LaserProjectile laser = collision.gameObject.GetComponent<LaserProjectile>();
            if (laser)
            {
                health -= laser.GetDamage();
                laser.Hit();

                if (health <= 0)
                { Die(); }
            }
        }
    }

    // function to destory the player
    // called when the health of the player is <= 0
    private void Die()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Win Screen");
    }

}
