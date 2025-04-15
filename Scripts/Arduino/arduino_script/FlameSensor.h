#ifndef FLAME_SENSOR_H
#define FLAME_SENSOR_H

class FlameSensor {
  private:
    int sensorPin;
    int ledPin;

  public:
    FlameSensor(int sensor, int led);
    void begin();
    void checkFlame();
};

#endif
