using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {

    public enum SightSensitivity { STRICT, LOOSE };

    public SightSensitivity sensitivity = SightSensitivity.STRICT;

    public float fieldOfView = 45.0f;

    public Transform target = null;
    public Transform eyePoint = null;

    public bool canSeeTarget = false;

    public SphereCollider thisCollider;

    public Vector3 lastKnownSighting = Vector3.zero;

    bool InFOV()
    {
        Vector3 dirToTarget = target.position - eyePoint.position;

        float angle = Vector3.Angle(eyePoint.forward, dirToTarget);

        if (angle <= fieldOfView)
            return true;

        return false;
    }

    bool ClearLineOfSight()
    {
        RaycastHit info;

        if (Physics.Raycast(eyePoint.position, (target.position - eyePoint.position).normalized, out info, thisCollider.radius))
        {
            if (info.transform.CompareTag("Player"))
                return true;
        }
        
        return false;
    }

    void UpdateSight()
    {
        switch(sensitivity)
        {
            case SightSensitivity.STRICT:
                canSeeTarget = InFOV() && ClearLineOfSight();
                break;

            case SightSensitivity.LOOSE:
                canSeeTarget = InFOV() || ClearLineOfSight();
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //canSeeTarget = InFOV();

        UpdateSight();
        if (canSeeTarget)
            lastKnownSighting = target.position;

    }
}
