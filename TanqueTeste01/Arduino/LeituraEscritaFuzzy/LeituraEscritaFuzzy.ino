#include <Pid.h>

const int analogInPin = A0;
double kp, ki, kd, outputValue = 0.0;               
int setPoint = 15, sensorValue = 0.0;
float potenciaBomba = 0;
double parametro_A = 0.119; 
double parametro_B = 4.1029;
double sampleTime;
boolean enviarDados = false, execPid = false;
bool first = true;

Pid pid_control = Pid();

unsigned long currentTime, previousTime;
const int PINO_PWM = 3;     // A = 0.127 B = 4.1029  PID = kp.125 ki.0.05 kd.0    // A0.119;4.1029


void setup() { 
    Serial.begin(9600);

    pid_control.SetULimits(255, 0);

    pinMode(PINO_PWM, OUTPUT); 

    pid_control.EnableAntiResetWindup();
}

String leituraString(){
  String dadosSerial = "";
  char caractere;

  while(Serial.available() > 0){
    caractere = Serial.read(); // Lê byte da Serial
    if(caractere != '\n'){
      dadosSerial.concat(caractere); //Concatena os caracteres recebidos da serial
    }
    delay(10);
  }
  return dadosSerial;
}

void desligarSistema(){
  Serial.print("[" + String(outputValue) + "/" + String(potenciaBomba) + "]"); // Envia os dados para o VS 
  potenciaBomba = 0;
  outputValue = 0;
  sensorValue = 0.0;
  kp = ki = kd = 0.0;
  sampleTime = 0.0;
  enviarDados = false;
  execPid = false;
  first = true;
}

String ligarBomba(String getPortaSerial){
  execPid = false;
  String minhaString = getPortaSerial.substring(1);
  potenciaBomba = (80 + minhaString.toFloat()* 1.75); //******* Calculo da potência da bomba  ******
}

String setSetPoint(String getPortaSerial){
  String minhaString = getPortaSerial.substring(1);
  setPoint = minhaString.toInt();
}

String parametrosAB(String getPortaSerial){
  int j = 0;
  String PA[2];
  for(int i = 1; i < getPortaSerial.length(); i++){
     if(getPortaSerial[i] != ';'){
        PA[j] += getPortaSerial[i];
     }  
     else
       j++;
  }
  parametro_A = PA[0].toDouble();
  parametro_B = PA[1].toDouble();
}

String controladorPID(String getPortaSerial){
  int j = 0;
  String pid[3];
  for(int i = 1; i < getPortaSerial.length(); i++){
    if(getPortaSerial[i] != ';')
      pid[j] += getPortaSerial[i];
    else
      j++;
  }
  kp = pid[0].toDouble();
  ki = pid[1].toDouble();
  kd = pid[2].toDouble();
          
  pid_control.SetPidParameters(kp,ki,kd);
  execPid = true;
}

void loop() {
    analogWrite(PINO_PWM, potenciaBomba);
    if (Serial.available() > 0){ // verifica se a serial recebeu dados      
      String getPortaSerial = leituraString();
      char op = getPortaSerial[0];

        // Liga o sistema
        if(op == 'L'){ 
          enviarDados = true;
        }

        // Desliga o sistema
        else if(op == 'D'){ 
          desligarSistema();
        }

        // Seta o valor da potência da bomba
        else if(op == 'B'){ 
          ligarBomba(getPortaSerial);
        }

        // Seta o valor do setPoint
        else if(op == 'S'){ 
          setSetPoint(getPortaSerial);
        }

        // Seta os valores para A e B
         else if(op == 'A'){ 
            parametrosAB(getPortaSerial);
         }

        // Seta os valores do PID
        else if(op == 'P'){
          controladorPID(getPortaSerial);
        }    
   } // fim primeiro if 
   
   sensorValue = analogRead(analogInPin);   
   outputValue = parametro_A * sensorValue - parametro_B;   // MESMA COISA DO C# A = 0.127 e B = - 4.1029
   if(outputValue > 25.00){
      potenciaBomba = (80 + 35 * 1.75); //******* Calculo da potência da bomba  ******
    }
    
   if(execPid){ 
    if (!first)
      currentTime = millis();
    else
    {
      first = false;
      currentTime += 0;
    }
    sampleTime = (double)(currentTime - previousTime) / 1000;
    if(outputValue < 25.00)
      potenciaBomba = pid_control.CalculatePidControlSignal((outputValue), (setPoint), sampleTime); 
    previousTime = millis();
   }
   
   if(enviarDados){ 
      Serial.print("[" + String(outputValue) + "/" + String(potenciaBomba) + "]"); // Envia os dados para o VS 
   }   
   delay(200); 
}
