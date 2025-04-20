#ifndef ANALOG_SENSOR_H
#define ANALOG_SENSOR_H

class AnalogSensor {
  private:
    int pin;

  public:
    AnalogSensor(int analogPin);
    void begin();
    int readValue();
};

#endif
