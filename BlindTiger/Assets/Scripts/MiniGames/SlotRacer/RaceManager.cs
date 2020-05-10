using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject car1;

    public bool car1Wins;
    public GameObject car2;
    public bool car2Wins;

    public int lapsToWin = 1;

    private SlotCarProperties slotCarScript1;

    private SlotCarProperties slotCarScript2;

    // Start is called before the first frame update
    private void Start()
    {
        slotCarScript1 = car1.GetComponent<SlotCarProperties>();
        slotCarScript2 = car2.GetComponent<SlotCarProperties>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (slotCarScript1.lapCount == lapsToWin && slotCarScript2.lapCount < lapsToWin)
        {
            car1Wins = true;
            Debug.Log("Car 1 Wins");
        }

        if (slotCarScript2.lapCount == lapsToWin && slotCarScript1.lapCount < lapsToWin)
        {
            car2Wins = true;
            Debug.Log("Car 2 Wins!");
        }
    }
}