using System;

public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("Tutorial System")
    {
        // Log Hollo Wolod
        //        Add(new HelloWorldSystem(contexts));  
        // Create Log Message.
        //        Add(new LogMouseClickSystem(contexts));

        #region Create Movable Sprite And Follow Mouse Down Position.

        Add(new GameInitializeSystem());
        Add(new EmitInputSystem(contexts));
        Add(new MiddleMouseKeyChangeSpriteSystem(contexts));
        Add(new CreateMoverSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));
        Add(new CommandMoveSystem(contexts));
        Add(new MoveSystem(contexts));
        #endregion
        
        // Display Message.
        Add(new DebugMessageSystem(contexts));
        // Cleanup All Debug Messages.
        Add(new CleanupDebugMessageSystem(contexts));
    }
}