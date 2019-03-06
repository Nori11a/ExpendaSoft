﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    public float speed;
    public Done_Boundary boundary;

    public float RotateSpeed = 100f; //speed of the rotation

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    //these are used to calculate the foward/back and rotation of the player
    private float moveAxis;
    private float turnAxis;

    void Update()
    {
        //this allows the player to shoot lasers
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire) //Input.GetKey is used to figure out what key needs to be pushed, and it'll know it's the Space Bar because of "KeyCode.Space"
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        //this will figure out movement when you push a directional arrow key or WASD
        moveAxis = Input.GetAxis("Vertical");
        turnAxis = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move(); //checks for position
        Turn(); //checks for rotation
    }

    private void Move()
    {
        Vector3 movement = transform.forward * moveAxis * speed * Time.deltaTime;

        GetComponent<Rigidbody>().velocity = movement * speed;
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up * turnAxis * RotateSpeed * Time.deltaTime);
    }
}