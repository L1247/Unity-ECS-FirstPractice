using  Entitas;
public class HelloWorldSystem :IInitializeSystem 
{
    private readonly GameContext _context;

    public HelloWorldSystem(Contexts context)
    {
        _context = context.game;
    }
    
    public void Initialize()
    {
        _context.CreateEntity().AddDebugMessage("Hello World");
    }
}