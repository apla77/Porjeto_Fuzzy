#include <Util.h>
#include <string.h>
#include <Pid.h>
#include <Arduino.h>

String Util::leituraString(){
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

void Util::desligarSistema(float &potenciaBomba, double &outputValue, double &sampleTime, boolean &enviarDados, boolean &execPid, boolean &first){
  
  potenciaBomba = 0;
  outputValue = 0;
  sampleTime = 0;
  enviarDados = false;
  execPid = false;
  first = false;
  Serial.print("[" + String(outputValue) + "/" + String(potenciaBomba) + "]"); // Envia os dados para o VS 
}


void Util::ligarBomba(boolean &execPid, String getPortaSerial, float &potenciaBomba){
  execPid = false;
  String minhaString = getPortaSerial.substring(1);
  potenciaBomba = (80 + minhaString.toFloat()* 1.75); //******* Calculo da potência da bomba  ******
}

void Util::setSetPoint(String getPortaSerial, int &setPoint){
  String minhaString = getPortaSerial.substring(1);
  setPoint = minhaString.toInt();
}

void Util::parametrosAB(String getPortaSerial, double &parametro_A, double &parametro_B){
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

void Util::controladorPID(String getPortaSerial, Pid &pid_control, boolean &execPid){
  int j = 0;
  double kp, ki, kd;
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


