using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandedGrabInteractable : XRGrabInteractable
{
    [SerializeField] private Transform leftAttachTransform;
    [SerializeField] private Transform rightAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.name.Contains("Left"))
            attachTransform = leftAttachTransform;
        else if (args.interactorObject.transform.name.Contains("Right"))
            attachTransform = rightAttachTransform;

        base.OnSelectEntered(args);
    }
}
