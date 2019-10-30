#include <Util.h>
#include <Pid.h>

const int analogInPin = A0;
double outputValue = 0.0;               
int setPoint = 15, sensorValue = 0.0;
int potenciaBomba = 0;
double parametro_A = 0.119; 
double parametro_B = 4.1029;
double sampleTime;
boolean enviarDados = false, execPid = false;
bool first = true;

Pid pid_control = Pid();
Util leitura = Util();

unsigned long currentTime, previousTime;
const int PINO_PWM = 3; 

void setup() { 
    Serial.begin(9600);
    pid_control.SetULimits(255, 0);
    pinMode(PINO_PWM, OUTPUT);
    pid_control.EnableAntiResetWindup();
}

void loop() {
    analogWrite(PINO_PWM, potenciaBomba);
    if (Serial.available() > 0){ // verifica se a serial recebeu dados      
      String getPortaSerial = leitura.leituraString();
      char op = getPortaSerial[0];

        // Liga o sistema
        if(op == 'L'){ 
          enviarDados = true;
        } 
        
        // Desliga o sistema
        else if(op == 'D'){ 
          leitura.desligarSistema(potenciaBomba, outputValue, enviarDados, execPid, first);
        }

        // Seta o valor da potência da bomba
        else if(op == 'B'){ 
          leitura.ligarBomba(execPid, getPortaSerial, potenciaBomba);
        }

        // Seta o valor do setPoint
        else if(op == 'S'){ 
          leitura.setSetPoint(getPortaSerial, setPoint);
        }

        // Seta os valores para A e B
         else if(op == 'A'){ 
           leitura.parametrosAB(getPortaSerial, parametro_A, parametro_B);
        }

        // Seta os valores do PID
        else if(op == 'P'){
          leitura.setParametrosPID(getPortaSerial, pid_control, execPid);
      }    
   } // fim primeiro if 
   
   sensorValue = analogRead(analogInPin);   
   outputValue = parametro_A * sensorValue - parametro_B;   // MESMA COISA DO C# A = 0.127 e B = - 4.1029
   if(outputValue > 30){
      potenciaBomba = (80 + 40 * 1.75); //******* Calculo da potência da bomba  ******
    }
    
   if(execPid){ 
     // leitura.controladorPID(first, outputValue, potenciaBomba, pid_control, setPoint);
   //}
   
    if (!first){
      currentTime = millis();
    }
    else{
      first = false;
      currentTime += 0;
    }
    sampleTime = (double)(currentTime - previousTime) / 1000;
    if(outputValue < 30.00){
      potenciaBomba = pid_control.CalculatePidControlSignal((outputValue), (setPoint), sampleTime); 
    }
    previousTime = millis();
   }
   
   if(enviarDados){ 
      Serial.print("[" + String(outputValue) + "/" + String(potenciaBomba) + "]"); // Envia os dados para o VS 
   }   
   delay(200); 
}
