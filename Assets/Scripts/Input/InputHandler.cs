using UnityEngine;

public class InputHandler : IInput
{
    private NewInput _newInput;

    public InputHandler()
    {
        _newInput = new NewInput();
        _newInput.Enable();
    }
    
    public Vector3 MovementInput()
    {
        return _newInput.Gameplay.Movement.ReadValue<Vector3>();
    }

    public bool IsFire()
    {
        throw new System.NotImplementedException();
    }

    public bool IsJumping()
    {
        throw new System.NotImplementedException();
    }
}
