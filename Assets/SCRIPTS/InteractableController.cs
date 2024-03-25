using UnityEngine;using UnityEngine.InputSystem;
public class InteractableController : MonoBehaviour
{
    [SerializeField] private float timeRecoil;
    private Transform obj;
    private int type;
    // 1 - door
    // 2 - partitura
    // 
    // 
    private Door door;
    private PartituraObj partitura;
    private PartiturasInventory partituraInventory;
    private void Start(){
        partituraInventory=FindObjectOfType<PartiturasInventory>();
    }
    public void InteractInput(InputAction.CallbackContext value){
        switch(type){
            case 1:
                door.TransportPlayer(gameObject.transform);
                Clear();
                InvokeRepeating("Reset", timeRecoil, timeRecoil);
            break;
            case 2:
                partituraInventory.AddPartitura(partitura.partitura);
                Destroy(partitura.gameObject);
                Clear();
                InvokeRepeating("Reset", timeRecoil, timeRecoil);
            break;
        }
    }
    private void Clear(){
        type=0;
        door=null;
        partitura=null;
    }
    private void Reset(){
        Debug.Log("reset");
        obj=null;
        CancelInvoke();
    }
    private void OnTriggerEnter(Collider other){
        if(other.transform.tag=="Interactable"&&obj==null){
            obj=other.transform;
            if(obj.GetComponent<Door>()!=null){
                door=obj.GetComponent<Door>();
                type=1;
            }
            if(obj.GetComponent<PartituraObj>()!=null){
                partitura=obj.GetComponent<PartituraObj>();
                type=2;
            }
        }
    }
}
