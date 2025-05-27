#ifndef FLAME_SENSOR_H
#define FLAME_SENSOR_H

class FlameSensor {
  private:
    int sensorPin;

  public:
    FlameSensor(int sensor);
    void begin();
    char checkFlame();
};

#endif
