#include <Util.h>
#include <Pid.h>
#include <Fuzzy.h>

const int SENSOR_PIN = A0;        // Pino da entrada analógica (entrada do sensor)
const int PWM_PIN = 3; 

double parameter_A = 0.119;     // Parâmetro A de conversão para nível y = Ax + B 
double parameter_B = 4.1029;      // Parâmetro A de conversão para nível y = Ax + B

int sensorValue = 0;        // Pressure sensor measurement  
double levelCm = 0.0;         // Tank level in centimeter

double error_ant = 0;
double error = 0;
double Derror = 0;

int dutyCylePump = 0;             // Duty cycle of the water pump
         
bool sendData = false;            // Flag used to send data to supervisory system 
bool execPid = false;       // Flag used to execute PID controller algorithm  
bool first = true;
bool execFazzy = false;

int setPoint = 15;          // Set point value

unsigned long currentTime, previousTime;  // Used to calculate the sample time
double sampleTime;                // Sample time value

Pid pidControl = Pid();         // PID controller object
Util reading = Util();        // Util object (auxiliar commands)  

Fuzzy *fuzzy = new Fuzzy();

void setup() 
{ 
    Serial.begin(9600);            // Initialize the serial interface setting the baud rate
    pidControl.SetULimits(255, 0);       // Set the control signal limits
    pinMode(PWM_PIN, OUTPUT);        // Set the PWM pin
    pidControl.EnableAntiResetWindup();    // Enable the PID Anti Reset Windup method (CHC)

  FuzzyInput *error = new FuzzyInput(1);
  
  FuzzySet * eLN = new FuzzySet(-30,-30,-7,-5);
  FuzzySet * eSN = new FuzzySet(-7,-3,-3,-1.5);
  FuzzySet * eZR = new FuzzySet(-1.5,0,0,1.5);
  FuzzySet * eSP = new FuzzySet(1.5,3,3,7);
  FuzzySet * eLP = new FuzzySet(5,7,30,30);

  error->addFuzzySet(eLN);
  error->addFuzzySet(eSN);
  error->addFuzzySet(eZR);
  error->addFuzzySet(eSP);
  error->addFuzzySet(eLP);  

  fuzzy->addFuzzyInput(error);
  
  FuzzyInput *dError = new FuzzyInput(2);

  FuzzySet * deLN = new FuzzySet(-1667,-1667,-0.35,-0.2);
  FuzzySet * deSN = new FuzzySet(-0.3,-0.2,-0.2,-0.05);
  FuzzySet * deZR = new FuzzySet(-0.1,0,0,0.1);
  FuzzySet * deSP = new FuzzySet(0.05,0.2,0.2,0.3);
  FuzzySet * deLP = new FuzzySet(0.2,0.35,1667,1667);  

  dError->addFuzzySet(deLN);
  dError->addFuzzySet(deSN);
  dError->addFuzzySet(deZR);
  dError->addFuzzySet(deSP);
  dError->addFuzzySet(deLP);  

  fuzzy->addFuzzyInput(dError);

  FuzzyOutput *du = new FuzzyOutput(1);

  FuzzySet * duLN = new FuzzySet(-8000, -8000, -50, -35);
  FuzzySet * duSN = new FuzzySet(-40, -20, -20, -5);
  FuzzySet * duZR = new FuzzySet(-5, 0, 0, 5);
  FuzzySet * duSP = new FuzzySet(5, 20, 20, 40);
  FuzzySet * duLP = new FuzzySet(35, 50, 8000, 8000);

  du->addFuzzySet(duLN);
  du->addFuzzySet(duSN);
  du->addFuzzySet(duZR);
  du->addFuzzySet(duSP);
  du->addFuzzySet(duLP);

  fuzzy->addFuzzyOutput(du);

  FuzzyRuleConsequent* then_du_LN = new FuzzyRuleConsequent();
  then_du_LN->addOutput(duLN);

  FuzzyRuleConsequent* then_du_SN = new FuzzyRuleConsequent();
  then_du_SN->addOutput(duSN);

  FuzzyRuleConsequent* then_du_ZR = new FuzzyRuleConsequent();
  then_du_ZR->addOutput(duZR);

  FuzzyRuleConsequent* then_du_SP = new FuzzyRuleConsequent();
  then_du_SP->addOutput(duSP);

  FuzzyRuleConsequent* then_du_LP = new FuzzyRuleConsequent();
  then_du_SN->addOutput(duSN);


  // If error = LN AND derror = LN Then du = LN
  FuzzyRuleAntecedent* if_Error_LN_And_DError_LN = new FuzzyRuleAntecedent();
  if_Error_LN_And_DError_LN->joinWithAND(eLN,deLN);   
  
  FuzzyRule* fuzzyRule01 = new FuzzyRule(1, if_Error_LN_And_DError_LN, then_du_LN);

  // If error = LN AND derror = SN Then du = LN
  FuzzyRuleAntecedent* if_Error_LN_And_DError_SN = new FuzzyRuleAntecedent();
  if_Error_LN_And_DError_SN->joinWithAND(eLN,deSN);   

  FuzzyRule* fuzzyRule02 = new FuzzyRule(2, if_Error_LN_And_DError_SN, then_du_LN);

  // If error = LN AND derror = ZR Then du = LN
  FuzzyRuleAntecedent* if_Error_LN_And_DError_ZR = new FuzzyRuleAntecedent();
  if_Error_LN_And_DError_ZR->joinWithAND(eLN,deZR);   

  FuzzyRule* fuzzyRule03 = new FuzzyRule(3, if_Error_LN_And_DError_ZR, then_du_LN);

  // If error = LN AND derror = SP Then du = LN
  FuzzyRuleAntecedent* if_Error_LN_And_DError_SP = new FuzzyRuleAntecedent();
  if_Error_LN_And_DError_SP->joinWithAND(eLN,deSP);   

  FuzzyRule* fuzzyRule04 = new FuzzyRule(4, if_Error_LN_And_DError_SP, then_du_LN);

  // If error = LN AND derror = LP Then du = LN
  FuzzyRuleAntecedent* if_Error_LN_And_DError_LP = new FuzzyRuleAntecedent();
  if_Error_LN_And_DError_LP->joinWithAND(eLN,deLP);   

  FuzzyRule* fuzzyRule05 = new FuzzyRule(5, if_Error_LN_And_DError_LP, then_du_LN);

  // If error = SN AND derror = LN Then du = SN
  FuzzyRuleAntecedent* if_Error_SN_And_DError_LN = new FuzzyRuleAntecedent();
  if_Error_SN_And_DError_LN->joinWithAND(eSN,deLN);   

  FuzzyRule* fuzzyRule06 = new FuzzyRule(6, if_Error_SN_And_DError_LN, then_du_SN);

  // If error = SN AND derror = SN Then du = ZR
  FuzzyRuleAntecedent* if_Error_SN_And_DError_SN = new FuzzyRuleAntecedent();
  if_Error_SN_And_DError_SN->joinWithAND(eSN,deZR);   

  FuzzyRule* fuzzyRule07 = new FuzzyRule(7, if_Error_SN_And_DError_SN, then_du_ZR);

  // If error = SN AND derror = ZR Then du = ZR
  FuzzyRuleAntecedent* if_Error_SN_And_DError_ZR = new FuzzyRuleAntecedent();
  if_Error_SN_And_DError_ZR->joinWithAND(eSN,deZR);   

  FuzzyRule* fuzzyRule08 = new FuzzyRule(8, if_Error_SN_And_DError_ZR, then_du_ZR);

  // If error = SN AND derror = SP Then du = SN
  FuzzyRuleAntecedent* if_Error_SN_And_DError_SP = new FuzzyRuleAntecedent();
  if_Error_SN_And_DError_SP->joinWithAND(eSN,deSN);   

  FuzzyRule* fuzzyRule09 = new FuzzyRule(9, if_Error_SN_And_DError_SP, then_du_SN);

  // If error = SN AND derror = LP Then du = LN
  FuzzyRuleAntecedent* if_Error_SN_And_DError_LP = new FuzzyRuleAntecedent();
  if_Error_SN_And_DError_LP->joinWithAND(eSN,deLP);   

  FuzzyRule* fuzzyRule10 = new FuzzyRule(10, if_Error_SN_And_DError_LP, then_du_LP);

  // If error = ZR AND derror = LN Then du = SP
  FuzzyRuleAntecedent* if_Error_ZR_And_DError_LN = new FuzzyRuleAntecedent();
  if_Error_ZR_And_DError_LN->joinWithAND(eZR,deLN);   

  FuzzyRule* fuzzyRule11 = new FuzzyRule(11, if_Error_ZR_And_DError_LN, then_du_SP);

  // If error = ZR AND derror = SN Then du = ZR
  FuzzyRuleAntecedent* if_Error_ZR_And_DError_SN = new FuzzyRuleAntecedent();
  if_Error_ZR_And_DError_SN->joinWithAND(eZR,deZR);   

  FuzzyRule* fuzzyRule12 = new FuzzyRule(12, if_Error_ZR_And_DError_SN, then_du_ZR);

  // If error = ZR AND derror = ZR Then du = ZR
  FuzzyRuleAntecedent* if_Error_ZR_And_DError_ZR = new FuzzyRuleAntecedent();
  if_Error_ZR_And_DError_ZR->joinWithAND(eZR,deZR);   

  FuzzyRule* fuzzyRule13 = new FuzzyRule(13, if_Error_ZR_And_DError_ZR, then_du_ZR);

  // If error = ZR AND derror = SP Then du = SN
  FuzzyRuleAntecedent* if_Error_ZR_And_DError_SP = new FuzzyRuleAntecedent();
  if_Error_ZR_And_DError_SP->joinWithAND(eZR,deSP);   

  FuzzyRule* fuzzyRule14 = new FuzzyRule(14, if_Error_ZR_And_DError_SP, then_du_SN);

  // If error = ZR AND derror = LP Then du = SN
  FuzzyRuleAntecedent* if_Error_ZR_And_DError_LP = new FuzzyRuleAntecedent();
  if_Error_ZR_And_DError_LP->joinWithAND(eZR,deLP);   

  FuzzyRule* fuzzyRule15 = new FuzzyRule(15, if_Error_ZR_And_DError_LP, then_du_SN);

  // If error = SP AND derror = LN Then du = SP
  FuzzyRuleAntecedent* if_Error_SP_And_DError_LN = new FuzzyRuleAntecedent();
  if_Error_SP_And_DError_LN->joinWithAND(eSP,deLN);   

  FuzzyRule* fuzzyRule16 = new FuzzyRule(16, if_Error_SP_And_DError_LN, then_du_SP);

  // If error = SP AND derror = SN Then du = SN
  FuzzyRuleAntecedent* if_Error_SP_And_DError_SN = new FuzzyRuleAntecedent();
  if_Error_SP_And_DError_SN->joinWithAND(eSP,deSN);   

  FuzzyRule* fuzzyRule17 = new FuzzyRule(17, if_Error_SP_And_DError_SN, then_du_SN);

  // If error = SP AND derror = ZR Then du = SP
  FuzzyRuleAntecedent* if_Error_SP_And_DError_ZR = new FuzzyRuleAntecedent();
  if_Error_SP_And_DError_ZR->joinWithAND(eSP,deZR);   

  FuzzyRule* fuzzyRule18 = new FuzzyRule(18, if_Error_SP_And_DError_ZR, then_du_SP);

  // If error = SP AND derror = SP Then du = SP
  FuzzyRuleAntecedent* if_Error_SP_And_DError_SP = new FuzzyRuleAntecedent();
  if_Error_SP_And_DError_SP->joinWithAND(eSP,deSP);   

  FuzzyRule* fuzzyRule19 = new FuzzyRule(19, if_Error_SP_And_DError_SP, then_du_SP);

  // If error = SP AND derror = LP Then du = SP
  FuzzyRuleAntecedent* if_Error_SP_And_DError_LP = new FuzzyRuleAntecedent();
  if_Error_SP_And_DError_LP->joinWithAND(eSP,deLP);   

  FuzzyRule* fuzzyRule20 = new FuzzyRule(20, if_Error_SP_And_DError_LP, then_du_SP);

  // If error = LP AND derror = LN Then du = LP
  FuzzyRuleAntecedent* if_Error_LP_And_DError_LN = new FuzzyRuleAntecedent();
  if_Error_LP_And_DError_LN->joinWithAND(eLP,deLN);   

  FuzzyRule* fuzzyRule21 = new FuzzyRule(21, if_Error_LP_And_DError_LN, then_du_LP);

  // If error = LP AND derror = SN Then du = LP
  FuzzyRuleAntecedent* if_Error_LP_And_DError_SN = new FuzzyRuleAntecedent();
  if_Error_LP_And_DError_SN->joinWithAND(eLP,deSN);   

  FuzzyRule* fuzzyRule22 = new FuzzyRule(22, if_Error_LP_And_DError_SN, then_du_LP);

  // If error = LP AND derror = ZR Then du = LP
  FuzzyRuleAntecedent* if_Error_LP_And_DError_ZR = new FuzzyRuleAntecedent();
  if_Error_LP_And_DError_ZR->joinWithAND(eLP,deZR);   

  FuzzyRule* fuzzyRule23 = new FuzzyRule(23, if_Error_LP_And_DError_ZR, then_du_LP);

  // If error = LP AND derror = SP Then du = LP
  FuzzyRuleAntecedent* if_Error_LP_And_DError_SP = new FuzzyRuleAntecedent();
  if_Error_LP_And_DError_SP->joinWithAND(eLP,deSP);   

  FuzzyRule* fuzzyRule24 = new FuzzyRule(24, if_Error_LP_And_DError_SP, then_du_LP);

  // If error = LP AND derror = LP Then du = LP
  FuzzyRuleAntecedent* if_Error_LP_And_DError_LP = new FuzzyRuleAntecedent();
  if_Error_LP_And_DError_LP->joinWithAND(eLP,deLP);   

  FuzzyRule* fuzzyRule25 = new FuzzyRule(25, if_Error_LP_And_DError_LP, then_du_LP);

   fuzzy->addFuzzyRule(fuzzyRule01);
   fuzzy->addFuzzyRule(fuzzyRule02);
   fuzzy->addFuzzyRule(fuzzyRule03);
   fuzzy->addFuzzyRule(fuzzyRule04);
   fuzzy->addFuzzyRule(fuzzyRule05);
   fuzzy->addFuzzyRule(fuzzyRule06);
   fuzzy->addFuzzyRule(fuzzyRule07);
   fuzzy->addFuzzyRule(fuzzyRule08);
   fuzzy->addFuzzyRule(fuzzyRule09);
   fuzzy->addFuzzyRule(fuzzyRule10);
   fuzzy->addFuzzyRule(fuzzyRule11);
   fuzzy->addFuzzyRule(fuzzyRule12);
   fuzzy->addFuzzyRule(fuzzyRule13);
   fuzzy->addFuzzyRule(fuzzyRule14);
   fuzzy->addFuzzyRule(fuzzyRule15);
   fuzzy->addFuzzyRule(fuzzyRule16);
   fuzzy->addFuzzyRule(fuzzyRule17);
   fuzzy->addFuzzyRule(fuzzyRule18);
   fuzzy->addFuzzyRule(fuzzyRule19);
   fuzzy->addFuzzyRule(fuzzyRule20);
   fuzzy->addFuzzyRule(fuzzyRule21);
   fuzzy->addFuzzyRule(fuzzyRule22);
   fuzzy->addFuzzyRule(fuzzyRule23);
   fuzzy->addFuzzyRule(fuzzyRule24);
   fuzzy->addFuzzyRule(fuzzyRule25);
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
          reading.desligarSistema(dutyCylePump, levelCm, sampleTime, sendData, execPid, first);     // Turn off the didatic system       
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
       else if(commandCode == 'F')
      {
          dutyCylePump = 190;
          execFazzy = true;
          
      }
      
  } 
   
  sensorValue = analogRead(SENSOR_PIN);            // Read the pressure sensor
  levelCm = parameter_A * sensorValue - parameter_B;   // Convert the measurement to level in cm
  error_ant = error;
  error = setPoint - levelCm;
  Derror = error - error_ant;

  // Fuzzy para teste **********************************************************
  if(execFazzy){ 
    fuzzy->setInput(1, error);
    fuzzy->setInput(2, Derror);

        fuzzy->fuzzify();

        double saidaFuzzy = fuzzy->defuzzify(1);
        dutyCylePump += fuzzy->defuzzify(1);
        if(dutyCylePump < 0){
          dutyCylePump = 0;
        }
        else if(dutyCylePump > 255){
          dutyCylePump = 255;
        }
        // limitar entre 0 e 100 -> dutyCyclePump
        

        Serial.print("[ Nivel " + String(levelCm) + " /Bomba " + String(dutyCylePump) + " ]");
        Serial.println("[ Erro " + String(error) + " /DErro " + String(Derror) + " /SaidaF " + String(saidaFuzzy) + " ]");

  } 
  // ****************************************************************************
   
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
          //Serial.print("[DERROR: " + String(pidControl.GetDError()) + "]");
      }
        
    previousTime = millis();  // Obtain the previousTime stamp
    }
   
    // Send data to supervisory
    if(sendData) 
    {
      //Serial.print("[" + String(levelCm) + "/" + String(dutyCylePump) + "]");
    }
      
  delay(200);  // Delay execution
}
