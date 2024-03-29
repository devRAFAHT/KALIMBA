using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Dialogue{

    public string name;
    [TextArea(5,10)]
    public string text;
}

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/TalkScript", order =1)]
public class DialogueData : ScriptableObject {
    // Start is called before the first frame update
    public List<Dialogue> talkScript;
    
}
