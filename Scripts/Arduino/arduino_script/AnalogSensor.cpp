#include "AnalogSensor.h"
#include <Arduino.h>

AnalogSensor::AnalogSensor(int analogPin) {
  pin = analogPin;
}

void AnalogSensor::begin() {
  pinMode(pin, INPUT);
}

int AnalogSensor::readValue() {
  return analogRead(pin);
}
