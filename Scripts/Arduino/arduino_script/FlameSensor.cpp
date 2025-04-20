#include "FlameSensor.h"
#include <Arduino.h>

FlameSensor::FlameSensor(int sensor, int led) {
  sensorPin = sensor;
  ledPin = led;
}

void FlameSensor::begin() {
  pinMode(sensorPin, INPUT);
  pinMode(ledPin, OUTPUT);
}

void FlameSensor::checkFlame() {
  int flameDetected = digitalRead(sensorPin);
  if (flameDetected == HIGH) {
    Serial.println("FIRE DETECTED!");
    digitalWrite(ledPin, HIGH);
  } else {
    Serial.println("No Fire");
    digitalWrite(ledPin, LOW);
  }
}
