# Worksheet Two

## Exploring the OO principles of SOLID

We are going to explore the OO principles as proposed by SOLID.  
To do this we are going to use the example of a "Sensor System" (Fire, etc.).

### Use cases

- The system should support any number of sensors
- The system should support different types of sensors
- The system should poll all sensors to see if any are triggered (an alarm is raised)
- The system should also check for the battery percentage of the sensors (different types of sensors draines faster)

### The starting point

You are already provided with some starting code (in this repository) and the initial design (see below).

**Interfaces**

- `ISensor`. This interface defines methods for all sensors to implement.
	- `IsTriggered()`: returns true/false for whether the sensor is triggered or not. Different sensors has different rules. See exercises.
	- `GetLocation()`: returns a description of the location of the sensor such as "Lobby 1st floor" or "In the auditorium".
	- `GetSensortype()`: returns a textual description of the sensor type such as "Fire sensor" or "Smoke sensor".
	- `GetBatteryPercentage()`: Returns a number between 0-100 where 0 is empty and 100 is fully charged.

**Classes**

- `FireSensor`. This sensor implements the `ISensor` interface but has no logic yet.
- `SmokeSensor`. This sensor implements the `ISensor` interface but has no logic yet.
- `ControlUnit`. This is the starting point for the alarm system. It's the main entry point for polling sensors and controlling the system.

### Exercises

Take your time with these exercises. It is important that you explore the various implications of adopting the SOLID principles for a problem.

1. Implement the `FireSensor` methods.
	- 5% of the time it is called, it raises an alarm
	- Drains 10% battery between each poll
2. Implement the `SmokeSensor` methods.
	- 10% of the time it is called, it raises an alarm
	- Drains 20% battery between each poll
3. Investigate the `ControlUnit.PollSensors()` method. 
	What are its current responsibilities? (No need to do anything, just make sure you find all responsibilities before you continue).  
	Ask an instructor if you're not sure.
4. Instead of "newing up" sensors when we call `PollSensors()`, we want to pass a collection of sensors in to the control unit. 
	However, we don't want to pass the sensors in when we are polling. 
	When we poll sensors, the control unit should be configured with all of the required sensors. (Hint: *Dependency Inversion Principle*).
5. Investigate the `PollSensors` method again, same as #4. What are the responsibilities now?
6. A new use case! This is no longer an alarm system for only detecting hazards; 
	it should now also include security such as *motion* and *heat* sensors. 
	However, these sensors don't run on battery power so one of the `ISensor` interface methods is now redundant for a whole set of sensors.  
	Which method is this and what SOLID principle does this break?
7. Following the principle you determined in #6, solve the problem by following the presentation slide hints on this principle.   
	Ask an instructor if you're not sure.
8. Create a new `MotionSensor` sensor, which inherits from the `ISensor` interface. 
	These new security sensors should be polled separately from the hazard sensors. 
	This requires a means to distinguish between the two sensor categories. 
	Make changes to the `ISensor` interface to accommodate this change in the requirements.
9. Security sensors should only be polled at night between `22:00–06:00`. 
	This is the same for all security sensors. 
	Since we don't want to mix security sensor and hazard sensor behaviour in the same polling mechanism, we decide to make use of inheritance and create a new `SecurityControlUnit` 
which extends the existing `ControlUnit`. 
	Our intention is to pass in the security sensors through the (base) parent constructor and then implement a rule that checks the current time and if it's between `22:00–06:00`, we poll the sensors using the existing method, which already does the heavy lifting for us.
10. Which SOLID principle are we _maintaining/not breaking_ by doing this?

Have fun!
