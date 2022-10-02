using UnityEngine;

namespace SuareDemo
{
    public class Methods_Swerve
    {
        public static void SwerveHorizontally(Transform transform, Vector3 mousePosition, Camera camera, float speed, LayerMask layer)
        {
            mousePosition.z = camera.transform.localPosition.z;

            if (Physics.Raycast(camera.ScreenPointToRay(mousePosition), out RaycastHit hit, 50f, layer))
            {
                Vector3 hitPosition = hit.point;
                hitPosition.y = transform.localPosition.y;
                hitPosition.z = transform.localPosition.z;

                transform.localPosition = Vector3.MoveTowards(transform.localPosition, hitPosition, speed * Time.deltaTime);
            }
        }
    }
}
