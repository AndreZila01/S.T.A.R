#include "Buzzer.h"
#include <Arduino.h>

Buzzer::Buzzer(int buzzerPin) {
  pin = buzzerPin;
}

void Buzzer::begin() {
  pinMode(pin, OUTPUT);
}

void Buzzer::playTone(int frequency, int duration) {
  tone(pin, frequency, duration);
}

void Buzzer::stopTone() {
  noTone(pin);
}
