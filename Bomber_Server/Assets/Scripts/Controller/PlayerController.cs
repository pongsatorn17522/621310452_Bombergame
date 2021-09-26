using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    private int id;
    private Server server;
    public int Id => id;

    public Vector3 Position => transform.position;

    // Start is called before the first frame update
    private void Start()
    {
        server.SendCreatePlayer(this);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    internal void Setup(int id, Server server)
    {
        this.id = id;
        this.server = server;
    }
}