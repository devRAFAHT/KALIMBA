using UnityEngine;
using UnityEngine.InputSystem;
public class InputController : MonoBehaviour
{
    public static Vector2 Move;
    public static bool Interact;
    public void MoveInput(InputAction.CallbackContext value){
        Move = value.ReadValue<Vector2>();
    }
}
