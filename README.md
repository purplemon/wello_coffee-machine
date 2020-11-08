# VCSharpBucks - Virtual Coffee Machine (.NET Console application)

This repo contains all the source files to build and run a virtual coffee machine.

Simply [download](slides-students-C04.pdf) the executable to get started, or optionally download the sourcecode and build solution yourself.

## PLATFORM DETAILS

This .NET Console project is a console application written in C#. It is controlled through console interactions.

It does not depend on any external libraries .

It does not require a persistent datastore.

## FUNCTIONALITY

- The virtual coffee machine can perform one order. When the order is complete, the coffee machine shuts off (the program ends). To create a second order the executable must be started again.

- The virtual coffee machine can only make coffee.

- The user has a choice from 3 sizes: small ($2.95), medium ($3.25), large ($3.95). Prices were not specified, and we chose them to be competitive with a close competitor of CSharpBucks, StarBucks.

- The user can order more than one coffee.

- The user can optionally add up to 3 sugars or 3 creams in each coffee.

- The coffee machine will prompt for payment and inform the user if inadequate payment is received.

- The user can pay using standard cash increments.