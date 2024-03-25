using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReceiveNotesEnemy : MonoBehaviour
{
    private Kalimba kalimba;
    private int[] notes;

    private NoteEnemy atual;
    public float pontuação=100;
    private GameObject partitura;
    private void Start(){
        kalimba=FindObjectOfType<Kalimba>();
    }
    private void Update(){
        if(atual!=null){
            if(kalimba.noteAtual==atual.note){
                Destroy(atual.gameObject);
                atual=null;
            }
        }
    }
    public void Reset(){
        pontuação=100;
        if(partitura!=null)
        Destroy(partitura);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.GetComponent<NoteEnemy>()!=null){
            atual=other.transform.GetComponent<NoteEnemy>();
            if(partitura!=null)
            partitura=atual.transform.parent.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D other){
        if(atual!=null)
        if(other.transform.GetComponent<NoteEnemy>()==atual){
            if(kalimba.noteAtual!=atual.note){
                atual=null;
                pontuação-=10;
            }
        }
    }
}
