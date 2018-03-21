word_list = ['hello','world','my','name','is','Anna']
new_list = []
find_letters = str('o')
for letter_o in word_list:
    if letter_o.find(find_letters) != -1:
        new_list.append(letter_o)
print new_list

