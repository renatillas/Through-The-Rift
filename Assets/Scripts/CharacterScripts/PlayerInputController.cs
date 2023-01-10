using UnityEngine;

namespace CharacterScripts
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerInputController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private Jumper _jumper;

        private static Vector3 MovementDirection =>
            new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")).normalized;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _jumper = GetComponent<Jumper>();
        }

        private void FixedUpdate()
        {
            if (MovementDirection != Vector3.zero)
                _characterMovement.Move(MovementDirection);

            if (Input.GetAxis("Jump") > 0)
                _jumper.TryJump();
        }
    }
}