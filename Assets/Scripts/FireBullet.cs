using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;

    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;

    [SerializeField] private float destroyTimer = 2f;
    [SerializeField] private float shotPower = 500f;

    [SerializeField] private XRGrabInteractable_Extended gun;

    [SerializeField] private InputActionReference fireAction;

    [SerializeField] private AudioClip shootSFX;

    [SerializeField] private ActionBasedController rightController;
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        fireAction.action.performed += Fire;
    }

    private void OnDisable()
    {
        fireAction.action.performed -= Fire;
    }

    private void Update()
    {
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        gunAnimator.SetTrigger("Fire");
    }

    private void Fire(InputAction.CallbackContext ctx)
    {
        if (gun.IsObjectGrabbed)
            gunAnimator.SetTrigger("Fire");
    }

    private void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation);

            Destroy(tempFlash, destroyTimer);
        }
        if (!bulletPrefab) return;
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower, ForceMode.Impulse);
        AudioSource.PlayClipAtPoint(shootSFX, transform.position);
        rightController.SendHapticImpulse(.5f, .2f);
    }
}
