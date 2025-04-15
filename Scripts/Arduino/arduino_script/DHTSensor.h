#ifndef DHT_SENSOR_H
#define DHT_SENSOR_H

#include <DHT.h>

class DHTSensor {
  private:
    uint8_t pin;
    DHT dht;

  public:
    DHTSensor(uint8_t dht_pin);
    void begin();
    float readTemperature();
    float readHumidity();
};

#endif
