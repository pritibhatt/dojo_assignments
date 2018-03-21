# def draw_stars(x_list):
#     stars = '*'
#     for thing in x_list:
#         num = thing
#         print num*stars

# x_list = [4, 6, 1, 3, 5, 7, 25]
# draw_stars(x_list)


def draw_stars(x_list):
    stars = '*'
    
    for thing in x_list:
        if( type(thing) == int):
            print thing*stars
        if ( type(thing) == str):
            count = len(thing)
            print count*thing[:1].lower()

x_list = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
draw_stars(x_list)






[4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
