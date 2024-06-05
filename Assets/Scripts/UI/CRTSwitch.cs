using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRTSwitch : AbstractSwitch
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
