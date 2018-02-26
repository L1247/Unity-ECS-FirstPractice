using Entitas;
using UnityEngine;

public class TestSystem : IExecuteSystem
{
    private GameContext _context ;

    public TestSystem(Contexts context)
    {
        _context = context.game;
    }

    public void Execute()
    {
        _context.CreateEntity().AddDebugMessage("Test");
    }
}