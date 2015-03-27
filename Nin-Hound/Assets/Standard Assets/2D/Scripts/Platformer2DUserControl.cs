using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private bool shoot;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
			if (!shoot)
			{
				// Read the jump input in Update so button presses aren't missed.
				//m_Character.m_Attack = false;
				shoot = Input.GetKeyDown(KeyCode.Z);
			}
			if (Input.GetKeyDown(KeyCode.Z)) m_Character.m_Attack = true;
			else m_Character.m_Attack = false;

        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
			bool crouchStand = Input.GetKeyUp (KeyCode.LeftControl);
			if (crouchStand)
				crouch = false;
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump, shoot, crouchStand);
            m_Jump = false;
			shoot = false;
			//m_Character.m_Attack = false;
        }
    }
}
