using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private int maxBulletsPerRound;
    [SerializeField] private TMP_Text bulletText;
    private int currentBulletCount;

    private void Start()
    {
        currentBulletCount = maxBulletsPerRound;
        bulletText.text = currentBulletCount.ToString();
    }

    private void OnFire(int bulletCount)
    {
        bulletText.text = bulletCount.ToString();
        if (bulletCount == 0)
            bulletText.text = "Reload";
    }
}
