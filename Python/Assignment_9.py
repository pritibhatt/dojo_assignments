import random
def score_grade():
    
    for i in range(1,10):
        score = random.randint(60,100)
        if score <=69:
           print("Score: {}; Your grade is D".format(score))
        elif score<=79:
           print("Score: {}; Your grade is C".format(score))
        elif score<=89:
           print("Score: {}; Your grade is B".format(score))
        elif score<=100:
           print("Score: {}; Your grade is A".format(score))
        else:
            print "End of the program. Bye!"


score_grade()

