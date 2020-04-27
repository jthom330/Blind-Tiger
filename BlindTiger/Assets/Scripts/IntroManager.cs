using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public Cinemachine.CinemachineDollyCart cart;
    public GameObject dolly;
    public Animator doorAnim;
    public GameObject entranceArea;
    public Camera main;
    public PlayerMovement movement;

    public Cinemachine.CinemachineVirtualCamera sky;
    public Cinemachine.CinemachineVirtualCamera sign;
    public Cinemachine.CinemachineVirtualCamera start;

    private bool doorAnimationPlayed = false;
    // Start is called before the first frame update
    private void Start()
    {
        movement.moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(cart.m_Position > 0.1f && sky.Priority != 0)
        {
            sky.Priority = 0;
        }

        if (cart.m_Position > 0.4f && !doorAnimationPlayed)
        {
            doorAnim.SetTrigger("Open");
            doorAnimationPlayed = true;
        }

        if (cart.m_Position > 0.45f && sign.Priority != 0)
        {
            sign.Priority = 0;
        }

        if(cart.m_Position == 1f)
        {
            movement.moving = false;
            main.useOcclusionCulling = true;
            sky.gameObject.SetActive(false);
            sign.gameObject.SetActive(false);
            entranceArea.SetActive(false);
            dolly.SetActive(false);

            cart.gameObject.SetActive(false); //self
        }
    }
}
