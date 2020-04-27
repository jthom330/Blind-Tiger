using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public PlayerMovement movement;
    public Animator startButtonAnim;
    public Animator canvasSettingsAnim;
    public GameObject cart;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //pull settings from player preps and set to globally accessable variables.

        //fade out menu
        startButtonAnim.SetTrigger("start");


        //StartCoroutine(IntroMovement());
        cart.SetActive(true);
    }

    public void OpenSettings()
    {
        canvasSettingsAnim.SetBool("active", true);
    }

    public void CloseSettings()
    {
        canvasSettingsAnim.SetBool("active", false);
    }

    private IEnumerator IntroMovement()
    {
        yield return StartCoroutine(movement.Look(movement.entrance));
        yield return StartCoroutine(movement.Move(movement.entrance));

        yield return StartCoroutine(movement.Look(movement.start));

        //open door
        //doorAnim.SetTrigger("Open");
        yield return StartCoroutine(movement.Wait(1));
        //start sound fade

        yield return StartCoroutine(movement.Move(movement.start));
        //close door

        //despawn outside
        yield return null;
    }
}
