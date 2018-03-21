import random

def cointoss():
    total_head = 0
    total_tail = 0
    attempt_total =0

    for i in range(1,5000):
        count = random.randint(0,1)
        if count == 1:
            total_head += 1
            attempt_total += 1
            print ("Attempt #{}; Its a head(s)!....Got {} head(s) so far and {} tail(s) so far".format(attempt_total, total_head, total_tail))
        elif count == 0:
           total_tail += 1
           attempt_total += 1
           print ("Attempt #{}; Its a tail(s)!....Got {} head(s) so far and {} tail(s) so far".format(attempt_total, total_tail, total_tail))
       

cointoss()
