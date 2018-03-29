using System.Attributes;
using Entitas;
using UnityEngine;

public class AttributeControllerMono : MonoBehaviour
{
    private Systems _systems;

    // Use this for initialization
    void Start()
    {
        var contexts = Contexts.sharedInstance;

        _systems = new Systems()
            .Add(new AttributeTestSystem());
        
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        
        _systems.Cleanup();
    }
}