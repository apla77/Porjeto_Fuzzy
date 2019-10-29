/**
    Project: Controlador Fuzzy
    File: Pid.h
    Purpose: Implementation of the PID control class

    @author Leandro L. S. Linhares
    @version 0.1  09/20/2019 
*/

#include "Pid.h"

/**
    PID class construtcor

    @param Kp is the PID proportional gain.
    @param Ki is the PID integrative gain.
    @param Kd is the PID derivative gain.
    @param uMax is the maximum control signal value.
    @param uMin is the minimum control signal value.
*/
Pid::Pid(const double Kp, const double Ki, const double Kd, const double uMax, const double uMin)
{
    this->SetPidParameters(Kp,Ki,Kd);
    this->SetULimits(uMax,uMin);
}

/**
    Set the PID proportional gain

    @param Kp is the new proportional gain value.
*/
void Pid::SetKp(const double Kp)
{
    this->_pidParameters.Kp = Kp;
}

/**
    Set the PID integrative gain

    @param Ki is the new integrative gain value.
*/
void Pid::SetKi(const double Ki)
{
    this->_pidParameters.Ki = Ki;
}

/**
    Set the PID derivative gain

    @param Kd is the new derivative gain value.
*/
void Pid::SetKd(const double Kd)
{
    this->_pidParameters.Kd = Kd;
}

/**
    Set all the PID parameters

    @param Kp is the new proportional gain value.
    @param Ki is the new integrative gain value.
    @param Kd is the new derivative gain value.
*/
void Pid::SetPidParameters(const double Kp, const double Ki, const double Kd)
{
    this->SetKp(Kp);
    this->SetKi(Ki);
    this->SetKd(Kd);
}

/**
    Set the maximum control signal value

    @param uMax is the new maximum control signal value.
*/
void Pid::SetUMax(const double uMax)
{
    this->_uMax = uMax;
}

/**
    Set the minimum control signal value

    @param uMin is the new minimum control signal value.
*/
void Pid::SetUMin(const double uMin)
{
    this->_uMin = uMin;
}

/**
    Set the maximum and minimum control signal values

    @param uMax is the new maximum control signal value.
    @param uMin is the new minimum control signal value.
*/
void Pid::SetULimits(const double uMax, const double uMin)
{
    this->SetUMax(uMax);
    this->SetUMin(uMin);
}

/**
    Return all PID controller parameters

    @return The PID parameters (proportional, integrative and derivative).
*/
Parameters Pid::GetPidParameters() const
{
    return this->_pidParameters;
}

/**
    Return the internal PID actions of control

    @return The PID actions (proportional, integrative and derivative).
*/
PidActions Pid::GetPidActions() const
{
    return this->_pidActions;
}

/**
    Return the control error signal

    @return The control error signal.
*/
double Pid::GetError() const
{
    return this->_error;
}

/**
    Calculate the PID control signal (PID output)

    @param pv is the process variable (variable to be controlled).
    @param sp is the set point (desired value to pv).
    @param sp is the set point (desired value to pv).    
    @return PID control signal.
*/
double Pid::CalculatePidControlSignal(double pv, double sp, double sampleTime)
{
    double error_ant = this->_error;        // store the previous error

    this->_error = sp - pv;                 // calculate the control error
    this->_sumError += this->_error;        // cumulate the error
    
    this->_pidActions.PAction = this->_pidParameters.Kp * this->_error;                     // calculate the proportional action
    this->_pidActions.IAction = this->_pidParameters.Ki * this->_sumError * sampleTime;     // calculate the integrative error

    // apply the Anti Reset Windup method if enabled
    if (this->_antiResetWindupEnabled)
    {
        this->_pidActions.IAction *= this->AntiResetWindup();       // application of the Anti Reset Windup method
    }
    
    // test possible division by zero
    if (sampleTime != 0)
        this->_pidActions.DAction = this->_pidParameters.Kd * ((this->_error - error_ant) / sampleTime);    // calculate the derivative action                    
    else
        this->_pidActions.DAction = 0;

    // calculate the ideal PID control signal
    this->_u = this->_pidActions.PAction + this->_pidActions.IAction + this->_pidActions.DAction;

    return this->Saturation();    // saturate the PID control if necessary and returns it
}

/**
    Enable the Anti Reset Windup method (C. T. Chen)
*/
void Pid::EnableAntiResetWindup()
{
    this->_antiResetWindupEnabled = true;
}

/**
    Disable the Anti Reset Windup method (C. T. Chen)
*/
void Pid::DisableAntiResetWindup()
{
    this->_antiResetWindupEnabled = false;
}

/**
    Saturate the PID control signal
*/
double Pid::Saturation() const
{
    if (this->_u < this->_uMin)         // test the control signal lower limit
        return this->_uMin;

    if (this->_u > this->_uMax)         // test the control signal upper limit
        return this->_uMax;

    return this->_u;
}

/**
    Apply the Anti Reset Windup Method relay (C. T. Chen)

    @return 0 if the integrative action must be disconsidered, 
            1 if the integrative action is considered
*/
int Pid::AntiResetWindup() const
{
    return (this->_uMax - this->_u) > 0;    // 
}