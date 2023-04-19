using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVa1ue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVa1ue);

        float gripVa1ue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVa1ue);
    }
}
