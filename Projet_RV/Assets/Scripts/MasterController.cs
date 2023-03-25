using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public bool isHolding = false;
    public List<Cube> inHandCube;
    public OVRInput.Button button;
    public OVRInput.Controller controller;


    private void Start()
    {
        inHandCube = new();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(button) && !isHolding)
        {
            isHolding = true;
            foreach (var cube in inHandCube)
            {   
                Debug.Log("Cube 1");
                cube.controller = transform;
                Debug.Log("Cube 2");
                cube.transform.rotation = transform.rotation;
                Debug.Log("Cube 3");
                if (cube.GetComponent<Rigidbody>())
                {
                    cube.PlayAudio();
                    Rigidbody rb = cube.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }
            }
        }else if (!OVRInput.Get(button) && isHolding)
        {
            isHolding = false;
            foreach (var cube in inHandCube)
            {
                cube.pickedUp = false;
                cube.controller = cube.transform;
                if (cube.GetComponent<Rigidbody>())
                {
                    Rigidbody rb = cube.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    Vector3 rawVelocity = OVRInput.GetLocalControllerVelocity(controller);
                    Debug.Log( "vel " +rawVelocity);
                    Vector3 velocity = new Vector3(rawVelocity.z, rawVelocity.y, -rawVelocity.x);
                    rb.velocity = velocity;

                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Cube>(out var cube) && inHandCube.Count == 0)
        {
            Debug.Log("Get cube");
            inHandCube.Add(cube);
            Debug.Log("Add cube");
            cube.pickedUp = true;
            //cube.PlayAudio();
            Debug.Log("End");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Cube>(out var cube) && inHandCube.Count > 0)
        {
            inHandCube.Remove(cube);
            cube.pickedUp = false;
        }
    }
}
        