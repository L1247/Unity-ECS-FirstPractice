using System.Collections.Generic;
using UnityEngine;

namespace System.Attributes
{
    using Entitas;
    
    public sealed class AttributeTestSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
    
        public AttributeTestSystem() { _gameContext = Contexts.sharedInstance.game; }
        
        public void Initialize()
        {
            // Component
            //            _gameContext.CreateEntity().AddScene(2 ,new List<int>());
            
            // Normal Class
            //            var bullet = new Bullet();
            //            bullet.Value = 2;
            //            bullet.dic = new Dictionary<int , string>();
            //            _gameContext.CreateEntity().AddBullet(bullet);
            
            // Struct
            //            _gameContext.CreateEntity().AddEditorOnlyVisual(new EditorOnlyVisual(true));

            // UniquePrefix
            //            _gameContext.flagDestroy = true;
            
            // PrimaryEntityIndex 
            // Core component to provide a name.  Will only allow a single entity with that name.
            //            var gameEntity = _gameContext.CreateEntity();
            //            gameEntity.AddName("Foo");
            //            gameEntity.AddDebugMessage("a");
            //            
            //            var gameEntity2 = _gameContext.CreateEntity();
            //            gameEntity2.AddName("Foo2");
            //            gameEntity2.AddDebugMessage("b");
            //
            //            var entityWithName = _gameContext.GetEntityWithName("Foo");
            //            if (entityWithName != null)
            //                if (entityWithName.hasDebugMessage)
            //                    Debug.Log(entityWithName.debugMessage.message);
              
            // EntityIndex
//            _gameContext.CreateEntity().AddFaction("Player");
//            _gameContext.CreateEntity().AddFaction("Player");
//            _gameContext.CreateEntity().AddFaction("Player");
//            _gameContext.CreateEntity().AddFaction("Player");
//            Debug.Log(_gameContext.GetEntitiesWithFaction("Player").Count);
            
            // CustomComponentName
//            var gameEntity = _gameContext.CreateEntity();
//            gameEntity.AddPosition2(new IntVector2());
//            gameEntity.AddVelocity2(new IntVector2());
//            var intVector2 = new IntVector2();
//            intVector2.x = 2;
//            intVector2.y = 3;
//            gameEntity.ReplacePosition2(intVector2);
//            intVector2.x = 3;
//            intVector2.y = 4;
//            gameEntity.ReplaceVelocity2(intVector2);
//            
        }
    }
}