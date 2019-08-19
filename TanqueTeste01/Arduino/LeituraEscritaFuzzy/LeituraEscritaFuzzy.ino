#include <AFMotor.h>

AF_DCMotor motor(1); //Seleciona o motor 1

const int analogInPin = A7;
int sensorValue = 0;
int getPortaSerial = 0;
float potenciaBomba = 0;
boolean enviarDados = false;

void setup() { 
    Serial.begin(9600);
    motor.setSpeed(potenciaBomba); //Define a velocidade maxima
    motor.run(FORWARD); //Gira o motor no sentido horario
}

void loop() {
    motor.setSpeed(potenciaBomba);
    if (Serial.available()){ // verifica se a serial recebeu dados      
      getPortaSerial = Serial.parseFloat();      
      Serial.read();

      if(getPortaSerial == 300){ // Se o valor recebido do VS for igual a 300 o sistema é iniciado
        enviarDados = true;
      }
    
      else if(getPortaSerial == 200){ // Se o valor recebido do VS for igual a 200 o sistema é desligado
        Serial.print("[" + String(sensorValue) + "/" + String(potenciaBomba) + "]");
        enviarDados = false;
        potenciaBomba = 0;
      }
    
      else if(getPortaSerial > 0 && getPortaSerial <= 100){ 
        potenciaBomba = (80 + float(getPortaSerial * 1.75)); //******* Calculo da potência da bomba  ******
      }
      else {
        potenciaBomba = 0;
      }
   }
   
   if(enviarDados){
      sensorValue = analogRead(analogInPin);
      Serial.print("[" + String(sensorValue) + "/" + String(potenciaBomba) + "]"); // Envia os dados para o VS 
   }   
   delay(200); 
}
