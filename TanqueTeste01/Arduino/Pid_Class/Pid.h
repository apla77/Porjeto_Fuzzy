/**
    Project: Controlador Fuzzy
    File: Pid.h
    Purpose: Definition of the PID controller class
             * Discrete Position PID Controller
             * Anti Reset Windup (C. T. Chen)
             * "Variable" Sample Time

    @author Leandro L. S. Linhares
    @version 0.1  09/20/2019 
*/

#ifndef _PID_H_
#define _PID_H_

#include <float.h>
#include <math.h>

// PID Parameters
struct Parameters
{
    double Kp = 0;      // proportional gain
    double Ki = 0;      // integrative gain
    double Kd = 0;      // derivative gain
};

// PID Actions
struct PidActions
{
    double PAction = 0;     // PID proportional action
    double IAction = 0;     // PID integrative action
    double DAction = 0;     // PID derivative action
};

// PID Class
class Pid
{
    public:
        // Constructors 
        Pid() : Pid(0,0,0,__DBL_MAX__,__DBL_MIN__) {}
        Pid(const double Kp, const double Ki, const double Kd) : Pid(Kp,Ki,Kd,__DBL_MAX__,__DBL_MIN__) {}
        Pid(const double Kp, const double Ki, const double Kd, const double uMax, const double uMin);
  
        void SetKp(const double Kp);        // Set the proportional gain
        void SetKi(const double Ki);        // Set the integrative gain
        void SetKd(const double Kd);        // Set derivative gain

        void SetPidParameters(const double Kp, const double Ki, const double Kd);      // Set PID parameters

        void SetUMax(const double uMax);                            // Set maximum control signal value (saturation)
        void SetUMin(const double uMin);                            // Set minimum control signal value (saturation)    
        void SetULimits(const double uMax, const double uMin);      // Set control signal limits (saturation)

        Parameters GetPidParameters() const;        // Get the PID parameters (Kp, Ki and Kd)
        PidActions GetPidActions() const;           // Get the PID action (P, I and D)

        double GetError() const;                    // Get the actual error control value

        double CalculatePidControlSignal(double pv, double sp, double sampleTime);      // Calculate the PID control signal

        void EnableAntiResetWindup();       // Enable the Anti Reset Windup method (C. T. Chen)
        void DisableAntiResetWindup();      // Disable the Anti Reset Windup (C. T. Chen)

    private:
        Parameters _pidParameters;                // PID parameters
        PidActions _pidActions;                   // PID action
        double _u, _uMax, _uMin;                  // control signal, maximum and minimum control signal value
        double _error = 0;                        // control error signal
        double _sumError = 0;                     // summation of control error signal

        bool _antiResetWindupEnabled = false;     // Flag of Anti Reset Windup (C. T. Chen)

        double Saturation() const;                // Apply the control saturation
        int AntiResetWindup() const;              // Apply the Anti Reset Windup Method (C. T. Chen)
};

#endif