using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move by position, velocity, & acceleration ranges.
public class BulletMovePVA : BulletMoveInterface {

    public RangeValue xOffset;
    public RangeValue yOffset;
    public RangeValue xVelo;
    public RangeValue yVelo;
    public RangeValue xAccel;
    public RangeValue yAccel;

    private double cur_xo;
    private double cur_yo;
    private double cur_xv;
    private double cur_yv;
    private double cur_xa;
    private double cur_ya;
	
    public BulletMovePVA(double x, double y) {
        xOffset = new RangeValue(x);
        yOffset = new RangeValue(y);
        cur_xo = x;
        cur_yo = y;
    }

    public BulletMovePVA(double x, double y, double xv, double yv) :
        this (x, y)  {
        xVelo = new RangeValue(xv);
        yVelo = new RangeValue(yv);
        cur_xv = xv;
        cur_yv = yv;
    }

    public BulletMovePVA(double x, double y, double xv, double yv, double xa, double ya) :
        this ( x, y, xv, yv ) {
        xAccel = new RangeValue(xa);
        yAccel = new RangeValue(ya);
        cur_xa = xa;
        cur_ya = ya;
    }

    public BulletMovePVA(RangeValue x, RangeValue y) {
        if (x == null)
            xOffset = new RangeValue();
        else
            xOffset = x;
        if (y == null)
            yOffset = new RangeValue();
        else
            yOffset = y;
        cur_xo = xOffset.getValue();
        cur_yo = yOffset.getValue();
    }

    public BulletMovePVA(RangeValue x, RangeValue y, RangeValue xv, RangeValue yv) :
        this(x, y) {
        if (xv == null)
            xVelo = new RangeValue();
        else
            xVelo = xv;
        if (yv == null)
            yVelo = new RangeValue();
        else
            yVelo = yv;
        cur_xv = xVelo.getValue();
        cur_yv = yVelo.getValue();
    }

    public BulletMovePVA(RangeValue x, RangeValue y, RangeValue xv, RangeValue yv, RangeValue xa, RangeValue ya) :
        this(x, y, xv, yv) {
        if (xa == null)
            xAccel = new RangeValue();
        else
            xAccel = xa;
        if (ya == null)
            yAccel = new RangeValue();
        else
            yAccel = ya;
        cur_xa = xAccel.getValue();
        cur_ya = yAccel.getValue();
    }

    public override void FixedUpdate() {
        cur_xo += cur_xv;
        cur_yo += cur_yv;
        cur_xv += cur_xa;
        cur_yv += cur_ya;
	}

    public override double getXOff() {
        return cur_xo;
    }

    public override double getYOff() {
        return cur_yo;
    }

    public override BulletMoveInterface getClone() {
        return new BulletMovePVA(xOffset, yOffset, xVelo, yVelo, xAccel, yAccel);
    }
}
