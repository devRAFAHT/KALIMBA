using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Nova partitura", menuName = "Partitura/Criar nova")]
public class PARTITURA : ScriptableObject
{
    public Sprite sprite;
    public int[] notes;
    public bool combate;
    public float damage;
    public float energy;
}
