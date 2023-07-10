using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    private void Update()
    {
        //The full funtionnalities are availiable when you add the asset in your project, no need to attach something on a gameobject or something else.
        //The full funtionnalities are availiable is also available on non MonoBehaviour class (like static or regular C# class).
        //To access on the InputManager functions, just une the static class InputManager.

        //To get the state of a key, use the GetKeyDown/GetKeyUp/GetKey function
        //The InputKey enum contain all the Keyboard key, the mouse key and all the button on a XBox controller for 4 defferents controllers
        if (InputManager.GetKeyDown(InputKey.Space))
        {
            print("Space is pressed down.");//GetKeyDown return true 1 frame when the key is pressed down
        }

        //It work the same for mouse buttons, whose and considered as Keyboard buttons
        if (InputManager.GetKeyDown(InputKey.Mouse1))
        {
            print("Right click is pressed down.");//GetKeyDown return true 1 frame when the key is pressed down
        }

        //you can also use the KeyCode enum present by default in Unity, KeyCode enum is include to the InputKey enum
        if (InputManager.GetKeyUp(KeyCode.A))
        {
            print("A key was pressed up.");//GetKeyUp return true 1 frame when the key is release
        }

        //The Keyboard enum contain only Keyboard and Mouse keys, all the Keyboard keys are include in the InputKey enum
        if (InputManager.GetKey(KeyboardKey.UpArrow))
        {
            print("UpArrow button is currently pressed.");//GetKey return true while the key is pressed
        }

        //The GamepadKey enum contain all the keys for 4 differents gamepads controllers, GamepadKey is include to the InputKey enum
        if (InputManager.GetKeyDown(GamepadKey.GP2Start))
        {
            print("The 4th button of the 2nd gamepad controller is pressed down.");
        }

        //The GeneralGamepadKey enum contain key for all gamepad controller, GeneralGamepadKey is include to GamepadKey
        if (InputManager.GetKeyDown(GeneralGamepadKey.GPA))
        {
            print("A button was pressed down by a controller");//Any gamepad controller where the A button was pressed will trigger the previous condition
        }

        //You can also use GetKeyDown/GetKeyUp/GetKey on analogic button like thumbstick or trigger
        if (InputManager.GetKeyDown(GamepadKey.GP1TBSLLeft))
        {
            print("The left thumbstick of the first controller have reach his left position.");
        }
        if (InputManager.GetKeyDown(GamepadKey.GPRT))
        {
            print("A right trigger of a controller was pressed down.");
        }

        //You can get the current position of a thumbstick
        Vector2 stickPos = InputManager.GetGamepadStickPosition(ControllerType.Gamepad1, GamepadStick.right);//stickPos.x is between -1 and 1 and repressent the position of the thumbstick on the horizontal axis.
        //stickPos.y is between -1 and 1 and repressent the position of the thumbstick on the vertical axis.
        if (stickPos != Vector2.zero)
        {
            print("The current position of the gamepad1 left thumbstick is : " + stickPos);        
        }

        //You can get the value of a trigger
        float leftTrigger = InputManager.GetGamepadTrigger(ControllerType.Gamepad1, GamepadTrigger.left);//leftTrigger is between 0 and 1. 0 is the release state, 1 is the full pressed state
        if (leftTrigger > 0f)
        {
            print("The current value of the gamepad1 left trigger is : " + leftTrigger);
        }

        if(InputManager.GetKeyDown(InputKey.GPB))
        {
            //You can handle controller vibration
            float vibrationIntensity = 1f;//0 is for no vibration, 1 is max vibration
            InputManager.SetVibration(vibrationIntensity, ControllerType.GamepadAll);//vibrate all the connected gamepad at max vibration
        }

        if(InputManager.GetKeyDown(InputKey.GPX))
        {
            //you can also make different intensity for the right and left side of the gamepad
            InputManager.SetVibration(1f, 0f, ControllerType.Gamepad1);//vibrate only the right side of the first controller
            print("Begin vibrate!");
        }

        //The vibration of the controller don't turn of automatically, you have to stop it
        if (InputManager.GetKeyDown(InputKey.GPY))
        {
            InputManager.StopVibration();//you can pass in parameter the gamepad to stop vibrate.
            print("Stop vibrate!");
        }

        //You can also set the duration of the vibration, and set a vibration delay
        if (InputManager.GetKeyDown(InputKey.GPDPadDown))
        {
            //the first controller will vibrate at 50%, during 2sec, 1sec after pressed down DPad down button.
            InputManager.SetVibration(0.5f, 0.5f, 2f, 1f, ControllerType.Gamepad1);
        }

        //You can verify if a gamepad controller is connected
        if(InputManager.IsGamePadConnected(ControllerType.Gamepad1))
        {
            // The gamepad1 is connected !
        }

        //You can verify if a gamepad controller become connected this frame
        if(InputManager.GetGamepadPlugged(out ControllerType gamepadIndex))
        {
            print("The " +  gamepadIndex.ToString() + " was plugged!");
        }

        //Same thing but when the gamepad is unplugged
        if (InputManager.GetGamepadUnPlugged(out ControllerType gamepadIndex2))
        {
            print("The " + gamepadIndex2.ToString() + " was unplugged!");
        }

        //You can listen if a key is pressed
        if(InputManager.Listen(ControllerType.Gamepad1, out InputKey key))
        {
            print("The key " + InputManager.KeyToString(key) + " was pressed down.");
        }

        //You can listen if a number is pressed on the keyboard
        if (InputManager.NumberPressed(out string number))
        {
            print("The number " + number + " was pressed down.");
        }

        //You can listen if a char is pressed on the keyboard
        if (InputManager.CharPressed(out string character))
        {
            print("The character " + character + " was pressed down.");
        }

        //You can also get informations about the mouse
        bool isAMouseConnected = InputManager.isAMouseConnected;
        if (isAMouseConnected)
        {
            Vector2 mousePosition = InputManager.mousePosition;
            if (InputManager.MouseWheel(out MouseWheelDirection mouseWheelDirection))
            {
                //The mouse wheel has been moved this frame!
                if (mouseWheelDirection == MouseWheelDirection.Up)
                {
                    print("Mouse scroll up!");
                }
                else
                {
                    print("Mouse scroll down!");
                }
                //get the current scroll delta
                print("Mouse delta : " + InputManager.mouseScrollDelta);
            }
        }
    }
}
