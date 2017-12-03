using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Controllers.Base;

namespace Merchant.Controllers.Players
{
    public class PlayerController : Merchant.Controllers.Base.Controller
    {

        private void Start()
        {
        }

        private void Update()
        {
            if(this.character == null)
            {
                return;
            }

            Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            this.character.movement.Direction = direction;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerMouse = mousePosition - this.character.transform.position;
            float rotation = Mathf.Atan2(playerMouse.y, playerMouse.x) * Mathf.Rad2Deg;
            this.character.attack.SetRotation(rotation);


            if(Input.GetMouseButtonUp(0))
            {
                this.character.attack.Pressed();
            }

            if(Input.GetButtonUp("Dash"))
            {
                Vector3 dashDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * rotation), Mathf.Sin(Mathf.Deg2Rad * rotation), 0);
                this.character.movement.Dash(dashDirection);
            }
        }
    }
}
