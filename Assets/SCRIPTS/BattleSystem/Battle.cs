using UnityEngine;
public class Battle : MonoBehaviour
{
    private bool start,turno;
    [SerializeField] private float HP;
    [SerializeField] private float DAMAGE;
    // fase==eenemy, true=player
    private Kalimba kalimba;
    private PlayerMovement movementPlayer;
    private ReceiveNotesEnemy notesEnemy;


    [SerializeField] private Animator BattleUI;
    [SerializeField] private Animator NotesEnemy;

    private void Start(){
        kalimba=FindObjectOfType<Kalimba>();
        movementPlayer=FindObjectOfType<PlayerMovement>();
        notesEnemy=FindObjectOfType<ReceiveNotesEnemy>();
    }
    private void OnTriggerEnter(Collider other){
        if(other.transform.tag=="eyeForward"){
            StartBattle();
        }
    }

    private void StartBattle(){
        start=true;
        movementPlayer.enabled=false;
        kalimba.BattleMode(true);
        BattleUI.SetTrigger("start");
        StartTurnEnemy();
    // turno  inimigo
    }
    private void StartTurnEnemy(){
        PartiturasInventory.open=false;
        turno=false;
        BattleUI.SetBool("enemy", true);
        BattleUI.SetBool("player", false);
        NotesEnemy.SetTrigger("go");
    }

    private void TurnEnemy(){
        if (NotesEnemy.GetCurrentAnimatorStateInfo(0).IsName("end")){
            AtributeController.HP-=DAMAGE*(100-notesEnemy.pontuação);
            notesEnemy.Reset();
            StartTurnPlayer();
        }
    }

    private void StartTurnPlayer(){
        turno=false;
        BattleUI.SetBool("enemy", false);
        BattleUI.SetBool("player", true);
        PartiturasInventory.open=true;
    }

    private void TurnPlayer(){
        turno=true;
        BattleUI.SetBool("enemy", false);
        BattleUI.SetBool("player", true);

    }

    private void Update(){
        if(AtributeController.HP<=0)GameOver();
        if(HP<=0)Winner();
        if(start){
            if(turno){
                TurnPlayer();
            }else{
                TurnEnemy();
            }            
        }

    }

    private void EndBattle(){
        BattleUI.SetBool("enemy", false);
        BattleUI.SetBool("player", false);
        start=false;
        BattleUI.SetTrigger("end");
        PartiturasInventory.open=false;

    }
    private void Winner(){
        EndBattle();        
        movementPlayer.enabled=true;
        kalimba.BattleMode(false);
        Destroy(gameObject);
    }
    private void GameOver(){
        EndBattle();
    }
}
