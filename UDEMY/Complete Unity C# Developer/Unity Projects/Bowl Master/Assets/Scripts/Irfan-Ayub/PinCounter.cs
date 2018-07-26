using UnityEngine;
using UnityEngine.UI;


public class PinCounter : MonoBehaviour {

    public Text standingsPinsDisplayText;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    public int lastSettledCount = 10; // TODO make private
    private GameManager gameManager;

    // Use this for initialization
    void Start () {

        standingsPinsDisplayText.text = CountStanding().ToString();
        gameManager = GameObject.FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update () {

        if (ballOutOfPlay)
        {
            CheckStandingCount();
        }

    }

    public void Reset()
    {
        lastSettledCount = 10;
        standingsPinsDisplayText.text = "10";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballOutOfPlay = true;
        }
    }

    private void CheckStandingCount()
    {
        // Update the lastStandingCount
        // Call PinsHaveSettled() when they have
        standingsPinsDisplayText.color = Color.red;

        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        standingsPinsDisplayText.text = currentStanding.ToString();

        float settleTime = 3.0f; // How long to wait to consider pins settle

        if ((Time.time - lastChangeTime) > settleTime) // If last change > settleTime ago
        {
            PinsHaveSettled();
        }

    }

    private void PinsHaveSettled()
    {

        int standingCount = CountStanding();
        int pinFall = lastSettledCount - standingCount;
        lastSettledCount = standingCount;

        gameManager.Bowl(pinFall);
;
        lastStandingCount = -1; // Indicates pins have settled and ball not back in box
        ballOutOfPlay = false;
        standingsPinsDisplayText.color = Color.green;
    }

    public int CountStanding()
    {
        int standingPins = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            { standingPins++; }
        }


        return standingPins;
    }



}
