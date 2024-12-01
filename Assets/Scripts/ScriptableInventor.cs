using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Inventor/New Inventor", fileName = "New Inventor")]
public class ScriptableInventor : ScriptableObject
{
    public Sprite patentImage;
    public Sprite wrongPatentImage;
    public Sprite inventorImage;
    public int patentId;
    public string inventorEnterDialog;
    public string inventorExitDialogApprove;
    public string inventorExitDialogDisapprove;
    
}
