using UnityEngine;
public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 destino;
    private Animator transicion;
    private void Start(){
        transicion=GameObject.FindWithTag("TransicionDoor").GetComponent<Animator>();
    }
    public void TransportPlayer(Transform player){
        Vector3 local = transform.position+destino;
        local.y=player.position.y;
        transicion.SetTrigger("on");
        player.transform.position=local;
        ControllerGridFase grid = player.GetComponent<ControllerGridFase>();
        ColliderEyes eyeFront = grid.eyeForward;
        ColliderEyes eyeBack = grid.eyeForward;
        eyeFront.coll=false;
        eyeBack.coll=true;
        InputController.Move=Vector3.zero;
        player.GetComponent<PlayerMovement>().target=player.position;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position+destino, .1f);
    }
}
