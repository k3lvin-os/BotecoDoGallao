
using System;
using System.Collections;
using UnityEngine;

namespace BotecoDoGallao.Util
{
    public static class MonobehaviourExtensionMethods
    {
        public static IEnumerator CallbackCoroutine(this MonoBehaviour m, Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action.Invoke();
        }
    }
}
