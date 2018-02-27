using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEditor;
using UnityEngine;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    private readonly Transform _viewContainer = new GameObject("Game Views").transform;
    private readonly GameContext _context;
    
    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView ;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity gameEntity in entities)
        {
            GameObject go = new GameObject("Game View");
            go.transform.SetParent(_viewContainer , false);
            gameEntity.AddView(go);
            go.Link(gameEntity, _context);
        }
    }
}