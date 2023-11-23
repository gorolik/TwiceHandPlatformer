using UnityEngine;

namespace Sources.Infrastructure.Extensions
{
    public static class Extensions
    {
        #region LookAt2D
        public static void LookAt2D(this Transform me, Vector3 target, float angleOffset = 0, Vector3? eye = null)
        {
            float signedAngle = Vector2.SignedAngle(eye ?? me.up, target - me.position);

            if (Mathf.Abs(signedAngle) >= 1e-3f)
            {
                var angles = me.eulerAngles;
                angles.z += signedAngle + angleOffset;
                me.eulerAngles = angles;
            }
        }
        public static void LookAt2D(this Transform me, Transform target, float angleOffset = 0, Vector3? eye = null) => 
            me.LookAt2D(target.position, angleOffset, eye);

        public static void LookAt2D(this Transform me, GameObject target, float angleOffset = 0, Vector3? eye = null) => 
            me.LookAt2D(target.transform.position, angleOffset, eye);

        #endregion
    }
}