using System;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    [SerializeField]
    private Server server;

    [SerializeField]
    private PlayerController playerControllerPrefab;

    private Dictionary<int, PlayerController> playerControllers = new Dictionary<int, PlayerController>();

    public void CreatePlayer(PeerConnection peerConnection)
    {
        var playerController = Instantiate(playerControllerPrefab);
        var id = peerConnection.Id;
        playerController.Setup(id, server);
        playerControllers.Add(id, playerController);
        peerConnection.AddPlayer(playerController);
    }
}