using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scar : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0 && extra.reload == false)
        {
            base.Shoot();

            GameObject.Find("Player").GetComponent<Movement144>().y -= recoilMain;
            GameObject.Find("Player").GetComponent<Movement144>().x += recoilMain / 3;

            if (ammoCount == 0)


                if (extra.infiniteAmmo == false)

                    base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

            if (extra.infiniteAmmo == false)
            {
                ammoCount -= 1;
            }

            if (ammoCount == 0)
            {
                extra.ammoText.color = Color.red;
                extra.reloadText.SetActive(true);
            }

            base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
        }
    }
}