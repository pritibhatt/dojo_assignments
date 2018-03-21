class Car(object):
    def __init__(self,price,speed,fuel,mileage):
        self.price = price
        if (self.price>10,000):
            self.tax = "0.15"
        else:
            self.tax = "0.12"
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage 
    def display_all(self):
        print "Price:", str(self.price)
        print "Speed:", str(self.speed),"mph"
        print "Fuel:", str(self.fuel)
        print "Mileage:", str(self.mileage),"mph"
        print "Tax:", str(self.tax)

car1 = Car("1000","40","Full", "15")
car1.display_all()
car2 = Car("10000","80","Not Full", "15")
car2.display_all()
car3 = Car("15000","40","Not Full", "25")
car3.display_all()
car4 = Car("1000","40","Full", "20")
car4.display_all()
car5 = Car("20000","40","Not Full", "18")
car5.display_all()
car6 = Car("25000","40","Full", "17")
car6.display_all()
