using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public bool sniper;

    //public KeyCode reload;

    private Movement Player;

    private GameObject test;
    private bool isShooting;

    public FireMode fireMode;

    private PlayerControlls input;

    public enum FireMode
    {
        single,
        auto
    }

    public void Awake()
    {
        input = new PlayerControlls();
    }

    private void OnEnable()
    {
        input.Enable();

        input.DeafultInput.Shoot.started += ShootV;
        input.DeafultInput.Shoot.canceled += ShootV;
        input.DeafultInput.Aim.started += Scope;
        input.DeafultInput.Aim.canceled += Scope;
        input.DeafultInput.Reload.started += Reload;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        if (isShooting == true)
        {
            GetComponent<BaseGun>().Shoot();
        }
    }
    public void ShootV(InputAction.CallbackContext context)
    {
        if (context.started && (fireMode == FireMode.single || fireMode == FireMode.auto))
        {
            GetComponent<BaseGun>().Shoot();

            if (fireMode == FireMode.auto)
            {
                isShooting = true;
            }
        }

        if (context.canceled && fireMode == FireMode.auto)
        {
            isShooting = false;
        }
    }

    public void Scope(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            GetComponent<BaseGun>().Normal();

            print("ADS Done");
        }

        else
        {
            GetComponent<BaseGun>().ADS();
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        print("reload");

        if (GetComponent<BaseGun>().ammoCount < GetComponent<BaseGun>().upgrade.ammoBoosted && GetComponent<BaseGun>().extra.reload == false)
        {
            GetComponent<BaseGun>().Reload();
            GetComponentInChildren<Animation>().Play();
        }
    }
}
