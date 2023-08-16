using UnityEngine;

public class KeyboardInputController : IInputController
{
    public float ProcessInput()
    {
        return Input.GetAxis("Horizontal");
    }
}
