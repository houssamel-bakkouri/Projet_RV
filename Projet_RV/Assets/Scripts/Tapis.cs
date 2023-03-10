using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapis : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var pos = _rb.position;
        _rb.position += Vector3.back * (speed * Time.fixedDeltaTime);
        _rb.MovePosition(pos);
    }
}
