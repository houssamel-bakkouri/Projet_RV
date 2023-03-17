using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int trashNumber;
    public Transform controller;
    public bool pickedUp = false;

    public AudioClip popAudio;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
            {
                transform.position = controller.position;
                transform.rotation = controller.rotation;
            }
    }

    public void PlayAudio()
    {
        if(popAudio)
            audioSource.Play();
    }

}
