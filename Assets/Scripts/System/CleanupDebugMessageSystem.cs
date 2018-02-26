using Entitas;
using UnityEngine;

public class CleanupDebugMessageSystem : ICleanupSystem
{
    private readonly GameContext        _Context;
    private readonly IGroup<GameEntity> _debugmessage;

    public CleanupDebugMessageSystem(Contexts contexts)
    {
        _Context      = contexts.game;
        _debugmessage = _Context.GetGroup(GameMatcher.DebugMessage);
    }

    public void Cleanup()
    {
        foreach (var e in _debugmessage.GetEntities())
            e.Destroy();
    }
}