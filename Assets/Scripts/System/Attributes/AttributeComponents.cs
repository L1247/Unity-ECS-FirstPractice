using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class SceneComponent : IComponent
{
    public float Value;
    public List<int> list = new List<int>();
}


[Game]
public class Bullet
{
    // Since it doesn't derive from 'IComponent'
    // it will be generated as 'BulletComponent'

    public float Value;
    public  List<int> list = new List<int>();
    public  Dictionary<int ,string> dic = new Dictionary<int , string>();
}

[Game]
public struct EditorOnlyVisual
{
    public bool ShowInMode;
    public List<int>               list;
    public Dictionary<int ,string> dic ;

    public EditorOnlyVisual(bool show) {
        this.ShowInMode = show;
        list = new List<int>();
        dic = new Dictionary<int , string>();
    }
}

[Unique,UniquePrefix("flag") ]
public sealed class DestroyComponent : IComponent{}


[Game]
public class NameComponent : IComponent {
    [PrimaryEntityIndex]
    public string value;
}

[Game]
public class FactionComponent : IComponent {
    [EntityIndex]
    public string name;
}

[Game, CustomComponentName("Position2", "Velocity2")]
public struct IntVector2 {
    public int x;
    public int y;
}