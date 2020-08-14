using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is the core script for any shooting based weapons.
/// The script does not contain  all of the weapon properties and 
/// will use a scriptable object as a referances. All weapon 
/// functionality can be called from another script.
/// </summary>

[DisallowMultipleComponent]
public class GunController : MonoBehaviour {
    #region Weapon Properties
    [Header("Weapon Components")]
    [SerializeField] Transform weaponBarrel = null;
    [SerializeField] Transform weaponEjector = null;
    [Header("Weapon Properties")] [Space(20)]
    [SerializeField] Vector3 hipFirePosition = Vector3.zero;
    [SerializeField] Vector3 aimFirePosition = Vector3.zero;
    [Space(10)]
    [SerializeField] GunProperties weaponProperties = null;

    // Fire mode selection
    int CurrentFireSelect = 0;
    [ReadOnly] [SerializeField] FireSelection CurrentFireMode;

    // Shooting logic variables;
    bool CanShoot = true;
    float CurrentRateOfFire = 0;
    [ReadOnly] public int TotalRemainingAmmo = 0;
    [ReadOnly] public int RemainingMagazineAmmo = 0;
    [ReadOnly] public GameObject hitScanObject = null;

    WeaponSway SwayLogic;
    #endregion


    // Start is called before the first frame update
    void Start() {
        SwayLogic = GetComponentInParent<WeaponSway>();
        SwayLogic.weaponProperties = weaponProperties;

        StartingFireSelect();
        switch (CurrentFireMode) {
            case FireSelection.Safe:
                CanShoot = false;
                break;
            case FireSelection.Semi:
                CanShoot = true;
                break;
            //case FireSelection.Burst:
            //    CanShoot = true;
            //    break;
            case FireSelection.FullAuto:
                CanShoot = true;
                break;
        }

        TotalRemainingAmmo = weaponProperties.TotalAmmoCount;
        RemainingMagazineAmmo = weaponProperties.MagazineCapacity;
    }

    // Update is called once per frame
    void Update() {
        CurrentRateOfFire += Time.deltaTime;
    }

    // Weapon sway input
    public void SwayInput(float X_Input, float Y_Input) {
        SwayLogic.X_Input = -X_Input;
        SwayLogic.Y_Input = -Y_Input;
    }

    // Aim Down Sights / ADS
    public void AimDownSights(bool AimInput = false) {
        if (AimInput) {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimFirePosition, Time.deltaTime * weaponProperties.AimSpeed);
        }
        else {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hipFirePosition, Time.deltaTime * weaponProperties.AimSpeed);
        }
    }

    // Fire weapon, based on the current fire mode and input
    public void Shoot(bool FireInput = false) {
        // Auto reload case
        if (FireInput && RemainingMagazineAmmo <= 0 && weaponProperties.AutoReload) {
            Reload();
        }

        switch (CurrentFireMode) {
            case FireSelection.Safe:
                CanShoot = false;
                break;
            case FireSelection.Semi:
                if (FireInput && CanShoot) {
                    ShootingLogic();
                    CanShoot = false;
                }
                break;
            //case FireSelection.Burst:
            //    if (FireInput && CanShoot) {
            //        ShootingLogic();
            //        CanShoot = false;
            //    }
            //    break;
            case FireSelection.FullAuto:
                if (FireInput) {
                    ShootingLogic();
                }
                break;
        }
        if (!FireInput) {
            CanShoot = true;
        }
    }

    // Change they type of fire mode to the next possible selection
    public void ToggleFire() {
        CurrentFireSelect += 1;

        if (CurrentFireSelect == 0 && weaponProperties.FireModes.HasFlag(FireSelection.Safe)) {
            CurrentFireMode = FireSelection.Safe;
        }
        else if (CurrentFireSelect == 1 && weaponProperties.FireModes.HasFlag(FireSelection.Semi)) {
            CurrentFireMode = FireSelection.Semi;
        }
        //else if (CurrentFireSelect == 2 && weaponProperties.FireModes.HasFlag(FireSelection.Burst)) {
        //    CurrentFireMode = FireSelection.Burst;
        //}
        else if (CurrentFireSelect == 3 && weaponProperties.FireModes.HasFlag(FireSelection.FullAuto)) {
            CurrentFireMode = FireSelection.FullAuto;
        }
        else if (CurrentFireSelect == 4) {
            StartingFireSelect();
        }
        else {
            ToggleFire();
        }
    }
    void StartingFireSelect() {
        if (weaponProperties.FireModes.HasFlag(FireSelection.Safe)) {
            CurrentFireMode = FireSelection.Safe;
            CurrentFireSelect = 0;
        }
        else if (weaponProperties.FireModes.HasFlag(FireSelection.Semi)) {
            CurrentFireMode = FireSelection.Semi;
            CurrentFireSelect = 1;
        }
        //else if (weaponProperties.FireModes.HasFlag(FireSelection.Burst)) {
        //    CurrentFireMode = FireSelection.Burst;
        //    CurrentFireSelect = 2;
        //}
        else if (weaponProperties.FireModes.HasFlag(FireSelection.FullAuto)) {
            CurrentFireMode = FireSelection.FullAuto;
            CurrentFireSelect = 3;
        }
    }

    // Shooting logic based on the weapon type, trigger and properties of the gun
    void ShootingLogic() {
        int CurrentShots = 1;
        if (CurrentRateOfFire < weaponProperties.RateOfFire || RemainingMagazineAmmo <= 0) {
            return;
        }

        switch (weaponProperties.BulletType) {
            case WeaponType.Hitscan:
                RaycastHit hit;
                if (Physics.Raycast(weaponBarrel.position, weaponBarrel.transform.forward, out hit, weaponProperties.HitScan.Range)) {
                    hitScanObject = hit.transform.gameObject;
                }
                else {
                    hitScanObject = null;
                }

                break;
        }
        CurrentShots++;
        RemainingMagazineAmmo--;
        CurrentRateOfFire = 0;
    }

    // Weapon reload based on the ammo storage system
    public void Reload() {
        switch (weaponProperties.AmmoSystem) {
            case AmmoStorageType.AmmoCount:
                if (TotalRemainingAmmo <= 0) {
                    return;
                }

                int ConsumedAmmo = weaponProperties.MagazineCapacity - RemainingMagazineAmmo;
                int AmmoToDeduct = (TotalRemainingAmmo >= ConsumedAmmo) ? ConsumedAmmo : TotalRemainingAmmo;

                TotalRemainingAmmo -= AmmoToDeduct;
                RemainingMagazineAmmo += AmmoToDeduct;
                break;
        }
    }

    // Refils the total remaining ammo based on the ammo storage system
    public void AmmoResupply() {
        switch (weaponProperties.AmmoSystem) {
            case AmmoStorageType.AmmoCount:
                TotalRemainingAmmo = weaponProperties.TotalAmmoCount;
                break;
        }
    }
}