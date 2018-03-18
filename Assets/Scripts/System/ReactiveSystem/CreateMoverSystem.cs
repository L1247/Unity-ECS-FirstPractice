using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Internal.VR;

public class CreateMoverSystem : ReactiveSystem<InputEntity>
{
    private readonly  GameContext _gameContext;

    public CreateMoverSystem( Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse
                                                          , InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity inputEntity in entities)
        {
            GameEntity entity = _gameContext.CreateEntity();
            entity.isMover = true;
            entity.AddPosition(inputEntity.mouseDown.position);
            entity.AddDirection(Random.Range(0,360));
//            entity.AddSprite("head1");
            entity.isSpriteRender = true;
        }
    }
}