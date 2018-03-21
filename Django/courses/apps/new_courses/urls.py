from django.conf.urls import url
from . import views
urlpatterns = [
url(r'^$', views.index, name="index"),
url(r'^new_create$', views.add_new_course, name='add'),  
url(r'^(?P<course_id>\d+)$', views.show, name='show'),       
url(r'^(?P<course_id>\d+)/like$', views.add_to_favorites, name='like'),       
url(r'^(?P<course_id>\d+)/unlike$', views.remove_from_favorites, name='unlike'),       
url(r'^destroy/(?P<course_id>\d+)$', views.delete, name='delete'), 
# url(r'^delete_course/(?P<course_id>\d+)$', views.delete_course, name='delete_course'),   

]