// MiddleMouseKeyChangeSpriteSystem.cs  
using UnityEngine;  
using Entitas;
using UnityEditor;
using Utility;

public class MiddleMouseKeyChangeSpriteSystem : IExecuteSystem  
{  
    readonly IGroup<GameEntity> _sprites;

    private GameContext _gameContext;  
    // 获取所有拥有Sprite的组  
    public MiddleMouseKeyChangeSpriteSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _sprites = contexts.game.GetGroup(GameMatcher.Sprite);  
    }  
  
    // 如果按下的中键，则替换  
    public void Execute()  
    {  
        if(Input.GetMouseButtonDown(2))
        {
//            GameUtility.SpriteName = "head2";
//            foreach(var e in _sprites.GetEntities())  
//            {  
//                e.ReplaceSprite("head2");
//            }
            _gameContext.ReplaceSpriteName("head2");
        }  
    }  
}  