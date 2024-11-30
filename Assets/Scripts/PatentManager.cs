using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PatentManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer patentSpriteRenderer;
    [SerializeField] private SpriteRenderer inventorSpriteRenderer;
    [SerializeField] private TextMeshProUGUI enterDialogText;
    [SerializeField] private TextMeshProUGUI exitDialogText;
    private string _dialogApprove;
    private string _dialogDisapprove;
    [SerializeField] private List<ScriptableInventor> inventors;
    private int _currentInventor = -1;
    private ScriptableInventor _currentInventorScript;

    [SerializeField] private GameObject approveButton;
    [SerializeField] private GameObject disapproveButton;
    
    [SerializeField] private LampMovement lampMovement;

    public void ShowExitDialog(bool approved)
    {
        // anim?
        lampMovement.ToggleLampMovement();
        patentSpriteRenderer.gameObject.SetActive(false);
        disapproveButton.SetActive(false);
        approveButton.SetActive(false);
        exitDialogText.text = approved ? _dialogApprove : _dialogDisapprove;
        exitDialogText.gameObject.transform.parent.gameObject.SetActive(true);
    }
    
    public void LoadNewInventor()
    {
        exitDialogText.gameObject.transform.parent.gameObject.SetActive(false);

        _currentInventor++;
        _currentInventorScript = inventors[_currentInventor];
        patentSpriteRenderer.sprite = _currentInventorScript.patentImage;
        // inventorImage.sprite = _currentInventorScript.inventorImage;
        enterDialogText.text = _currentInventorScript.inventorEnterDialog;
        _dialogApprove = _currentInventorScript.inventorExitDialogApprove;
        _dialogDisapprove = _currentInventorScript.inventorExitDialogDisapprove;
        
        Invoke(nameof(ShowEnterDialog), 2f);
    }

    private void ShowEnterDialog()
    {
        enterDialogText.gameObject.transform.parent.gameObject.SetActive(true);
    }
    
    public void ShowPatent()
    {
        // anim?
        lampMovement.ToggleLampMovement();
        patentSpriteRenderer.gameObject.SetActive(true);
        approveButton.SetActive(true);
        disapproveButton.SetActive(true);
        enterDialogText.gameObject.transform.parent.gameObject.SetActive(false);
    }
    
    
}
