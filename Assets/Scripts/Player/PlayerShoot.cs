using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gunPrefab; // Added gun prefab
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    private GameObject gunInstance; // Instance of the gun
    private Transform bulletSpawn; // Moved inside the class

    void Start()
    {
        if (gunPrefab != null)
        {
            gunInstance = Instantiate(gunPrefab, transform);
            bulletSpawn = gunInstance.transform.Find("Muzzle"); // Look for an object named "Muzzle" in the gun prefab
            if (bulletSpawn == null)
            {
                Debug.LogError("Muzzle not found in gun prefab.");
            }
        }
        else
        {
            Debug.LogError("Gun prefab is not assigned.");
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletSpawn == null)
        {
            Debug.LogError("bulletSpawn is not assigned.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bulletSpawn.forward * bulletSpeed; // Shoot in the direction the muzzle is facing
    }
}
