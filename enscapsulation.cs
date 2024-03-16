class Car:
    def __init__(self, speed):
        self._speed = speed

    def accelerate(self, increment):
        self._speed += increment

    def get_speed(self):
        return self._speed

my_car = Car(speed=0)
my_car.accelerate(10)
print("Current speed:", my_car.get_speed())  # Output: Current speed: 10
