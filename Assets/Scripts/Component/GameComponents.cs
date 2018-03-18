using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class PositionComponent : IComponent
{
    public Vector2 value;
}

[Game]
public class DirectionComponent : IComponent
{
    public float value;
}

[Game]
public class ViewComponent : IComponent
{
    public GameObject gameObject;
}

// GameObject是否是Mover的标志  
[Game]  
public class MoverComponent : IComponent  
{  
}  

[Game]
public class SpriteComponent : IComponent
{
    public string name;
}

[Game]
public class SpriteRenderComponent : IComponent{}

[Game,Unique]
public class SpriteNameComponent : IComponent{public string value;}

[Game]
public class MoveComponent : IComponent
{
    public Vector2 target;
}

[Game]
public class MoveCompleteComponent : IComponent{}