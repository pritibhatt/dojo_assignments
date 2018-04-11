class MathDojo(object):
    def __init__(self):
        self.y0 = 0
        self.y1 = y1
        self.y2 = y2
        self.y3 = y3
    def add1(self,x):
        self.y0 += x.y0
        return self
    def add2(b,c):
        self.y1 = b.y1+c.y1
        return self
    def subtract(d,e):
        self.y2 = d.y2-e.y2
        return self
    def total(self):
        self.y3 = self.y0 + (self.y1) + (self.y2)
        return self.y3
        print self.y3


md1 = MathDojo()
md1.add1(2)
md1.add2(3,4)
md1.subtract(4,3)
self.y3()
