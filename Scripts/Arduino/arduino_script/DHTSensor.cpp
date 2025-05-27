#include "DHTSensor.h"
#include <Arduino.h>

DHTSensor::DHTSensor(uint8_t dht_pin)
  : pin(dht_pin), dht(dht_pin, DHT11) {}

void DHTSensor::begin() {
  dht.begin();
}

int DHTSensor::readTemperature() {
  return static_cast<int>(dht.readTemperature());  // Cast para int
}

int DHTSensor::readHumidity() {
  return static_cast<int>(dht.readHumidity());     // Cast para int
}
