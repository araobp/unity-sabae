using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrafficSignal
{
    void Off();

    void Red();

    void Yellow();

    void Blue();
}
