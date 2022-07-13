# Arduino Csharp - Implementation of a Cash Register Security System
Make a program that simulates a security system of a cash register, where you must also be able to capture images of the user who wants to enter, there must also be a motion sensor that connects by means of an Arduino, the application must allow you to enter a password to the user where you can disable the entire security system.

# SECURITY
You must have a file where three users (one administrator and two cashiers) are already registered.The administrator will have access to the entire security system and register, cashiers will only be able to access the register. If a person other than the cashiers or administrator wants to enter the alarm system, they must start immediately and capture images of the person infiltrated.

# FUNCTIONALITY
- The cash register must allow entry of an opening cash balance.
- Record the value of each item you want to buy or remove items from the purchase.
- Allow to calculate the total value of the purchase, enter the value with which the user pays, and show on the screen what the change (returned).
- Request cash withdrawal when an amount of $200,000 is exceeded, leaving a base value of $30,000 (the value withdrawn is counted as an expense).
- Allow to have a balance of the total income, expenses (value withdrawn when it exceeds the limit) and total money available in the box
- At the time of entering the values, they must be entered through the on-screen keyboard as well as the passwords.
- The security must allow entering a password to disable the entire system.
- The motion sensor must be at a point where only the 3 users can enter.
- The security system must be able to take a burst of images when an unregistered user enters.
- The security system will have to capture an image every time the password is entered wrong.
- The administrator can view the captured images as well as view the history of purchases made
