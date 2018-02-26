using UnityEngine;

public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("Tutorial System")
    {
        Add(new HelloWorldSystem(contexts));  
        // Create Log Message.
//        Add(new LogMouseClickSystem(contexts));
        Add(new EmitInputSystem(contexts));
        Add(new CreateMoverSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));
        Add(new CommandMoveSystem(contexts));
        Add(new MoveSystem(contexts));
        // Display Message.
        Add(new DebugMessageSystem(contexts));
        // Cleanup All Debug Messages.
        Add(new CleanupDebugMessageSystem(contexts));
    }
}

