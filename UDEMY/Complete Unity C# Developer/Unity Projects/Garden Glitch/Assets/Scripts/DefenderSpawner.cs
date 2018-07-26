using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;
    private StarsCount starsCountScript;

    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        starsCountScript = GameObject.FindObjectOfType<StarsCount>();
        if (!defenderParent)
        { defenderParent = new GameObject("Defenders"); }

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown()
    {
        //print(SnapToGrid(CalculateWorldPointForMouseClick()));
        Vector2 defenderPosition = SnapToGrid(CalculateWorldPointForMouseClick());
        GameObject defender = Button.selectedDefender;

        if (defender)
        {
            int defenderCost = defender.GetComponent<Defender>().starCost;
            if(starsCountScript.UseStars(defenderCost) == StarsCount.Status.SUCESS)
            { Instantiate(Button.selectedDefender, defenderPosition, Quaternion.identity, defenderParent.transform); }
            else
            { Debug.Log("Insuficient stars to spawn"); }
        }
    }

    private Vector2 SnapToGrid(Vector2 worldPoints)
    {
        return new Vector2(Mathf.RoundToInt(worldPoints.x), Mathf.RoundToInt(worldPoints.y));
    }


    private Vector2 CalculateWorldPointForMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10.0f;

        Vector3 screenToWorldVector = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPosition = myCamera.ScreenToWorldPoint(screenToWorldVector);

        return worldPosition;
    }
}
