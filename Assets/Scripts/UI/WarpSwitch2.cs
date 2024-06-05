using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WarpSwitch : AbstractSwitch
{
    public Volume volumeGame;
    
    public override void ActivateSwitch()
    {
        print("hola");
    }

    public override void DeActivateSwitch()
    {
        print("Adios");
    }
}
