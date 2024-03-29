using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{   
    [Header("MOVEMENT")]
    [SerializeField] private Animator hands;
    [SerializeField] private float speedMovement;
    [SerializeField] private float sizeGrid;
    private Vector2 moveInput;
    public Vector3 target;
    public bool isMoving;
    [Header("LOOKAROUND")]
    public bool isRotation;
    public int dirRotation;
    [SerializeField] private Transform eyeForward;
    [SerializeField] private Vector3 targetRotation;
    [SerializeField] private float smothRotation;

    DialogueSystem dialogueSystem;
    [SerializeField] public Transform npc;

    private void Awake(){
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
    private void Start(){
        target=Vector3.zero;
        target.y=transform.position.y;
    }
    private void Update(){
        hands.SetBool("move", isMoving);
        #region MOVEMENT
        if((InputController.Move.y!=0)&&(!isMoving)&&(!isRotation)){
            if((InputController.Move.y>0)&&(!ControllerGridFase.isColliderWallForward)){
                StartMoving();
            }
            if((InputController.Move.y<0)&&(!ControllerGridFase.isColliderWallBack)){
                StartMoving();
            }
        }

        if(isMoving)
            if(Vector3.Distance(transform.position,target)>.03f){
                Moving();
            }else{
                isMoving=false;
            }
        #endregion

        #region LOOKAROUND
        if(isRotation){
            if(targetRotation.y>270f&&targetRotation.y<361f)targetRotation.y=0;
            if(targetRotation.y<0f)targetRotation.y=270f;
            
            if(Vector3.Distance(transform.eulerAngles, targetRotation)<0.05f){
                isRotation=false;
            }else{
                LookingAround(dirRotation);
            }
            if(eyeForward.tag!="Untagged"){
                eyeForward.tag="Untagged";   
                eyeForward.GetComponent<BoxCollider>().enabled=false;
                eyeForward.GetComponent<ColliderEyes>().coll=false;
            }
        }else{
            if(eyeForward.tag!="eyeForward"){
                eyeForward.tag="eyeForward";   
                eyeForward.GetComponent<BoxCollider>().enabled=true;
            }
        }
        #endregion

        if(Mathf.Abs(transform.position.x - npc.position.x) < 2.0f){
            if(Input.GetKeyDown(KeyCode.E)){
                dialogueSystem.Next();
            }
        }

    }
    #region MOVEMENT
    private void StartMoving(){
        target=localTarget();
        isMoving=true;
    }
    private void Moving(){
        transform.position=Vector3.Lerp(transform.position, target, Time.deltaTime*speedMovement);        
    }
    private Vector3 localTarget(){
        Vector3 dir = Vector3.zero;
        dir+=new Vector3(sizeGrid*transform.forward.x,0,sizeGrid*transform.forward.z)*InputController.Move.y;
        dir.y=0;
        return target+dir;
    }
    #endregion

    #region LOOKAROUND
    public void LookAroundRightInput(InputAction.CallbackContext value){
        if(!isRotation&&(!isMoving)&&(!isRotation)){
            isRotation=true;
            dirRotation=1;
            targetRotation=GetTargetRotation();
        }
    }
    public void LookAroundLeftInput(InputAction.CallbackContext value){
        if(!isRotation&&(!isMoving)&&(!isRotation)){
            isRotation=true;
            dirRotation=-1;
            targetRotation=GetTargetRotation();
        }
    }
    private Vector3 GetTargetRotation(){
        Vector3 t = transform.eulerAngles+Vector3.up*90*dirRotation;
        return t;
    }
    private void LookingAround(int dir){
        if(dir>0){
            transform.rotation=Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime*smothRotation);   
        }else if(dir<0){
            transform.rotation=Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime*smothRotation);   
        }
    }
    #endregion
}
