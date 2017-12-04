using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Controllers.Base;

namespace Merchant.Controllers.Players
{
    public class PlayerController : Merchant.Controllers.Base.Controller
    {
        private Plane plane;

        private void Start()
        {
            this.plane = new Plane();
        }

        private void Update()
        {
            if(this.character == null)
            {
                return;
            }

            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            this.character.movement.Direction = direction;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;

            this.plane.SetNormalAndPosition(Vector3.up, this.character.transform.position);
            this.plane.Raycast(ray, out enter);

            Vector3 playerMouse = ray.GetPoint(enter) - this.character.transform.position;
            float rotation = Mathf.Atan2(playerMouse.x, playerMouse.z) * Mathf.Rad2Deg;
            this.character.attack.SetRotation(rotation - 90);

            if(Input.GetMouseButtonUp(0))
            {
                this.character.attack.Pressed();
            }

            if(Input.GetButtonUp("Dash"))
            {
                Vector3 dashDirection = new Vector3(Mathf.Sin(Mathf.Deg2Rad * rotation), 0, Mathf.Cos(Mathf.Deg2Rad * rotation));
                this.character.movement.Dash(dashDirection);
            }
        }
    }
}
