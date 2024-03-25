using UnityEngine;
using UnityEngine.UI;
public class AtributeController : MonoBehaviour
{
    [SerializeField] public static float HP=100;
    [SerializeField] public static float ENERGY;
    [SerializeField] public static float CDA;// Combo de ataque
    [SerializeField] private Image HP_BAR;// Combo de ataque
    [SerializeField] private Text HP_Text;// Combo de ataque
    private void LateUpdate(){
        float percent = HP/100;
        HP_BAR.fillAmount=percent;
        HP_Text.text="HP: "+ HP.ToString("0")+"/100";
    }
}
