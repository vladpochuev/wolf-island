using System;
using WolfIsland.Animals;
using WolfIsland.Environment;

namespace WolfIsland
{
    public static class ButtonStateFactory
    {
        public static Object GetObject(FormButtonState buttonState)
        {
            if (buttonState == FormButtonState.Ocean)
            {
                return new Ocean();
            }

            if (buttonState == FormButtonState.Plain)
            {
                return new Plain();
            }

            if (buttonState == FormButtonState.Rabbit)
            {
                return new Rabbit();
            }

            if (buttonState == FormButtonState.WolfM)
            {
                return new WolfM();
            }

            if (buttonState == FormButtonState.WolfF)
            {
                return new WolfF();
            }

            return null;
        }
    }
}