class Animal(object):
    def __init__(self,name,health):
        self.name = name
        self.health = health
    def walk(self):
        self.health -=1
        print "walking"
    def run(self):  
        self.health -=5 
        if self.health<5:
            self.health = 0
        print "running"
    def display_health(self):
        print self.health
class Dog(Animal):
    def __init__(self,name,health):
        self.health = 150
    def pet(self):
        self.health += 5
        print "petting"
class Dragon(Animal):
    def __init__(self,name,health):
        self.health = 170
    def fly(self):
        self.health -= 10
        print "flying"
    def display_health(self):
        print "I am a Dragon", self.health 
        
animal1 = Animal("tommy", 15)
animal1.walk()
animal1.walk()
animal1.walk()
animal1.run()
animal1.run()
animal1.display_health()
print'____________________________'
dog1 = Dog("angel",0)
dog1.walk()
dog1.walk()
dog1.walk()
dog1.run()
dog1.run()
dog1.pet() 
dog1.display_health()
print'______________________________'      
dragon1 = Dragon("sky",0)
dragon1.fly()
dragon1.display_health()
       


