// Importar a biblioteca.
#include "DHT.h"

// Definir pinos.
const uint8_t dht11_pin = 5;

// Instanciar objeto de gestao.
DHT dht11(dht11_pin, DHT11);

void setup() {
  Serial.begin(9600);
  dht11.begin();
}

void loop() {
  float temp = dht11.readTemperature();
  float humi  = dht11.readHumidity();
  //printf("Temperatura: %f\n", temp);
  Serial.print("Temperatura: ");
  Serial.println(temp);
  Serial.print("Humidade: ");
  Serial.println(humi);
  Serial.println();
  delay(2000);
}