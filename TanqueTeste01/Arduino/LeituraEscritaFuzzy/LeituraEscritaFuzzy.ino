#include <AFMotor.h>

AF_DCMotor motor(1); //Seleciona o motor 1

const int analogInPin = A7;
int sensorValue = 0;
int potenciaMotor = 0;
float potencia = 0;
boolean ligaDesliga = false;

void setup() { 
    Serial.begin(9600);
    motor.setSpeed(potenciaMotor); //Define a velocidade maxima
    motor.run(FORWARD); //Gira o motor sentido horario
}

void loop() {
    motor.setSpeed(potencia);   
    if (Serial.available()){ // verifica se a serial recebeu dados
    potenciaMotor = Serial.parseFloat();
    Serial.read();

    if(potenciaMotor == 300){ // Se o valor recebido do VS for igual a 300 o sistema é iniciado
      ligaDesliga = true;
    }
    if(potenciaMotor == 200){ // Se o valor recebido do VS for igual a 200 o sistema é desligado
      ligaDesliga = false;
      potencia = 0;
      Serial.print("[" + String(sensorValue) + "/" + String(potencia) + "]");
    }
    
    if(potenciaMotor >= 0 && potenciaMotor <= 100){ 
      potencia = (80 + float(potenciaMotor * 1.75)); //******* Relação nível sensor ******
    }
   }
   if(ligaDesliga){
    sensorValue = analogRead(analogInPin); 
    Serial.print("[" + String(sensorValue) + "/" + String(potencia) + "]"); // Envia os dados para o VS 
   }
   delay(200);
   
}
