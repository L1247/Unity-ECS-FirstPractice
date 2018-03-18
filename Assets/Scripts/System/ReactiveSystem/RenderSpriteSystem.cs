using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Utility;

public class RenderSpriteSystem : ReactiveSystem<GameEntity>
{
    private GameContext _gameContext;
    private IGroup<GameEntity> _spriteGroup;

    public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
        _spriteGroup = _gameContext.GetGroup(GameMatcher.SpriteRender);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.SpriteRender,
                                                         GameMatcher.SpriteName));
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //        foreach (GameEntity gameEntity in entities)
//        {
//            GameObject go = gameEntity.view.gameObject;
//
//            SpriteRenderer sr  = go.GetComponent<SpriteRenderer>();
//            if (sr == null) sr = go.AddComponent<SpriteRenderer>();
//                
//            //            sr.sprite = Resources.Load<Sprite>(gameEntity.sprite.name);
//            sr.sprite = Resources.Load<Sprite>(GameUtility.SpriteName);
//        }
        foreach (var e in _spriteGroup)
        {
            GameObject go = e.view.gameObject;
                
            SpriteRenderer sr  = go.GetComponent<SpriteRenderer>();
            if (sr == null) sr = go.AddComponent<SpriteRenderer>();
                
            sr.sprite = Resources.Load<Sprite>(_gameContext.spriteName.value);
        }
    }
}