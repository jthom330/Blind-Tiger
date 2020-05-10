using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 0.05f;
    public float midpoint;
    public PlayerMovement movement;
    private float timer;

    private void Update()
    {
        var waveslice = 0.0f;

        var cSharpConversion = transform.localPosition;

        if (!movement.moving)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2) timer = timer - Mathf.PI * 2;
        }

        if (waveslice != 0)
        {
            var translateChange = waveslice * bobbingAmount;
            float totalAxes = 1;
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }
}