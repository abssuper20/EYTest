using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractable_Extended : XRGrabInteractable
{
    [SerializeField] private Transform leftAttachTransform;
    [SerializeField] private Transform rightAttachTransform;

    [SerializeField] private bool disableGrabberRenderer;
    [SerializeField] private GameObject leftHandRenderer;
    [SerializeField] private GameObject rightHandRenderer;

    private bool isObjectGrabbed;
    public bool IsObjectGrabbed => isObjectGrabbed;

    //[SerializeField] private AllowedGrabbers allowedGrabbers;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.name.Contains("Left"))
        {
            //if ((int)allowedGrabbers != 2)
            leftHandRenderer.SetActive(!disableGrabberRenderer);
            //attachTransform = leftAttachTransform;
        }
        else if (args.interactorObject.transform.name.Contains("Right"))
        {
            //if ((int)allowedGrabbers != 1)
                rightHandRenderer.SetActive(!disableGrabberRenderer);
            //attachTransform = rightAttachTransform;
        }

        base.OnSelectEntered(args);
        isObjectGrabbed = true;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.name.Contains("Left"))
        {
            leftHandRenderer.SetActive(disableGrabberRenderer);
        }
        else if (args.interactorObject.transform.name.Contains("Right"))
        {

            rightHandRenderer.SetActive(disableGrabberRenderer);
        }
        base.OnSelectExited(args);
        isObjectGrabbed = false;
    }
}

public enum AllowedGrabbers
{
    Both,
    Left,
    Right
}