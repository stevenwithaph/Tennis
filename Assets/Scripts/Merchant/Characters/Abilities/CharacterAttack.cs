using UnityEngine;
using System.Collections;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class CharacterAttack : CharacterAbility
    {
        //  Should have a weapon class or something
        public bool isAttacking = false;

        public Weapon startingWeapon;

        private Transform holder;
        private SpriteRenderer weaponSrpite;
        private SpriteRenderer characterSprite;

        private Weapon currentEquip;

        private int offset = 1;

        public void Start()
        {
            this.holder = Util.CreateChildGameobject(this.gameObject, "WeaponHolder").transform;
            this.holder.transform.localPosition = new Vector3(0, 0.5f, 0);
            this.characterSprite = this.GetComponentInChildren<SpriteRenderer>();

            if (this.startingWeapon)
            {
                this.SpawnWeapon();
            }
        }

        private void SpawnWeapon()
        {
            Weapon spawnedWeapon = Instantiate(startingWeapon).GetComponent<Weapon>();
            Transform weaponTransform = spawnedWeapon.transform;

            weaponTransform.parent = this.holder;
            weaponTransform.localPosition = new Vector3(
                0.5f,
                0,
                0
            );
            weaponTransform.localRotation = Quaternion.identity;

            weaponTransform.parent = this.holder;

            this.weaponSrpite = spawnedWeapon.GetComponentInChildren<SpriteRenderer>();
            if (this.weaponSrpite)
            {
                this.weaponSrpite.sortingOrder = this.characterSprite.sortingOrder;
            }

            this.currentEquip = spawnedWeapon;
            this.currentEquip.owner = this.character;
        }


        public void SetRotation(float rotation)
        {
            rotation = this.NormalizeAngle(rotation);

            this.holder.rotation = Quaternion.Euler(0, rotation + (this.currentEquip.rotationOffset * this.offset), 0);

            if (rotation >= 90.0f && rotation <= 270.0f)
            {
                if (this.weaponSrpite)
                {
                    this.weaponSrpite.flipY = true;
                }
                this.characterSprite.flipX = true;
            }
            else
            {
                if (this.weaponSrpite)
                {
                    this.weaponSrpite.flipY = false;
                }
                this.characterSprite.flipX = false;
            }

            if (this.weaponSrpite)
            {
                if (rotation >= 0.0f && rotation <= 180.0f)
                {
                    this.weaponSrpite.sortingOrder = this.characterSprite.sortingOrder - 1;
                }
                else
                {
                    this.weaponSrpite.sortingOrder = this.characterSprite.sortingOrder + 1;
                }
            }
        }

        public void Pressed()
        {
            this.currentEquip.Pressed();
        }

        public void Released()
        {
            this.currentEquip.Released();
        }

        private float NormalizeAngle(float angle)
        {
            angle = angle % 360;

            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }
    }
}
