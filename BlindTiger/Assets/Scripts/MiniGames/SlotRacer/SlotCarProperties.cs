using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCarProperties : MonoBehaviour
{
    public const float DEFAULT_LAP_TICK_COUNTDOWN_TIME = 3.0f;
    public float lapCountdownTime;
    bool canIncrementLap = false;

    public int lapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        lapCountdownTime = DEFAULT_LAP_TICK_COUNTDOWN_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        lapCountdownTime -= Time.deltaTime;

        if (lapCountdownTime <= 0)
        {
            canIncrementLap = true;
        }
    }

    void OnCollisionEnter(Collision aCollisionObject)
    {
        if (aCollisionObject.collider.tag == "finishline")
        {
            if(canIncrementLap)
            {
                IncrementLap();
            }
        }
    }

    void IncrementLap()
    {
        lapCount++;
        ResetLapCountdown();
        Debug.Log(lapCount);
    }

    void ResetLapCountdown()
    {
        canIncrementLap = false;
        lapCountdownTime = DEFAULT_LAP_TICK_COUNTDOWN_TIME;
    }
}
