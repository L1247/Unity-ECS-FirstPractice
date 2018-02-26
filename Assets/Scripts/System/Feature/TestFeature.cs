using UnityEngine;

public class TestFeature : Feature
{
    public TestFeature(Contexts contexts) : base("Test System")
    {
        Add(new TestSystem(contexts));
    }
}
