using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerSphere : MonoBehaviour
{

    public static bool XBoxController;
    public static bool keyboard;

    private string[] controllerNames;
    private int controllerNumber;
  


    public void Start()
    {
        controllerNumber = Input.GetJoystickNames().Length;
        controllerNames = Input.GetJoystickNames();

        //      Debug.Log("Name: " + controllerNames[1]);
        //Debug.Log("Number: " + controllerNum);

        if (controllerNumber == 0 || (controllerNumber == 1 && controllerNames[0].Length == 0))
        {
            keyboard = true;
            XBoxController = false;
        }
        else if (controllerNumber == 1)
        {
            if ((controllerNames[0].ToLower() == "controller (xbox 360 for windows)" || controllerNames[0].ToLower() == "controller (xbox 360 wireless receiver for windows)"))
            {
                Debug.Log("XBox 360 Controller Connected");
                keyboard = false;
                XBoxController = true;
            }

                    // Other possible control options
                   //      else if (controllerNames[0].ToLower() == "sony playstation(r)3 controller" || controllerNames[0].ToLower() == "wireless controller")
                    //   Debug.Log("PlayStation 3 Controller Connected");

                    //         else if ((controllerNames[0].ToLower() == "controller (xbox one for windows)")
                    //              Debug.Log("XBox One Controller Connected");

                    //              else if ((controllerNames[0].ToLower() == "nintendo co., ltd. pro controller" || controllerNames[0].ToLower() == "unknown pro controller" )
                    //              Debug.Log("Switch Pro Controller Connected");



                else
                {
                Debug.Log("Unknown Controller Connected");
                keyboard = true;
                XBoxController = false;
            }
        }
        else if (controllerNumber > 1 && controllerNames[0].Length > 0)
        {
            Debug.Log("Too many controllers.");
            keyboard = true;
        }





     
    }





    
}
