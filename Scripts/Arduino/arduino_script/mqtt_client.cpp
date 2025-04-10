#include "mqtt_client.h"

const char* ssid = "Samsung_Fixe";
const char* password = "testenull";
const char* mqtt_server = "192.168.165.199";
const int mqtt_port = 1883;

const char* topicoPublicar = "esp32/teste";
const char* topicoReceber = "esp32/comando";

WiFiClient espClient;
PubSubClient client(espClient);

void setupWifi() {
  delay(10);
  Serial.print("Conectando ao Wi-Fi: ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("\nWi-Fi conectado!");
  Serial.print("IP: ");
  Serial.println(WiFi.localIP());
}

void mqttCallback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Mensagem recebida em [");
  Serial.print(topic);
  Serial.print("]: ");

  String msg;
  for (int i = 0; i < length; i++) {
    msg += (char)payload[i];
  }
  Serial.println(msg);

  // Aqui você pode colocar lógica de resposta ao comando
}

void mqttReconnect() {
  while (!client.connected()) {
    Serial.print("Conectando ao MQTT...");
    if (client.connect("ESP32Client")) {
      Serial.println("conectado!");
      client.subscribe(topicoReceber);
    } else {
      Serial.print("falhou, rc=");
      Serial.print(client.state());
      Serial.println(" tentando em 5s");
      delay(5000);
    }
  }
}

void mqttLoop() {
  if (!client.connected()) {
    mqttReconnect();
  }
  client.loop();
}

void mqttPublish(const char* payload) {
  client.publish(topicoPublicar, payload);
  Serial.print("Publicado: ");
  Serial.println(payload);
}
