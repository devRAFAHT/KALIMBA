using UnityEngine;
public class ControllerGridFase : MonoBehaviour
{
    public static bool isColliderWallForward;
    public static bool isColliderWallBack;
    public static bool isColliderWallLeft;
    public static bool isColliderWallRight;
    public ColliderEyes eyeForward;
    public ColliderEyes eyeBack;
    public ColliderEyes eyeLeft;
    public ColliderEyes eyeRight;
    private void Update(){
        isColliderWallForward=eyeForward.coll;
        isColliderWallBack=eyeBack.coll;
        isColliderWallLeft=eyeLeft.coll;
        isColliderWallRight=eyeRight.coll;
    }
}
