class Product(object):
    def __init__(self,price,item_name,weight,brand,Status):
        self.price = price
        self.item_name = item_name
        self.weight = weight
        self.brand = brand
        self.status = "for sale"
        self.tax = 0.15
         
        
    def price_product(self):
        self.price = self.price + self.price*self.tax
        return self
    def sell(self):
        if self.status == "sold":
            self.status = "sold"
        elif self.status == "defective":
            self.status = "defective"
            self.price = 0.00
        elif self.status == "in box_like new":
            self.status = "for sale"
            self.status = self.status - (self.price*.20)
            
        
    def display_info(self):
        print ("${}".format(self.price))
        print self.item_name
        print self.weight,"lbs"
        print self.brand
        print self.status

product1 = Product(10,"Book","5","Bookworm","defective" )            
product1.price_product()
product1.sell()
product1.display_info()
