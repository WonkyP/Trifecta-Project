
using UnityEngine;

[System.Serializable]
public class DialogColor_Class
{
    public string text;
    public enum whoTalking
    {
        Anja, dad, tree
    }
    public whoTalking talker = whoTalking.Anja;

}


