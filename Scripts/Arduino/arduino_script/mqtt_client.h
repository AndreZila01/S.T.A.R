#ifndef MQTT_CLIENT_H
#define MQTT_CLIENT_H

#include <WiFi.h>
#include <PubSubClient.h>

// Configurações Wi-Fi e Broker
extern const char* ssid;
extern const char* password;
extern const char* mqtt_server;
extern const int mqtt_port;

// Tópicos
extern const char* topicoPublicar;
extern const char* topicoReceber;

// Objetos do MQTT
extern WiFiClient espClient;
extern PubSubClient client;

// Declaração das funções
void setupWifi();
void mqttCallback(char* topic, byte* payload, unsigned int length);
void mqttReconnect();
void mqttLoop();
void mqttPublish(const char* payload);

#endif
