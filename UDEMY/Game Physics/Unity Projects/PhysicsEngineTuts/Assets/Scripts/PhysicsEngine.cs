using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {

    public float mass; // [kg]
    public Vector3 velocityVector = Vector3.zero; // [ m/s ]
    public Vector3 netForceVector; // N [ kg m/s^2 ]

    private List<Vector3> forceVectorList = new List<Vector3>();

	// Use this for initialization
	void Start () {

        SetupForceTrails();
    }
	
	// Update is called once per frame
	void Update () {

        
		
	}

    // FixedUpdate is called every fixed frame
    private void FixedUpdate()
    {
        RenderTrails();
        //CalculateGravity();
        UpdatePosition();

        // Update position
        gameObject.transform.position += velocityVector * Time.deltaTime;

    }

    public void AddForces(Vector3 forceVector)
    {
        forceVectorList.Add(forceVector);
    }



    void UpdatePosition()
    {
        // Sum Forces and Clear Forces List
        netForceVector = Vector3.zero;
        foreach (Vector3 forceVector in forceVectorList)
        {
            netForceVector = netForceVector + forceVector;
        }
        forceVectorList = new List<Vector3>(); // clear the list

        // Calculate position duw to the Net Forces
        Vector3 accelerationVector = netForceVector / mass;
        velocityVector += accelerationVector * Time.deltaTime;
    }



    /// <summary>
    /// Code for Drawing Froce Trails
    /// </summary>
    /// 

    public bool showTrails = true;

    private LineRenderer lineRenderer;
    private int numberOfForces;

    // Use this for initialization
    void SetupForceTrails()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(Color.yellow, Color.yellow);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.useWorldSpace = false;
    }
    
    void RenderTrails()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = forceVectorList.Count;
            lineRenderer.SetVertexCount(numberOfForces * 2);
            int i = 0;
            foreach (Vector3 forceVector in forceVectorList)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
