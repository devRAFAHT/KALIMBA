using UnityEngine;
public class ColliderEyes : MonoBehaviour
{
    [SerializeField] private LayerMask gridLayerMask;
    public bool coll;
    private Transform wall;
    private void OnTriggerEnter(Collider other){
        if(other.transform.tag=="Fase"){
            coll=true;
            wall=other.transform;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.transform.tag=="Fase"&&wall==other.transform){
            coll=false;
            wall=null;
        }
    }
}
