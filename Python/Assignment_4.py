newstr = ""
numbersum = 0
a_list = ['magical unicorns ',19,'hello ',98.98,'world']
for thing in a_list:
    if isinstance(thing, str):
      newstr = newstr + thing
    elif isinstance(thing, int):
        numbersum1 =float(thing) 
    elif isinstance(thing, float):
        numbersum2 = thing
        numbersum = numbersum1 + numbersum2

print "The list you entered is of mixed type"            
print "String:", newstr      
print "Sum:", numbersum