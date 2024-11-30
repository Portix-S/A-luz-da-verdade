using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventor : MonoBehaviour
{
    private static readonly int Rejected = Animator.StringToHash("LeaveRejected");
    private static readonly int Accepted = Animator.StringToHash("LeaveAccepted");

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void LeaveRejected()
    {
        _animator.SetTrigger(Rejected);
    }

    public void LeaveApproved()
    {
        _animator.SetTrigger(Accepted);
    }

    public void DisableInventor()
    {
        gameObject.SetActive(false);
    }
}
