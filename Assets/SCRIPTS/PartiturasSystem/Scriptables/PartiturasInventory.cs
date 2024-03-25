using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PartiturasInventory : MonoBehaviour
{
    public static bool open;
    [SerializeField] private List<PARTITURA> partituras = new List<PARTITURA>();
    [SerializeField] private Animator InventoryUI;
    [SerializeField] private Transform localPartituraUI;
    [SerializeField] private GameObject prefabPartituraUI;
    [SerializeField] private GameObject prefabPartituraInputsUI;
    [SerializeField] private string[] inputsKeyboard;
    [SerializeField] private string[] inputsController;

    public void OpenInventoryInput(InputAction.CallbackContext value){
        open=!open;
    }

    private void Update(){
        InventoryUI.SetBool("on", open);
    }

    public void AddPartitura(PARTITURA partitura){
        partituras.Add(partitura);
        InstancePartituraUI(partitura);
    }

    private void InstancePartituraUI(PARTITURA partitura){
        GameObject ui = Instantiate(prefabPartituraUI, localPartituraUI.position, localPartituraUI.rotation);
        ui.transform.parent = localPartituraUI;
        ui.transform.localScale=new Vector3(1,1,1);

        ui.transform.GetChild(0).gameObject.SetActive(partitura.combate);

        for(int i =0;i<partitura.notes.Length-1;i++){
            GameObject p = Instantiate(prefabPartituraInputsUI,ui.transform.position, ui.transform.rotation);
                p.transform.parent = ui.transform;
                p.transform.localScale=new Vector3(1,1,1);
                Text txt = p.GetComponent<Text>();
                string t = inputsKeyboard[partitura.notes[i]-1];
                txt.text = t;
        }
    }
}
