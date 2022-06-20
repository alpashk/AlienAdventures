using System;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

public class WeaponsUiList : ScriptableObject
{
    [SerializeField] private List<WeaponUiData> weaponData;
}

[Serializable]
public class WeaponUiData
{
    private Sprite sprite;
    private string name;
    private string description;
    private BaseWeapon weapon;
}
