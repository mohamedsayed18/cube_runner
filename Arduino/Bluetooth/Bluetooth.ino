//Connections
//bluetooth -----> Arduino
//       TX -----> Pin 0 RX
//  Rx      -----> Pin1 TX
// VCC     ------> 5V
// GND     ------> GND

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println("world");
}
