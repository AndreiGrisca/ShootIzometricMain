using UnityEngine;

public class position : MonoBehaviour
{
      public static bool isPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("trigger");
            isPos = true;
        }
    }
}
