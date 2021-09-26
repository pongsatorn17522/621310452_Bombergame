using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelToObjectMapper
{
    private Dictionary<string, Action<JObject>> Deserializes;

    private readonly ClientController clientController;

    private Dictionary<string, Action<JObject>> CreateDeserializes() => new Dictionary<string, Action<JObject>>
    {
        [CreatePlayerModel.CLASS_NAME] = OnCreatePlayerModel,
        [InitDataModel.CLASS_NAME] = OnInitData
    };

    public ModelToObjectMapper(ClientController clientController)
    {
        Deserializes = CreateDeserializes();
        this.clientController = clientController;
    }

    public void DeserializeToFunction(string json)
    {
        var jObject = JObject.Parse(json);
        if (jObject.TryGetValue("ClassName", out var value))
        {
            var className = value.ToString();
            Deserializes[className](jObject);
        }
    }
    private void OnCreatePlayerModel(JObject jObject)
    {
        var model = jObject.ToObject<CreatePlayerModel>();
        clientController.OnCreatePlayer(model);
    }
    private void OnInitData(JObject jObject)
    {
        var model = jObject.ToObject<InitDataModel>();
        clientController.OnInitData(model);
    }

}