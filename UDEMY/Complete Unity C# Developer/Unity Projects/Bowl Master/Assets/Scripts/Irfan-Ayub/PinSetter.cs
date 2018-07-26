using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public float distanceToRaise = 40f;
    public GameObject pinsPrefab;
    
    private Animator animator;
    private PinCounter pinCounter;


    // Use this for initialization
    void Start () {

        animator = gameObject.GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();

    }

    // Update is called once per frame
    void Update () {

    }

    public void RaisePins()
    {
        // raise standing Pins only by distanceToRaise
        //Debug.Log("Raising Pins");
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }

    }

    public void LowerPins()
    {
        // lower the pins to the ground again
        Debug.Log("Lowering Pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        GameObject.Instantiate(pinsPrefab, new Vector3(0, distanceToRaise, 1829), Quaternion.identity);
    }

    public void PerformAction(ActionMaster.Action bowlAction)
    {
        //ActionMaster.Action bowlAction = actionMaster.Bowl(pinsFall);

        if (bowlAction == ActionMaster.Action.Tidy)
        { animator.SetTrigger("tidyTrigger"); }

        else if (bowlAction == ActionMaster.Action.Reset || bowlAction == ActionMaster.Action.EndTurn)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }

        else if (bowlAction == ActionMaster.Action.EndTurn)
        { throw new UnityException("Don't Know to End Game"); }
    }









}
