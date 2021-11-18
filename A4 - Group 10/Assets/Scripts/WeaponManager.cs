using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Camera playerCamera;
    public Weapon primaryWeapon;

    [HideInInspector]
    public Weapon selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //At the start we enable the primary weapon and disable the secondary
        primaryWeapon.ActivateWeapon(true);
        selectedWeapon = primaryWeapon;
        primaryWeapon.manager = this;
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            primaryWeapon.ActivateWeapon(true);
            selectedWeapon = primaryWeapon;
        }
    }
}
