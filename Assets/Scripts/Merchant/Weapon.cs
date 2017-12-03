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
	public Vector3 offset = Vector3.zero;

    private bool canFire = true;
    private bool triggerDown = false;

    void Start()
    {
		if(!this.spawn)
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

    private IEnumerator Fire()
    {
        if (this.canFire)
        {
            for(int i = 0; i < this.bulletCount; i++)
            {
                this.SpawnBullet(i);
            }

            this.canFire = false;

			if(this.flipOnAttack)
			{
				this.rotationOffset = this.rotationOffset * -1;
			}

            yield return new WaitForSecondsRealtime(this.fireRate);
            this.canFire = true;

            if(this.automatic && this.triggerDown) 
            {
                this.StartCoroutine(this.Fire());
            }
        }
    }

    private GameObject SpawnBullet(int currentBulletCount)
    {
        float finalSpread = (float)(this.bulletCount-1) / (float)this.bulletCount * this.spread / 2;

        float spreadPiece = (float)currentBulletCount / (float)this.bulletCount;
        float currentSpread = (spreadPiece * this.spread) - finalSpread;

        Quaternion spreadRotation = Quaternion.LookRotation(Quaternion.Euler(0, currentSpread, 0) * this.transform.right);
        
        float accuracyRandom = Random.Range(-this.accuracy, this.accuracy);
        Vector3 accuracyPosition = new Vector3(0, 0, accuracyRandom);
        accuracyPosition = spreadRotation * accuracyPosition;

		Quaternion rotation = this.transform.rotation * Quaternion.Euler(0, -this.rotationOffset, 0);
		Vector3 spawnRotated = rotation * this.offset;

        GameObject bullet = Instantiate(
            this.bullet,
            this.spawn.position + accuracyPosition + spawnRotated,
            rotation
        );

        //bullet.GetComponent<Bullet>().SetDamage(this.damage);

        return bullet;
    }
}