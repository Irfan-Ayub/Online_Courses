using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    
    public Text text;

    private enum States {

        CELL,
        MIRROR, SHEETS_0, LOCK_0,
        CELL_MIRROR, SHEETS_1, LOCK_1,
        CORRIDOR_0,
        STAIRS_0, FLOOR, CLOSET_DOOR,
        STAIRS_1, CORRIDOR_1, IN_CLOSET,
        STAIRS_2, CORRIDOR_2,
        CORRIDOR_3, COURTYARD
    };
    private States myState;

	// Use this for initialization
	void Start () {

        myState = States.CELL;
        if(myState == States.CELL) { Cell(); }
	}
	
	// Update is called once per frame
	void Update () {

        //print(myState);

        if      (myState == States.CELL)        { Cell();  }
        else if (myState == States.SHEETS_0)    { Sheets_0(); }
        else if (myState == States.MIRROR)      { Mirror(); }
        else if (myState == States.LOCK_0)      { Lock_0(); }
        else if (myState == States.SHEETS_1)    { Sheets_1(); }
        else if (myState == States.CELL_MIRROR) { Cell_Mirror(); }
        else if (myState == States.LOCK_1)      { Lock_1(); }
        else if (myState == States.CORRIDOR_0)  { Corridor_0(); }
        else if (myState == States.CORRIDOR_0)  { Corridor_0(); }
        else if (myState == States.STAIRS_0)    {Stairs_0(); }
        else if (myState == States.FLOOR)       { Floor(); }
        else if (myState == States.CLOSET_DOOR) { Closet_Door(); }
        else if (myState == States.STAIRS_1)    { Stairs_1(); }
        else if (myState == States.CORRIDOR_1)  { Corridor_1(); }
        else if (myState == States.IN_CLOSET)   { In_Closet(); }
        else if (myState == States.STAIRS_2)    { Stairs_2(); }
        else if (myState == States.CORRIDOR_2)  { Corridor_2(); }
        else if (myState == States.CORRIDOR_3)  { Corridor_3(); }
        else if (myState == States.COURTYARD)   { Courtyard(); }

    }

    void Cell()
    {
        text.text = "You are in a prison cell, and you want to escape. " +
                         "There are some dirty sheets on the bed, a mirror on the wall, " +
                         "and the door is locked from the outside. \n\n" +
                         "Press S to view Sheets, M to view Mirror and L to view Lock";
        
        if      (Input.GetKeyDown(KeyCode.S)) { myState = States.SHEETS_0; }
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.MIRROR; }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.LOCK_0; }

    }

    void Sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time somebody changed them. The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press R to Return to roaming your cell";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CELL; }
    }

    void Mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the mirror, or R to Return to cell";

        if      (Input.GetKeyDown(KeyCode.T)) { myState = States.CELL_MIRROR; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.CELL; }

    }

    void Lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CELL; }
    }

    void Sheets_1()
    {
        text.text = "Holding a mirror in your hand doesn't make the sheets look " +
                    "any better.\n\n" +
                    "Press R to Return to roaming your cell";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CELL_MIRROR; }
    }

    void Cell_Mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view Sheets, or L to view Lock";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.SHEETS_1; }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.LOCK_1; }

    }


    void Lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open, or R to Return to your cell";

        if      (Input.GetKeyDown(KeyCode.O)) { myState = States.CORRIDOR_0; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.CELL_MIRROR; }

    }


    void Corridor_0()
    {
        text.text = "You're out of your cell, but not out of trouble." +
                    "You are in the corridor, there's a closet and some stairs leading to " +
                    "the courtyard. There's also various detritus on the floor.\n\n" +
                    "C to view the Closet, F to inspect the Floor, and S to climb the stairs";

        if      (Input.GetKeyDown(KeyCode.C)) { myState = States.CLOSET_DOOR; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.FLOOR; }
        else if (Input.GetKeyDown(KeyCode.S)) { myState = States.STAIRS_0; }


    }

    void Stairs_0()
    {
        text.text = "You start walking up the stairs towards the outside light. " +
                    "You realise it's not break time, and you'll be caught immediately. " +
                    "You slither back down the stairs and reconsider.\n\n" +
                    "Press R to Return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CORRIDOR_0; }

    }

    void Floor()
    {
        text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
                    "Press R to Return to the standing, or H to take the Hairclip.";
        if      (Input.GetKeyDown(KeyCode.R)) { myState = States.CORRIDOR_0; }
        else if (Input.GetKeyDown(KeyCode.H)) { myState = States.CORRIDOR_1; }
    }

    void Closet_Door()
    {
        text.text = "You are looking at a closet door, unfortunately it's locked. " +
                    "Maybe you could find something around to help enourage it open?\n\n" +
                    "Press R to Return to the corridor";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CORRIDOR_0; }
    }

    void Stairs_1()
    {
        text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
                    "confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
                    "Press R to Retreat down the stairs";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CORRIDOR_1; }

    }

    void Corridor_1()
    {
        text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
                    "Now what? You wonder if that lock on the closet would succumb to " +
                    "to some lock-picking?\n\n" +
                    "P to Pick the lock, and S to climb the stairs";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.IN_CLOSET; }
        else if (Input.GetKeyDown(KeyCode.S)) { myState = States.STAIRS_1; }
    }

    void In_Closet()
    {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
                    "Seems like your day is looking-up.\n\n" +
                    "Press D to Dress up, or R to Return to the corridor";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CORRIDOR_2; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.CORRIDOR_3; }
    }

    void Stairs_2()
    {
        text.text = "You feel smug for picking the closet door open, and are still armed with " +
                    "a hairclip (now badly bent). Even these achievements together don't give " +
                    "you the courage to climb up the staris to your death!\n\n" +
                    "Press R to Return to the corridor";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.CORRIDOR_2; }
    }

    void Corridor_2()
    {
        text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
                    "Press C to revisit the Closet, and S to climb the stairs";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.IN_CLOSET; }
        else if (Input.GetKeyDown(KeyCode.S)) { myState = States.STAIRS_2; }

    }

    void Courtyard()
    {
        text.text = "You walk through the courtyard dressed as a cleaner. " +
                    "The guard tips his hat at you as you waltz past, claiming " +
                    "your freedom. You heart races as you walk into the sunset.\n\n" +
                    "Press P to Play again.";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.CELL; }
    }

    void Corridor_3()
    {
        text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
                    "You strongly consider the run for freedom.\n\n" +
                    "Press S to take the Stairs, or U to Undress";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.COURTYARD; }
        else if (Input.GetKeyDown(KeyCode.U)) { myState = States.IN_CLOSET; }
    }
}
