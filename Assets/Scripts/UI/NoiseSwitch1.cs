using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseSwitch : AbstractSwitch
{
    public override void ActivateSwitch()
    {
        print("hola");
    }

    public override void DeActivateSwitch()
    {
        print("Adios");
    }
}
