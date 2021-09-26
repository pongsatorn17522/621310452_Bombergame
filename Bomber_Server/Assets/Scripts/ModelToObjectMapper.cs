using LiteNetLib;
using Newtonsoft.Json.Linq;
using UnityEngine;
using System;
using System.Collections.Generic;

public class ModelToObjectMapper
{
    private ServerController serverController;
    private Dictionary<string, Action<PeerConnection, JObject>> Deserializes;

    private Dictionary<string, Action<PeerConnection, JObject>> CreateDeserializes() => new Dictionary<string, Action<PeerConnection, JObject>>
    {
        //TODO [Model.CLASS_NAME] = callFunction,
    };

     public ModelToObjectMapper(ServerController serverController)
    {
        Deserializes = CreateDeserializes();
        this.serverController = serverController;
    }

    public void DeserializeToFunction(NetPeer peer, string json)
    {
        Debug.Log("DeserializeToFunction");
        var jObject = JObject.Parse(json);
        if (jObject.TryGetValue("ClassName", out var value))
        {
            var className = value.ToString();
            var peerConnection = peer.Tag as PeerConnection;
            Deserializes[className](peerConnection, jObject);
        }
    }
    

}