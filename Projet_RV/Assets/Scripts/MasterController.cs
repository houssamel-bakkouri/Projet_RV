using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public bool isHolding = false;
    public List<Cube> inHandCube = new List<Cube>();
    public OVRInput.Button button;
    public OVRInput.Controller controller;
    

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(button) && !isHolding)
        {
            isHolding = true;
            foreach (var cube in inHandCube)
            {

                cube.controller = transform;
                cube.transform.rotation = transform.rotation;
                if (cube.GetComponent<Rigidbody>())
                {
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
                    Debug.Log(rawVelocity);
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
            inHandCube.Add(cube);
            cube.pickedUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Cube>(out var cube) && inHandCube.Count > 0)
        {
            inHandCube.Remove(cube);
        }
    }
}
        