using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class weapon_selection_manager : MonoBehaviour
{
    [Header("UI")]
    public Image weaponImage;
    public TextMeshProUGUI weaponNameText;
    public Scrollbar rangeScrollbar;
    public Scrollbar damageScrollbar;
    public Scrollbar ammoScrollbar;

    [Header("Weapon")]
    public Weapons[] weapons;
    private int index;
    private Weapons selectedWeapon;

    private float maxRange = 100f;
    private float maxDamage = 100f;
    private float maxAmmo = 100f;

    void Start()
    {
        index = 0;
        selectedWeapon = weapons[index];
        UpdateUI();
    }

    public void UpdateUI()
    {
        weaponImage.sprite = selectedWeapon.weaponImage;
        weaponNameText.text = selectedWeapon.weaponName;

        rangeScrollbar.size = selectedWeapon.range / maxRange;
        damageScrollbar.size = selectedWeapon.damage / maxDamage;
        ammoScrollbar.size = selectedWeapon.ammoCapacity / maxAmmo;
    }

    public void ChangeWeapon(bool isRight)
    {
        if (isRight)
        {
            index = (index + 1) % weapons.Length;
        }
        else
        {
            index = (index - 1 + weapons.Length) % weapons.Length;
        }

        selectedWeapon = weapons[index];
        UpdateUI();
    }

    public void SelectWeapon()
    {
        // Guardar selección para usarla en el juego
        PlayerPrefs.SetInt("SelectedWeapon", index);
    }
}