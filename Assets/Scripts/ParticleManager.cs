using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem mainThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] CollisionHandler collisionHandler;
    [SerializeField] Movement movement;

    void Start() 
    {
        collisionHandler.OnRocketSuccess += RocketSuccess;
        collisionHandler.OnRocketCrash += RocketCrash;
        movement.OnRocketThrust += RocketThrust;
        movement.OnRocketThrustStop += RocketThrustStop;

    }    

    void RocketCrash()
    {
        crashParticle.Play();
    }

    void RocketSuccess()
    {
        successParticle.Play();
    }

    void RocketThrust(Thrusts currentThrust)
    {
        switch (currentThrust)
        {
            case Thrusts.Main:
                mainThrustParticle.Play();
                break;
            case Thrusts.Right:
                rightThrustParticle.Play();
                break;
            case Thrusts.Left:
                leftThrustParticle.Play();
                break;
            default:
                break;
        } 
    }

    void RocketThrustStop(Thrusts currentThrust)
    {
        switch (currentThrust)
        {
            case Thrusts.Main:
                mainThrustParticle.Stop();
                break;
            case Thrusts.Right:
                rightThrustParticle.Stop();
                break;
            case Thrusts.Left:
                leftThrustParticle.Stop();
                break;
            default:
                break;
        }
    }
}

public enum Thrusts
{
    Main, Right, Left
}
