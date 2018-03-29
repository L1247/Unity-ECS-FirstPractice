using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

// IViewEntity: "I am an Entity, I can have an AssignViewComponent and a ViewComponent"
public interface IviewEntity : IAssignViewEntity, IViewEntity, IEntity {}
public partial class GameEntity : IviewEntity {}
public partial class InputEntity : IviewEntity {}
public partial class UiEntity : IviewEntity {}

public class MultiAddViewSystem: MultiReactiveSystem<IviewEntity, Contexts>
{
    private readonly Transform                     _topViewContainer = new GameObject("Views").transform;
    private readonly Dictionary<string, Transform> _viewContainers   = new Dictionary<string, Transform>();
    private readonly Contexts                      _contexts;

    public MultiAddViewSystem(Contexts contexts) : base(contexts)
    {
        _contexts = contexts;
        // create a view container for each context name
        foreach (var context in contexts.allContexts)
        {
            string contextName = context.contextInfo.name;
            Transform contextViewContainer = new GameObject(contextName + " Views").transform;
            contextViewContainer.SetParent(_topViewContainer);
            _viewContainers.Add(contextName, contextViewContainer);
        }
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[] {
                                    contexts.game.CreateCollector(GameMatcher.AssignView),
                                    contexts.input.CreateCollector(InputMatcher.AssignView),
                                    contexts.ui.CreateCollector(UiMatcher.AssignView)
                                };
    }

    protected override bool Filter(IviewEntity entity)
    {
        return entity.isAssignView && !entity.hasView;
    }

    protected override void Execute(List<IviewEntity> entities)
    {
        foreach (var e in entities)
        {
            string     contextName = e.contextInfo.name;
            GameObject go          = new GameObject(contextName + " View");
            go.transform.SetParent(_viewContainers[contextName]);
            e.AddView(go);
            go.Link(e, _contexts.GetContextByName(contextName));
            e.isAssignView = false;
        }
    }
}