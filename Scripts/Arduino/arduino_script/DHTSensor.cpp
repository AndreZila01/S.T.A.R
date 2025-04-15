#include "DHTSensor.h"
#include <Arduino.h>

DHTSensor::DHTSensor(uint8_t dht_pin)
  : pin(dht_pin), dht(dht_pin, DHT11) {}

void DHTSensor::begin() {
  dht.begin();
}

float DHTSensor::readTemperature() {
  return dht.readTemperature();
}

float DHTSensor::readHumidity() {
  return dht.readHumidity();
}
