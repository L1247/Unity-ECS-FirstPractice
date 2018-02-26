// RenderPositionSystem.cs  
using System.Collections.Generic;  
using Entitas;  
  
// 处理Position值发生变化后的处理，直接赋值就OK，不多说  
public class RenderPositionSystem : ReactiveSystem<GameEntity>
{
    public RenderPositionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            e.view.gameObject.transform.position = e.position.value;
        }
    }
}