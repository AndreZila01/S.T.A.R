/**
 * Motor.h
 * Controls the motor.
 *
 * @author Nathan Campos <nathan@innoveworkshop.com>
 */

#pragma once

class Motor {
private:
  uint8_t pinA;
  uint8_t pinB;

public:
  Motor(uint8_t pinA, uint8_t pinB) {
    this->pinA = pinA;
    this->pinB = pinB;
  };

  void setup() {
    pinMode(this->pinA, OUTPUT);
    pinMode(this->pinB, OUTPUT);
  }

  void forward() {
    Serial.println("Motor Forward");
    digitalWrite(this->pinA, HIGH);
    digitalWrite(this->pinB, LOW);
  };

  void backward() {
    Serial.println("Motor Backward");
    digitalWrite(this->pinA, LOW);
    digitalWrite(this->pinB, HIGH);
  };

 

  void speedControl(bool forward, uint8_t speed) {
    if (forward) {
      digitalWrite(this->pinB, LOW);
      analogWrite(this->pinA, speed);
    } else {
      digitalWrite(this->pinA, LOW);
      analogWrite(this->pinB, speed);
    }
  }

  void stop() {
    Serial.println("Motor Stop");
    digitalWrite(this->pinA, LOW);
    digitalWrite(this->pinB, LOW);
  };
};
