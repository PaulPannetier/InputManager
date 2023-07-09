using UnityEngine;

public class ExampleAdvanced : MonoBehaviour
{
    private void Start()
    {
        //One of the main feature is to create inputs configurations. Configurations are flexibles, modifiables at runtime and you can save it in the game folder.
        //A configuration in compose by string that represent an action link to a list of InputKey
        //They are 7 configurations, a keyboard config, a gamepad config and a config for the player1 to the player5.
        //They are 2 other config, the default keyboard config, and the default gamepad config.
        //Some examples to understand

        //add the action "Jump" link to the space button to the current keyboard config
        //the "Jump" action is store in the current keyboard controller
        InputManager.AddInputAction("Jump", InputKey.Space, BaseController.Keyboard);
        //now, to trigger the jump action, we can to the Update function this condition
        if (InputManager.GetKeyDown("Jump", BaseController.Keyboard))
        {
            //Trigger is space is pressed down.
        }

        //A single action can be link to multiples inputs.
        InputKey[] gamepadKeys = new InputKey[2] { InputKey.GPLT, InputKey.GPRT };
        InputManager.AddInputsAction("Fire", gamepadKeys, BaseController.Gamepad);//add the action "Fire" to the current gamepad controller
        if (InputManager.GetKeyDown("Fire", BaseController.Gamepad))
        {
            //trigger if the left trigger or the right trigger is pressed down.
        }

        //Be careful, only keyboard key can be store in the default/current keyboard configuration.
        //Same thing for default/current gamepad configuration, only Gamepad key can be stored in.
        InputManager.AddInputAction("Fire", InputKey.GP1Button10, BaseController.Keyboard);//don't work, a error message will be send in the console
        InputManager.AddInputAction("Fire", InputKey.T, BaseController.Gamepad);//don't work, a error message will be send in the console

        //You have also input configuration for player, it's the same principle
        InputManager.AddInputAction("Run", InputKey.LeftShift, PlayerIndex.One);//add the "Run" action to the player1 input config
        if(InputManager.GetKeyDown("Run", PlayerIndex.One))
        {
            //trigger if the LeftShift button is pressed down.
        }

        //All AddInput(s)Action(s) functions have a optional boolean parameter named defaultConfig, if this param is on true, the action will be store in the default controller instead of the current controller
        InputManager.AddInputAction("Fly", InputKey.F, BaseController.Keyboard, true);//add the "Fly" action to the default keyboard input config
        if (InputManager.GetKeyDown("Fly", BaseController.Keyboard))
        {
            //The condition below will never trigger because the "Fly" action is store in the default Keyboard config
        }



        //you can modify the deadzone of the two thumbsticks and triggers for the 4 gamepad controller
        //The deadzone of a thumbstick define a zone of the thumbstick where position are ignore.
        //The deadzone of a thumbstick in define by a Vector2, the x component if for horizontal deadzone and the y component is for the vertical deadzone
        //The next line will set the deadzone of the Right thumbstick of the first gamepad controller to (0.05f, 0.05f).
        //It mean that if the x position return by the gamepad is in the interval [-0.05f, 0.05f] "or if -0.05f <= x <= 0.05"
        //then the InputManager.GetGamepadStickPosition(ControllerType.Gamepad1, GamepadStick.right).x will be equal to 0
        //Moreover if the x position return by the gamepad is in the interval [-1f, -0.95f] ou in [0.95f, 1f] then the x value return by the InputManager will be -1 or 1.
        //The process is the same for the y position but in the vertical axis.
        InputManager.GP1RightThumbStickDeadZone = new Vector2(0.05f, 0.05f);//default is (0.1f, 0.1f)

        //Same thing for the trigger deadzone but with a float, we will set the deadzone to 0.08 for the right trigger and 0.1 to the left one for the first gamepad controller (number is just for the example)
        //It mean that is if the value return by the right trigger gamepad controller is <= 0.08, then the InputManager will return 0 for the trigger value
        //And if the value return by the gamepad controller is >= 0.92, then the InputManager will return 1 for the trigger value
        InputManager.GP1TriggersDeadZone = new Vector2(0.08f, 0.1f);//x is for the left trigger, y for the right trigger, default value is (0.1f, 0.1f)
        InputManager.ResetGamepadDeadzone();//to restore the default deadzone of all gamepad
    }
}
