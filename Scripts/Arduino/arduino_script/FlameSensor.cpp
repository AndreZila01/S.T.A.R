#include "FlameSensor.h"
#include <Arduino.h>

FlameSensor::FlameSensor(int sensor, int led) {
  sensorPin = sensor;
  ledPin = led;
}

void FlameSensor::begin() {
  pinMode(sensorPin, INPUT);
}

int FlameSensor::checkFlame() {
  int flameDetected = digitalRead(sensorPin);
  if (flameDetected == HIGH) {
    return 1;
  } else {
    return 0;
  }
}
