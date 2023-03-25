using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int trashNumber;
    public Transform controller;
    public bool pickedUp = false;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if(audioSource)
        {
            audioSource.time = 0.35f;
            audioSource.Play();
        }
    }

}
