using Entitas;
using Utility;

namespace System
{
    public sealed class GameInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
    
        public GameInitializeSystem() { _gameContext = Contexts.sharedInstance.game; }
        
        public void Initialize()
        {
            GameUtility.SpriteName = "head1";
        }
    }
}