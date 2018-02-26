// MoveSystem.cs  

using Entitas;
using UnityEngine;

// 根据Move命令，执行移动，实现IExecuteSystem的Execute方法，每帧都会执行，  
// ICleanupSystem实现Cleanup方法，同样每帧执行，但会在所有System的Execute之后  
public class MoveSystem : IExecuteSystem, ICleanupSystem  
{  
    readonly IGroup<GameEntity> _moves;  
    readonly IGroup<GameEntity> _moveCompletes;  
    const    float              _speed = 4f;  
  
    // 获取有移动目标Move组和完成移动MoveComplete组  
    public MoveSystem(Contexts contexts)  
    {  
        _moves         = contexts.game.GetGroup(GameMatcher.Move);  
        _moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);  
    }  
  
    // 拥有目标的Mover每帧执行  
    public void Execute()  
    {  
        foreach (GameEntity e in _moves.GetEntities())  
        {  
            // 计算下一个GameObject的位置，并替换  
            Vector2 dir         = e.move.target    - e.position.value;  
            Vector2 newPosition = e.position.value + dir.normalized * _speed * Time.deltaTime;  
            e.ReplacePosition(newPosition);  
  
            // 计算下一个方向  
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;  
            e.ReplaceDirection(angle);  
  
            // 如果距离在0.5f之内，则判断为移动完成，移除Move命令，并添加移动完成标志  
            float dist = dir.magnitude;  
            if (dist <= 0.5f)  
            {  
                e.RemoveMove();  
                e.isMoveComplete = true;  
            }  
        }  
    }  
  
    // 清除所有MoveComplete，MoveComplete暂时没有作用  
    public void Cleanup()  
    {  
        foreach (GameEntity e in _moveCompletes.GetEntities())  
        {  
            e.isMoveComplete = false;  
        }  
    }  
}