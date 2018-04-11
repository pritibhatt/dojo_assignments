class Bike(object):
    def __init__(self,price,max_speed):
        self.miles = 0
        self.price = price
        self.max_speed = max_speed

    def display_info(self):
        print "Bike Price:", str(self.price)
        print "Max Speed", str(self.max_speed), "mph"
        print "Total Miles", str(self.miles), "miles"

    def ride(self):
        print "Riding"
        self.miles += 10
        
    def reverse(self):
        print "Reversing"
        if self.miles >=5:
            self.miles -=5


bike1 = Bike('$100', '50')
bike1.ride()
bike1.ride()
bike1.ride()
bike1.display_info()
print'__________________________________'
bike2 = Bike("$200", "100")
bike2.ride()
bike2.ride()
bike2.reverse()
bike2.reverse()
bike2.display_info()
print'___________________________________'
bike3 = Bike("$300","150")
bike3.reverse()
bike3.reverse()
bike3.reverse()
bike3.display_info()

