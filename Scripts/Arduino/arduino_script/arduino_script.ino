#include <WiFi.h>
#include <PubSubClient.h>
#include "UltrasonicSensor.h"
#include "FlameSensor.h"
#include "DHTSensor.h"
#include "AnalogSensor.h"
#include "Buzzer.h"

#include "Motor.h"


Motor motor_direito_frente(15, 2);
bool motor_direito_frente_direction = true;
Motor motor_direito_tras(18, 5);
bool motor_direito_tras_direction = true;

Motor motor_esquerda_frente(27, 14);
bool motor_esquerdo_frente_direction = true;
Motor motor_esquerda_tras(13, 12);
bool motor_esquerdo_tras_direction = true;

// // //mudar os pinos
// Buzzer buzzer(9); // Buzzer no pino 9
  AnalogSensor soundSensor(34);
  DHTSensor dhtSensor(32); 
  FlameSensor flame(35);  
  UltrasonicSensor ultrasonicsensor(21, 19);


#include <WiFi.h>
#include <PubSubClient.h>

// Update these with values suitable for your network.

const char* ssid = "Visitors";
const char* password = "";
const char* mqtt_server = "10.36.246.171";

WiFiClient espClient;
PubSubClient client(espClient);
unsigned long lastMsg = 0;
#define MSG_BUFFER_SIZE	(50)
char msg[MSG_BUFFER_SIZE];
int value = 0;

void setup_wifi() {

  delay(10);
  // We start by connecting to a WiFi network
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  randomSeed(micros());

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");

  String message = "";
  for (int i = 0; i < length; i++) {
    message += (char)payload[i];
  }
  Serial.println(message);

  if (message == "W") {
    frente();
  } else if (message == "S") {
    tras();
  } else if (message == "A") {
    virar_esquerda();
  } else if (message == "D") {
    virar_direito();
  }
  else if (message == "WAIT"){
    stop();
  }
}

void reconnect() {
  // Loop until we're reconnected
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    // Create a random client ID
    String clientId = "ESP8266Client-";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    if (client.connect(clientId.c_str())) {
      Serial.println("connected");
      // Once connected, publish an announcement...
      client.publish("/test/", "GreenLight");
      delay(5000);
      // ... and resubscribe
      client.subscribe("/test/");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}



void setup() {
 // pinMode(BUILTIN_LED, OUTPUT);     // Initialize the BUILTIN_LED pin as an output
  Serial.begin(115200);
  setup_wifi();
  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);
  
  //sensores
  ultrasonicsensor.begin();
  flame.begin();
  dhtSensor.begin();
  soundSensor.begin();
  // buzzer.begin();

  //motores
  motor_direito_frente.setup();
  motor_direito_tras.setup();

  motor_esquerda_tras.setup();
  motor_esquerda_frente.setup();
}

void stop(){
  motor_direito_frente.stop();
  motor_direito_tras.stop();

  motor_esquerda_tras.stop();
  motor_esquerda_frente.stop();
}
void virar_esquerda(){
 motor_direito_frente.forward();
  motor_direito_tras.forward();

  motor_esquerda_tras.backward();
  motor_esquerda_frente.backward();
  delay(1000);
  stop();
}

void virar_direito(){
 motor_direito_frente.backward();
  motor_direito_tras.backward();

  motor_esquerda_tras.forward();
  motor_esquerda_frente.forward();
  delay(1000);
  stop();
}

void frente(){
 motor_direito_frente.forward();
  motor_direito_tras.forward();

  motor_esquerda_tras.forward();
  motor_esquerda_frente.forward();
  delay(1000);
  stop();
}

void tras(){
   motor_direito_frente.backward();
  motor_direito_tras.backward();

  motor_esquerda_tras.backward();
  motor_esquerda_frente.backward();
  delay(1000);
  stop();
}

void loop() {

  if (!client.connected()) {
    reconnect();
  }
  client.loop();

  unsigned long now = millis();
  if (now - lastMsg > 2000) {
    lastMsg = now;
    ++value;
     int som = soundSensor.readValue();  // Faz a leitura do sensor
     int distancia = ultrasonicsensor.getDistance();  // Faz a leitura do sensor
     char fogo = flame.checkFlame();
     int temperatura =dhtSensor.readTemperature();
     int humidade = dhtSensor.readHumidity();

      //mandar dados de todos os sensores:
          snprintf(msg, MSG_BUFFER_SIZE, "D_%.d S_%.d T_%.d H_%.d F_%c", distancia,som, temperatura, humidade, fogo);
          Serial.print("Publicando: ");
          Serial.println(msg);
          client.publish("/test/", msg);
        }

}