// CommandMoveSystem.cs  
using System.Collections.Generic;  
using Entitas;
using UnityEngine;

// 点击左键后，用于创建移动命令  
public class CommandMoveSystem : ReactiveSystem<InputEntity>  
{  
    readonly IGroup<GameEntity> _movers;  
  
    // 获取拥有Mover标志Entity的组  
    public CommandMoveSystem(Contexts contexts) : base(contexts.input)  
    {  
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover));  
    }  
  
    // 过滤左键点击，和右键点击那个System一样  
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)  
    {  
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));  
    }  
  
    protected override bool Filter(InputEntity entity)  
    {  
        return entity.hasMouseDown;  
    }  
  
    // 在Entity上设置移动命令Move  
    protected override void Execute(List<InputEntity> entities)  
    {  
        foreach (InputEntity e in entities)  
        {
            GameEntity[] movers = _movers.GetEntities();  
            foreach (GameEntity entity in movers)  
                entity.ReplaceMove(e.mouseDown.position);  
        }  
    }  
}  