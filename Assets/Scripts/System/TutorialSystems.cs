public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("Tutorial System")
    {
        Add(new HelloWorldSystem(contexts));  
        Add(new DebugMessageSystem(contexts));
    }

}