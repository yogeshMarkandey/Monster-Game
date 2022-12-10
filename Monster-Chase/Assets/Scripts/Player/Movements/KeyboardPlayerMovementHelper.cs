
using UnityEngine;

public class KeyboardPlayerMovementHelper : UserInputs.IPlayerMovementHelper
{

    public float getHorizontalInput(){
        return Input.GetAxisRaw("Horizontal");
    }
    

    public float getVerticalInput() {
        return Input.GetAxisRaw("Vertical");
    }
}