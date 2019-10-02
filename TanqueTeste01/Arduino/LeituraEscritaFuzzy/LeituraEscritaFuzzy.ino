#include <Pid.h>

const int analogInPin = A0;
double outputValue = 0;               
int setPoint = 15, sensorValue = 0;
float potenciaBomba = 0;
double erro, kp, ki, kd;
boolean enviarDados = false, execPid = false;

Pid pid_control = Pid();

unsigned long sampleTime, initialTime, finalTime;

const int PINO_PWM = 3;

void setup() { 
    Serial.begin(9600);

    pid_control.SetULimits(255, 0);

    pinMode(PINO_PWM, OUTPUT); 
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

void loop() {
    initialTime = millis();
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
          Serial.print("[" + String(sensorValue) + "/" + String(potenciaBomba) + "]");
          enviarDados = false;
          execPid = false;
          potenciaBomba = 0;
        }
          
        else if(op == 'B'){ 
          String minhaString = getPortaSerial.substring(1);
          potenciaBomba = (80 + minhaString.toFloat()* 1.75); //******* Calculo da potência da bomba  ******
          
        }

        if(op == 'S'){ 
          String minhaString = getPortaSerial.substring(1);
            setPoint = minhaString.toInt();
        }
        
        else if(op == 'P'){
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
   } // fim primeiro if 
      
   if(execPid){
    finalTime = millis();
    sampleTime = ((finalTime - initialTime) / 1000);
    potenciaBomba = pid_control.CalculatePidControlSignal((outputValue), (setPoint), sampleTime);
    erro = pid_control.GetError();
    // Serial.println("potenciaBomba = " + String(potenciaBomba));
     Serial.println("[" + String(setPoint) + "/" + String(outputValue) + "/" + String(erro) + "/" + String(potenciaBomba) + "]"); // Envia os dados para o VS 
   }
   
   if(enviarDados){
      sensorValue = analogRead(analogInPin);
      //outputValue = map(sensorValue, 34, 1023, 0, 100);
      outputValue = 0.127*sensorValue - 4.1029;   // MESMA COISA DO C# A = 0.127 e B = - 4.1029
     // Serial.print("[" + String(outputValue) + "/" + String(potenciaBomba/34) + "]"); // Envia os dados para o VS 
   }   
   delay(200); 
}
