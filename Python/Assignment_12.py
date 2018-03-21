# def personal_info()
myinfo = [
{"name" : "Priti", "age" : "40", "Country of Birth" : "India", "favoriteLanguage" : "Spanish"},
{"name" : "Vick", "age" : "38", "Country of Birth" : "India", "favoriteLanguage" : "English"},

]

for thing in myinfo:
    for key,value in thing.iteritems():
            print ("My {} is {}".format(key,value))
