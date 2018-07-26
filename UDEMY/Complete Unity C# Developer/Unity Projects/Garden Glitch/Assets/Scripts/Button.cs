using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonsArray;
    private Text costText;
	
    // Use this for initialization
	void Start () {

        buttonsArray = GameObject.FindObjectsOfType<Button>();
        costText = gameObject.GetComponentInChildren<Text>();
        if(costText)
        { costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString(); }
        else
        { Debug.LogWarning(name + " has no Cost Text"); }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //Debug.Log("Button Pressed -- " + gameObject.name);

        foreach( Button button in buttonsArray)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        //print(selectedDefender);
    }
}
