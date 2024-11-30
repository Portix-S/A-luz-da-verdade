using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PatentManager : MonoBehaviour
{
    [SerializeField] private Image patentImage;
    [SerializeField] private Image inventorImage;
    [SerializeField] private TextMeshProUGUI enterDialogText;
    [SerializeField] private TextMeshProUGUI exitDialogText;
    private string _dialogApprove;
    private string _dialogDisapprove;
    [SerializeField] private List<ScriptableInventor> inventors;
    private int _currentInventor = -1;
    private ScriptableInventor _currentInventorScript;

    public void HidePatent()
    {
        patentImage.gameObject.SetActive(false);
        enterDialogText.gameObject.SetActive(true);
    }
    
    public void LoadNewInventor()
    {
        HidePatent();
        _currentInventor++;
        _currentInventorScript = inventors[_currentInventor];
        patentImage.sprite = _currentInventorScript.patentImage;
        // inventorImage.sprite = _currentInventorScript.inventorImage;
        enterDialogText.text = _currentInventorScript.inventorEnterDialog;
        _dialogApprove = _currentInventorScript.inventorExitDialogApprove;
        _dialogDisapprove = _currentInventorScript.inventorExitDialogDisapprove;
    }

    public void ShowPatent()
    {
        // anim?
        patentImage.gameObject.SetActive(true);
        enterDialogText.gameObject.SetActive(false);
    }
    
    
}
