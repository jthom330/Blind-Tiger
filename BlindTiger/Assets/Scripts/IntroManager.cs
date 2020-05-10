using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public GameObject dolly;
    public Animator doorAnim;
    public AudioSource intro;
    public AudioSource gameRoom;
    public GameObject entranceArea;
    public Camera main;
    public PlayerMovement movement;

    public CinemachineVirtualCamera sign;
    public CinemachineVirtualCamera sky;
    public CinemachineVirtualCamera start;
    
    private bool _doorAnimationPlayed = false;


    // Start is called before the first frame update
    private void Start()
    {
        movement.moving = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (cart.m_Position > 0.1f && sky.Priority != 0)
        {
            sky.Priority = 0;
        }

        if (cart.m_Position > 0.4f && !_doorAnimationPlayed)
        {
            doorAnim.SetTrigger("Open");
            _doorAnimationPlayed = true;
            
            //fade in music here
            StartCoroutine(FadeMusic(intro.volume, 0, intro));
            StartCoroutine(FadeMusic(gameRoom.volume, 1, gameRoom));
        }

        if (cart.m_Position > 0.45f && sign.Priority != 0)
        {
            sign.Priority = 0;
        }

        if (Math.Abs(cart.m_Position - 1f) < 0.0001f)
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

    IEnumerator FadeMusic(float from, float to, AudioSource music)
    {
        float elapsedTime = 0;
        const float waitTime = 2;
        
        while (elapsedTime < waitTime)
        {
            music.volume = Mathf.Lerp(from, to, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
 
            yield return null;
        }  
        // Make sure we got there
        music.volume = to;

        if (Math.Abs(to) < 0.001f)
        {
            music.enabled = false;
        }
        
        yield return null;
    }
}