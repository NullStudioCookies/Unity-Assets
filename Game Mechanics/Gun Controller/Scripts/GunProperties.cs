using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is just a template data container for the "Gun Controller" and
/// the "Weapon Sway" scripts.
/// </summary>

[System.Flags]
public enum WeaponRotation { X = (1 << 0), Y = (1 << 1), Z = (1 << 2) }
[System.Flags]
public enum FireSelection { Safe = (1 << 0), Semi = (1 << 1), FullAuto = (1 << 2) }
public enum WeaponType { Hitscan}
public enum AmmoStorageType { AmmoCount}

[CreateAssetMenu(fileName = "Gun Property", menuName = "Scriptable Objects/Gun Properties")]
public class GunProperties : ScriptableObject {
    #region Read only variables
    [Header("Gun Properties")]
    [Range(0, 10)] [SerializeField] float aimSpeed = 0;
    [SerializeField] bool autoReload = false;

    [Header("Shooting Properties")] [Space(20)]
    [EnumFlags] [SerializeField] FireSelection fireModes = FireSelection.Safe;
    [Space(10)]
    [SerializeField] WeaponType bulletType = WeaponType.Hitscan;
    [MinValue(0)] [SerializeField] float rateOfFire = 0;
    //[MinValue(1)] [SerializeField] int numberOfBurstShots = 1;
    [ConditionalEnumHide("bulletType", (int)WeaponType.Hitscan)] [SerializeField] HitScanProperties hitScan = null;


    [System.Serializable]
    public class HitScanProperties {
        [MinValue(0)] [ReadOnly] public float Range = 0; 
    }

    [Space(10)]
    [SerializeField] AmmoStorageType ammoSystem = AmmoStorageType.AmmoCount;
    [ConditionalEnumHide("ammoSystem", (int)AmmoStorageType.AmmoCount)] [SerializeField] int totalAmmoCount = 0;
    [MinValue(0)] [SerializeField] int magazineCapacity = 0;

    [Header("Weapon Sway")] [Space(20)]
    [Range(0, 1)] [SerializeField] float swayAmount = 0;
    [Range(0, 1)] [SerializeField] float maxSwayAmount = 0;
    [Range(0, 10)] [SerializeField] float smoothedSwayAmount = 0;
    [Space(10)]
    [EnumFlags] [SerializeField] WeaponRotation rotationAxis = WeaponRotation.X;
    [SerializeField] float rotationAmount = 0;
    [SerializeField] float maxRotationAmount = 0;
    [SerializeField] float smoothedRotation = 0;
    #endregion

    #region Provided Info
    // Weapon Properties
    public float AimSpeed => aimSpeed;
    public bool AutoReload => autoReload;

    // Shooting Properties
    public FireSelection FireModes => fireModes;
    public WeaponType BulletType => bulletType;
    public float RateOfFire => rateOfFire;
    //public int NumberOfBurstShots => numberOfBurstShots;
    public HitScanProperties HitScan => hitScan;
    public AmmoStorageType AmmoSystem => ammoSystem;
    public int TotalAmmoCount => totalAmmoCount;
    public int MagazineCapacity => magazineCapacity;

    // Weapon Sway
    public float SwayAmount => swayAmount;
    public float MaxSwayAmount => maxSwayAmount;
    public float SmoothedSwayAmount => smoothedSwayAmount;
    public WeaponRotation RotationAxis => rotationAxis;
    public float RotationAmount => rotationAmount;
    public float MaxRotationAmount => maxRotationAmount;
    public float smoothedRotaation => smoothedRotation;
    #endregion
}