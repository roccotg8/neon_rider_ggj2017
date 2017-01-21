using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arguments {

    public double arg0 = 0;
    public double arg1 = 0;
    public double arg2 = 0;
    public double arg3 = 0;
    public double arg4 = 0;
    public int definedArgs = 0;

    public Arguments() { }
    public Arguments(double a0) { arg0 = a0; definedArgs += 1; }
    public Arguments(double a0, double a1) : this(a0) { arg1 = a1; definedArgs += 1; }
    public Arguments(double a0, double a1, double a2) : this (a0, a1) { arg2 = a2; definedArgs += 1; }
    public Arguments(double a0, double a1, double a2, double a3) : this (a0, a1, a2) { arg3 = a3; definedArgs += 1; }
    public Arguments(double a0, double a1, double a2, double a3, double a4) : this(a0, a1, a2, a3) { arg4 = a4; definedArgs += 1; }

}
