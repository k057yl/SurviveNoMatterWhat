using UnityEngine;

public interface IInput
{
    Vector3 MovementInput();
    bool IsFire();
    bool IsJumping();
}
