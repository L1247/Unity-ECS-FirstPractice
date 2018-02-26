using UnityEngine;

public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("Tutorial System")
    {
        Add(new HelloWorldSystem(contexts));  
        // Create Log Message.
//        Add(new LogMouseClickSystem(contexts));
        Add(new EmitInputSystem(contexts));
        // Display Message.
        Add(new DebugMessageSystem(contexts));
        // Cleanup All Debug Messages.
        Add(new CleanupDebugMessageSystem(contexts));
    }
}

