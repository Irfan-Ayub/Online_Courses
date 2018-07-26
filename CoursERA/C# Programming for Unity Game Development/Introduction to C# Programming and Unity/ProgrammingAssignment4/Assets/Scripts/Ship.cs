using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a Ship controller class
/// </summary>
public class Ship : MonoBehaviour {

    Rigidbody2D rb2D;

    Vector2 thrustDirection;
    

    const float ThrustForce = 10.0f;
    const float RotateDegreesPerSecond = 90.0f;
    float colliderRadius;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {

        rb2D = gameObject.GetComponent<Rigidbody2D>();
        thrustDirection = new Vector2(1.0f, 0.0f);
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {

        float rotationInput = Input.GetAxis("Rotate");
        float rotationAmount = 0;
        if (rotationInput !=0)
            rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

        if (rotationInput < 0)
            rotationAmount *= -1;

        gameObject.transform.Rotate(Vector3.forward * rotationAmount);

        float zRotation = gameObject.transform.eulerAngles.z;
        zRotation *= Mathf.Deg2Rad;
        thrustDirection = new Vector2(Mathf.Cos(zRotation), Mathf.Sin(zRotation));
    }

    /// <summary>
    /// Called every fixed frame
    /// </summary>
    private void FixedUpdate()
    {
        float thrustForce = Input.GetAxis("Thrust");
        //Debug.Log(thrustForce * ThrustForce * thrustDirection);
        rb2D.AddForce(thrustForce * ThrustForce * thrustDirection, ForceMode2D.Force);
    }

    /// <summary>
    /// Called when the gameObject becomes invisible from the game screen
    /// </summary>
    private void OnBecameInvisible()
    {
        if(gameObject.transform.position.x + colliderRadius >  ScreenUtils.ScreenRight)
        {
            Debug.Log("Ship is out Right");
            gameObject.transform.position = new Vector2(-gameObject.transform.position.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.x - colliderRadius > ScreenUtils.ScreenLeft)
        {
            Debug.Log("Ship is out Left");
            gameObject.transform.position = new Vector2(-gameObject.transform.position.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y + colliderRadius > ScreenUtils.ScreenTop)
        {
            Debug.Log("Ship is out Top");
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y - colliderRadius < ScreenUtils.ScreenBottom)
        {
            Debug.Log("Ship is out Bottom");
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -gameObject.transform.position.y);
        }

    }
}
