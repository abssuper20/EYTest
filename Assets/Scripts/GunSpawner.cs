using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    private bool isGunSpawned;

    public void SpawnGun()
    {
        if (isGunSpawned) return;
        isGunSpawned = true;
        gun.SetActive(true);
    }
}
