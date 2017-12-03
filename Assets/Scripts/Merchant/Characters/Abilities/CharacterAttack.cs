using UnityEngine;
using System.Collections;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class CharacterAttack : CharacterAbility
    {
        //  Should have a weapon class or something
        public bool isAttacking = false;

        public GameObject paddleObject;

        public Weapon startingWeapon;

        private Transform holder;
        private SpriteRenderer weaponSrpite;
        private SpriteRenderer characterSprite;

        private Weapon currentEquip;

        private int offset = 1;

        public void Start()
        {
            this.holder = Util.CreateChildGameobject(this.gameObject, "WeaponHolder").transform;
            this.characterSprite = this.GetComponent<SpriteRenderer>();

            this.SpawnWeapon();
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
            this.weaponSrpite.sortingOrder = this.characterSprite.sortingOrder;

            this.currentEquip = spawnedWeapon;
            this.currentEquip.owner = this.character;
        }
        

        public void SetRotation(float rotation)
        {
            rotation = this.NormalizeAngle(rotation);

            this.holder.rotation = Quaternion.Euler(0, 0, rotation + (this.currentEquip.rotationOffset * this.offset));
            
            if (rotation >= 90.0f && rotation <= 270.0f)
            {
                this.weaponSrpite.flipX = true;
                this.characterSprite.flipX = true;
            }
            else
            {
                this.weaponSrpite.flipX = false;
                this.characterSprite.flipX = false;
            }

            if (rotation >= 0.0f && rotation <= 180.0f)
            {
                this.weaponSrpite.sortingOrder = this.characterSprite.sortingOrder - 1;
            }
            else
            {
                this.weaponSrpite.sortingOrder = this.characterSprite.sortingOrder + 1;
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
