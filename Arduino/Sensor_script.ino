//joystick pin definition
#define SW 8
#define VRX A0
#define VRY A1

void setup() {
  Serial.begin(9600); //Serial communiation 9600 works fine
  pinMode(SW, INPUT_PULLUP);
  pinMode(VRX, INPUT);
  pinMode(VRY, INPUT);
}

void loop() {
  float joy_rx = analogRead(VRX); //Read the pin values
  float joy_ry = analogRead(VRY);
  float SW2    = digitalRead(SW);
  joy_rx = map(joy_rx, 1, 1024, 0, 100); //Map the values for 0-100 degree
  joy_ry = map(joy_ry, 1, 1024, 0, 100);

  Serial.print(joy_rx); //Print the values to check in arduino
  Serial.print(",");
  Serial.print(joy_ry);
  Serial.print(",");
  Serial.println(!SW2);
}
