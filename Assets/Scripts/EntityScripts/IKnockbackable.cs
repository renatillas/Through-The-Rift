using System.Collections;
using UnityEngine;

namespace EntityScripts
{
    public interface IKnockbackable
    {
        float KnockbackCounter { get; }
        IEnumerator ApplyKnockback(Vector3 origin, float magnitude, float secondsDelay);
    }
}