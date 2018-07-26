using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public GameObject gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        { projectileParent = new GameObject("Projectiles"); }

        animator = gameObject.GetComponent<Animator>();

        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    private void Update()
    {
        if(IsAttackerAheadInLane())
        { animator.SetBool("isAttacking", true); }
        else { animator.SetBool("isAttacking", false); }
    }

    // Look Through all enemies spawners and set myLaneSpawner if found //
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == gameObject.transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(gameObject.name + " Can't Find Spawner in Lane");

    }

    bool IsAttackerAheadInLane()
    {
        // if the spawner has no childs
        if (myLaneSpawner.transform.childCount <= 0)
            return false;

        // for every child of the spawner
        foreach(Transform child in myLaneSpawner.transform)
        {
            // check if they are infront of us
            if (child.position.x > gameObject.transform.position.x)
                return true;
        }

        // if they are behind us
        return false;
    }

    private void Fire()
    {
        GameObject newFire = Instantiate(projectile, projectileParent.transform) as GameObject;
        newFire.transform.position = gun.transform.position;
    }
}
