using UnityEngine;
public class PartituraObj : MonoBehaviour
{
    public PARTITURA partitura;
    private SpriteRenderer spriteRenderer;
    private void Start(){
        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = partitura.sprite;
    }
}
