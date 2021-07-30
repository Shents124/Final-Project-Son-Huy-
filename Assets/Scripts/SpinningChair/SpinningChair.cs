using UnityEngine;

public class SpinningChair : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up * (120 * Time.deltaTime));
    }
}
