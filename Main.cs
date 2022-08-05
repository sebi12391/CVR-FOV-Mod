using MelonLoader;
using UnityEngine;

namespace FOVmod
{
    public class Main : MelonMod
    {

        private static Camera gameCamera;

        private static int FOV;
        private static int mVal;

        public static MelonPreferences_Category FOVsettings;
        public static MelonPreferences_Entry<int> defaultFOV;
        public static MelonPreferences_Entry<int> modifierValue;
        public static MelonPreferences_Entry<KeyCode> increaseKey;
        public static MelonPreferences_Entry<KeyCode> decreaseKey;

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("cBass's FOV Mod has Loaded");

            FOVsettings = MelonPreferences.CreateCategory("FOVsettings");
            defaultFOV = FOVsettings.CreateEntry("defaultFOV", 75);
            modifierValue = FOVsettings.CreateEntry("modifierValue", 2);
            increaseKey = FOVsettings.CreateEntry("increaseKey", KeyCode.T);
            decreaseKey = FOVsettings.CreateEntry("decreaseKey", KeyCode.Y);


            FOVsettings.LoadFromFile();
            MelonLogger.Msg("Successfully loaded from config file");

            FOV = defaultFOV.Value;
            mVal = modifierValue.Value;

            MelonLogger.Msg("FOV will be set to: " + FOV);
            MelonLogger.Msg("Modifier Number will be set to: " + mVal);
            MelonLogger.Msg("The key to increase FOV is: " + increaseKey.Value);
            MelonLogger.Msg("The key to decrease FOV is: " + decreaseKey.Value);

        }


        private static void setFOV(int fov)
        {
            gameCamera.fieldOfView = fov;
        }

        public override void OnUpdate()
        {
            gameCamera = Camera.main;
            setFOV(FOV);


            if (Input.GetKeyDown(increaseKey.Value))
            {
                FOV = FOV + mVal;
                setFOV(FOV);
                MelonLogger.Msg("Increased FOV by {0}, new FOV is: {1}", mVal, FOV);

            }
            if (Input.GetKeyDown(decreaseKey.Value))
            {
                FOV = FOV - mVal;
                setFOV(FOV);
                MelonLogger.Msg("Decreased FOV by {0}, new FOV is: {1}", mVal, FOV);

            }

        }

    }
}