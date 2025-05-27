#include "FlameSensor.h"
#include <Arduino.h>

FlameSensor::FlameSensor(int sensor) {
  sensorPin = sensor;
}

void FlameSensor::begin() {
  pinMode(sensorPin, INPUT);
}

char FlameSensor::checkFlame() {
  int flameDetected = digitalRead(sensorPin);
  if (flameDetected == HIGH) {
    return 'T';
  } else {
    return 'F';
  }
}
