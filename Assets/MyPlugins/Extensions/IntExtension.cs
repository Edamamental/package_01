using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtension
{
    public static bool IsEven(this int self)
    {
        return self % 2 == 0;
    }
}
