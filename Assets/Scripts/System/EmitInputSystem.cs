// EmitInputSystem
using UnityEngine;
using Entitas;
 
// 处理Input，需要初始化leftMouseEntity和rightMouseEntity，并且需要每帧执行读取，所以实现下面两个接口
public class EmitInputSystem :IInitializeSystem,IExecuteSystem
{
    readonly InputContext _context;
    private  InputEntity  _leftMouseEntity;
    private  InputEntity  _rightMouseEntity;
 
    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }
 
    // 初始化创建leftMouse和rightMouse的Entity后保存下来
    public void Initialize()
    {
        _context.isLeftMouse  = true;
        _context.isRightMouse = true;
        _leftMouseEntity      = _context.leftMouseEntity;
        _rightMouseEntity     = _context.rightMouseEntity;
    }
 
    // 在leftMouse和rightMouse的Entity上添加或替换Position的组件
    public void Execute()
    {
        // 根据当前鼠标位置获取世界坐标
//        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        // 处理左右点击
        replacePositionProcess(_leftMouseEntity,  0, Input.mousePosition);
        replacePositionProcess(_rightMouseEntity, 1, Input.mousePosition);
    }
 
    // 根据点击状态和鼠标的位置替换位置组件
    void replacePositionProcess(InputEntity entity, int buttonNum, Vector2 mousePosition)
    {
        // 如果判断到按键按下了，则替换entity上的MouseDown组件，下同
        if (Input.GetMouseButtonDown(buttonNum))
            entity.ReplaceMouseDown(mousePosition);

        if (Input.GetMouseButton(buttonNum))
            entity.ReplaceMousePosition(mousePosition);
 
        if (Input.GetMouseButtonUp(buttonNum))
            entity.ReplaceMouseUp(mousePosition);
    }
}