using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.InputSystem;
public class Kalimba : MonoBehaviour
{
    [SerializeField] private Animator partituraUI;
    [SerializeField] private Animator hands;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] notes;
    [SerializeField] private float resetTime;
    public int noteAtual;
    private bool battle;
    public void InputNote1(InputAction.CallbackContext value){
        noteAtual=1;
        hands.SetInteger("note", noteAtual);
        if(!battle)partituraUI.SetBool("on", true);
        audioSource.PlayOneShot(notes[noteAtual-1]);
        InvokeRepeating("Reset",resetTime,resetTime);
    }
    public void InputNote2(InputAction.CallbackContext value){
        noteAtual=2;
        audioSource.PlayOneShot(notes[noteAtual-1]);
        hands.SetInteger("note", noteAtual);
        if(!battle)partituraUI.SetBool("on", true);
        InvokeRepeating("Reset",resetTime,resetTime);
    }
    public void InputNote3(InputAction.CallbackContext value){
        noteAtual=3;
        audioSource.PlayOneShot(notes[noteAtual-1]);
        hands.SetInteger("note", noteAtual);
        if(!battle)partituraUI.SetBool("on", true);
        InvokeRepeating("Reset",resetTime,resetTime);
    }
    public void InputNote4(InputAction.CallbackContext value){
        noteAtual=4;
        audioSource.PlayOneShot(notes[noteAtual-1]);
        hands.SetInteger("note", noteAtual);
        if(!battle)partituraUI.SetBool("on", true);
        InvokeRepeating("Reset",resetTime,resetTime);
    }
    private void Reset(){
        noteAtual=0;
        hands.SetInteger("note", noteAtual);
        CancelInvoke();
        InvokeRepeating("ResetUI",5f,5f);
    }
    private void ResetUI(){
        partituraUI.SetBool("on", false);
        CancelInvoke();
    }

    public void BattleMode(bool on){
        partituraUI.SetBool("on", !on);
        battle=on;
    }
}
