using src.WeaponScripts;
using UnityEngine;

namespace src
{
    // Interfaz para los animation events. Maneja las dependencias de las armas y llama a sus correspondientes metodos.
    public class AttackManager : MonoBehaviour
    {
        private SwordManager _swordManager;

        private void Awake()
        {
            _swordManager = GetComponentInChildren<SwordManager>();
        }

        // AnimationEventCallback
        void StartAttackWind(string weaponName)
        {
            switch (weaponName)
            {
                case "1h":
                    _swordManager.OnAttackWind();
                    break;
            }
        }

        // AnimationEventCallback
        void EndAttackWind(string weaponName)
        {
            switch (weaponName)
            {
                case "1h":
                    _swordManager.OnEndAttackWind();
                    break;
            }
        }
    }
}