using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    public string sceneToLoadOnTrigger;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");

        levelManager.LoadScene(sceneToLoadOnTrigger);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision2D");
    }
}
