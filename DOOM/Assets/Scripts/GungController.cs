using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController instance;

    private BoxCollider gunTrigger;

    public Weapons weapon;

    public LayerMask raycastLayer;

    public bool canShoot;


    public AudioSource weaponAS;

    public Material initMateerial;
    public Material detectedMaterial;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(instance);
        }
    }
       
       
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        canShoot = true;
        SetTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void SetTrigger()
    {
        gunTrigger.size= new Vector3(weapon.horizontalRange, weapon.verticalRange, weapon.range);
        gunTrigger.center = new Vector3(0, (0.5f * weapon.verticalRange - 1f), weapon.range * 0.5f);
    }

    IEnumerator CanShoot(float time)
    {
        canShoot=false;
        yield return new WaitForSeconds(time);
        canShoot = true;
    }

    public void Shoot()

    {
        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            weaponAS.PlayOneShot(weapon.sound);

            foreach(Enemy enemy in EnemyManager.instance.enemiesInRange)
            {
                var dir = (enemy.transform.position - transform.position).normalized;

                RaycastHit hit;

                if(Physics.Raycast(transform.position, dir, out hit, weapon.range * 1.5f , raycastLayer));
                {
                    if (hit.transform== enemy.transform)
                    {
                        Quaternion rot = Quaternion.LookRotation(-hit.normal);
                        enemy.Damage(weapon.damage, rot);
                    }
                }
                Debug.DrawRay(transform.position, dir * weapon.range);
            }

            StartCoroutine(CanShoot(weapon.fireRate));
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            EnemyManager.instance.AddEnemy(enemy);
            enemy.GetComponent<Renderer>().material= detectedMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            EnemyManager.instance.RemoveEnemy(enemy);
            enemy.GetComponent<Renderer>().material = detectedMaterial;
        }
    }
}
