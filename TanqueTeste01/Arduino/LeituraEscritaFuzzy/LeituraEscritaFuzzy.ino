#include <Util.h>
#include <Pid.h>

const int SENSOR_PIN = A0;        // Pino da entrada analógica (entrada do sensor)
const int PWM_PIN = 3; 

double parameter_A = 0.119;     // Parâmetro A de conversão para nível y = Ax + B 
double parameter_B = 4.1029;      // Parâmetro A de conversão para nível y = Ax + B

int sensorValue = 0;        // Pressure sensor measurement  
double levelCm = 0.0;         // Tank level in centimeter

int dutyCylePump = 0;             // Duty cycle of the water pump
         
bool sendData = false;            // Flag used to send data to supervisory system 
bool execPid = false;       // Flag used to execute PID controller algorithm  
bool first = true;

int setPoint = 15;          // Set point value

unsigned long currentTime, previousTime;  // Used to calculate the sample time
double sampleTime;                // Sample time value

Pid pidControl = Pid();         // PID controller object
Util reading = Util();        // Util object (auxiliar commands)  

void setup() 
{ 
    Serial.begin(9600);            // Initialize the serial interface setting the baud rate
    pidControl.SetULimits(255, 0);       // Set the control signal limits
    pinMode(PWM_PIN, OUTPUT);        // Set the PWM pin
    pidControl.EnableAntiResetWindup();    // Enable the PID Anti Reset Windup method (CHC)
}

void loop() 
{
    analogWrite(PWM_PIN, dutyCylePump);            // Set the PWM-Pump duty cycle
    
  if (Serial.available() > 0)                // Check the serial port content
  {                    
    String getPortaSerial = reading.leituraString();   // Read the supervisory system command in serial port
        char commandCode = getPortaSerial[0];        // Obtain the command code given by supervisory
    
      // Enable data sending to the supervisory system
      if(commandCode == 'L')  
      {
          sendData = true;
    }             
              
        // Disable data sending to the supervisory system
        else if(commandCode == 'D')
      {
          reading.desligarSistema(dutyCylePump, levelCm, sendData, execPid, first);     // Turn off the didatic system       
      }

        // Set a manually given PWM-Pump duty cycle
        else if(commandCode == 'B')
      {
          reading.ligarBomba(execPid, getPortaSerial, dutyCylePump);
      }

        // Set the set point value
        else if(commandCode == 'S')
      {
          reading.setSetPoint(getPortaSerial, setPoint);
      }   

        // Set the conversion parameters
        else if(commandCode == 'A')
      {
          reading.parametrosAB(getPortaSerial, parameter_A, parameter_B);
      }

        // Set the PID parameters
        else if(commandCode == 'P')
      {
          reading.setParametrosPID(getPortaSerial, pidControl, execPid);
      }
  } 
   
  sensorValue = analogRead(SENSOR_PIN);            // Read the pressure sensor
  levelCm = parameter_A * sensorValue - parameter_B;   // Convert the measurement to level in cm
   
  // Level switch (HIGH)
  if(levelCm > 30)
  {
    dutyCylePump = (80 + 40 * 1.75);          //TODO: definir valor de acionamento (constante)
  }                                                       //      para evitar transbordamento

  // PID controller execution 
  if(execPid)
  {   
    // Obtain the currentTime stamp
    if (!first)
    {
          currentTime = millis();
        }
        else
      {
          first = false;
          currentTime += 0;
        }     
    
      sampleTime = (double)(currentTime - previousTime) / 1000; // Calculate the sample time
        if(levelCm < 30.00)
      {
      // Calculate the PID control signal (PWM-Pump duty cycle)
          dutyCylePump = pidControl.CalculatePidControlSignal(levelCm, setPoint, sampleTime); 
        }
        
    previousTime = millis();  // Obtain the previousTime stamp
    }
   
    // Send data to supervisory
    if(sendData) 
    {
    Serial.print("[" + String(levelCm) + "/" + String(dutyCylePump) + "]");
  }
      
  delay(200);  // Delay execution
}
