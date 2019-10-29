#ifndef _UTIL_H_
#define _UTIL_H_

#include <string.h>
#include <Pid.h>
#include <Arduino.h>

class Util{
	
	public: 
		String leituraString();
		void desligarSistema(float &potenciaBomba, double &outputValue, double &sampleTime, boolean &enviarDados, boolean &execPid, boolean &first);
		void ligarBomba(boolean &execPid, String getPortaSerial, float &potenciaBomba);
		void setSetPoint(String getPortaSerial, int &setPoint);
		void parametrosAB(String getPortaSerial, double &parametro_A, double &parametro_B);
		void controladorPID(String getPortaSerial, Pid &pid_control, boolean &execPid);
	private:

};

#endif