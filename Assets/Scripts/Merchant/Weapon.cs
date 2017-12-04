using UnityEngine;
using System.Collections;
using Merchant.Characters;

public class Weapon : MonoBehaviour
{
    public Transform spawn;
    public GameObject bullet;

    public Transform sprite;

    public int bulletCount = 1;
    public int damage = 1;

    public float fireRate = 1.0f;
    public int spread = 0;
    public float accuracy = 0;

    public bool usesAmmo = true;

    public bool automatic = false;

    public float rotationOffset = 0.0f;

    public bool flipOnAttack = false;

    public Character owner;
    public float offset = 0.5f;

    public AudioClip clip;

    private AudioSource source;

    private bool canFire = true;
    private bool triggerDown = false;

    void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        if (!this.spawn)
        {
            this.spawn = this.owner.transform;
        }
    }

    public void Pressed()
    {
        this.triggerDown = true;
        this.StartCoroutine(this.Fire());
    }

    public void Released()
    {
        this.triggerDown = false;
    }

    protected virtual IEnumerator Fire()
    {
        if (this.canFire)
        {
            for (int i = 0; i < this.bulletCount; i++)
            {
                this.SpawnBullet(i);
            }

            this.canFire = false;

            if (this.flipOnAttack)
            {
                this.rotationOffset = this.rotationOffset * -1;
            }

            yield return new WaitForSecondsRealtime(this.fireRate);
            this.canFire = true;

            if (this.automatic && this.triggerDown)
            {
                this.StartCoroutine(this.Fire());
            }
        }
    }

    protected virtual GameObject SpawnBullet(int currentBulletCount)
    {
        this.source.PlayOneShot(this.clip);
        Quaternion rotation = this.transform.rotation * Quaternion.Euler(0, -this.rotationOffset, 0);

        GameObject bullet = Instantiate(
            this.bullet,
            this.spawn.position,
            rotation
        );

        //bullet.GetComponent<Bullet>().SetDamage(this.damage);

        return bullet;
    }
}