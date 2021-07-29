using UnityEngine;

public class JoystickInput : MonoBehaviour
{
   private static JoystickInput _instance;

   public static JoystickInput Instance
   {
      get
      {
         if(_instance == null)
            Debug.Log("Joystick Input is null");
         return _instance;
      }
   }
   
   public FixedJoystick joystickController;

   private void OnEnable()
   {
      _instance = this;
   }

   public float GetHorizontal()
   {
      return joystickController.Horizontal;
   }

   public float GetVertical()
   {
      return joystickController.Vertical;
   }
}
