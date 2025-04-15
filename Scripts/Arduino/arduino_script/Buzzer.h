#ifndef BUZZER_H
#define BUZZER_H

class Buzzer {
  private:
    int pin;

  public:
    Buzzer(int buzzerPin);
    void begin();
    void playTone(int frequency, int duration);
    void stopTone();
};

#endif
