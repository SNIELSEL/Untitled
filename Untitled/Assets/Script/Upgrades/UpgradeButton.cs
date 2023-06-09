using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Upgrade[] upgrade;
    private Upgrade active;

    private TextMeshProUGUI name, uitleg;
    private RawImage image;
    public UpgradeManage upgradeManager;

    private void Start()
    {
        name = gameObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        uitleg = gameObject.transform.Find("Uitleg").GetComponent<TextMeshProUGUI>();
        image = gameObject.transform.Find("Icon").GetComponent<RawImage>();

        upgradeManager = GameObject.Find("Upgrades").GetComponent<UpgradeManage>();
    }

    private void OnEnable()
    {
        active = upgrade[Random.Range(0, upgrade.Length)];
        upgradeManager = GameObject.Find("Upgrades").GetComponent<UpgradeManage>();
        GameObject.Find("WeaponCam").GetComponent<PlayerInput>().enabled = false;

        if (upgradeManager.dubbleShot == true && active.upgradeName == "Dubble shot")
        {
            OnEnable();
        }

        else if (upgradeManager.enemyVision == true && active.upgradeName == "Enemy Vision")
        {
            OnEnable();
        }

        else
        {
            GetComponent<Button>().onClick.AddListener(() => upgradeManager.Pickup(active));
        }
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("WeaponCam").GetComponent<PlayerInput>().enabled = true;
    }

    private void Update()
    {
        name.text = active.upgradeName;
        uitleg.text = active.bio;
        image.texture = active.image;
    }
}
