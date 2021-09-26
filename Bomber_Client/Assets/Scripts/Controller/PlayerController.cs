using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    private int id;
    private Client client;
    private bool isCurrentPlayer;

    public int Id => id;

    internal void Setup(CreatePlayerModel model, Client client)
    {
        id = model.Id;
        transform.position = model.Position;
        this.client = client;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetCurrentPlayer()
    {
        isCurrentPlayer = true;
    }
}