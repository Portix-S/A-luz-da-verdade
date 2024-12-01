using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PatentManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer patentSpriteRenderer;
    [SerializeField] private SpriteRenderer wrongPatentSpriteRenderer;
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
    [SerializeField] private SpriteRenderer handSprite;
    [SerializeField] private Inventor inventorScript;

    public void ShowExitDialog(bool approved)
    {
        lampMovement.ToggleLampMovement();
        patentSpriteRenderer.gameObject.SetActive(false);
        disapproveButton.SetActive(false);
        approveButton.SetActive(false);
        var leaveDelay = 0f;
        if (_currentInventorScript.unlockLamp)
        {
            lampMovement.gameObject.SetActive(true);
            handSprite.gameObject.SetActive(true);
            leaveDelay = 1f;
            Invoke(nameof(DisappearHand), leaveDelay);
        }

        if (approved)
        {
            exitDialogText.text = _dialogApprove;
            Invoke(nameof(LeaveApproved), leaveDelay);
        }
        else
        {
            exitDialogText.text = _dialogDisapprove;
            Invoke(nameof(LeaveRejected), leaveDelay);
        }
        exitDialogText.gameObject.transform.parent.gameObject.SetActive(true);
    }

    private void LeaveApproved()
    {
        inventorScript.LeaveApproved();
    }

    private void LeaveRejected()
    {
        inventorScript.LeaveRejected();
    }
    
    private void DisappearHand()
    {
        handSprite.gameObject.SetActive(false);
    }

    public void LoadNewInventorWithDelay()
    {
        exitDialogText.gameObject.transform.parent.gameObject.SetActive(false);
        Invoke(nameof(LoadNewInventor), 1.1f);
    }
    
    public void LoadNewInventor()
    {
        exitDialogText.gameObject.transform.parent.gameObject.SetActive(false);
        inventorScript.gameObject.SetActive(true);
        _currentInventor++;
        _currentInventorScript = inventors[_currentInventor];
        
        var correctPatent = _currentInventorScript.patentImage;
        patentSpriteRenderer.sprite = correctPatent;
        inventorSpriteRenderer.sprite = _currentInventorScript.inventorImage;
        
        var wrongPatent = _currentInventorScript.wrongPatentImage;
        wrongPatentSpriteRenderer.sprite = !wrongPatent ?  correctPatent : wrongPatent;

        handSprite.sprite = _currentInventorScript.handSprite;
        
        enterDialogText.text = _currentInventorScript.inventorEnterDialog;
        _dialogApprove = _currentInventorScript.inventorExitDialogApprove;
        _dialogDisapprove = _currentInventorScript.inventorExitDialogDisapprove;
        
        Invoke(nameof(ShowEnterDialog), 1f);
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
