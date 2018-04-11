from django.conf.urls import url
from . import views
urlpatterns = [
url(r'^$', views.index, name="index"),
url(r'^add$', views.add_new_travel, name='add'),  
url(r'^new_create$', views.process_new_travel, name='process_add'),  
url(r'^destination/(?P<travel_id>\d+)$', views.show, name='show'), 
url(r'^(?P<travel_id>\d+)/like$', views.add_to_join, name='join'),             
url(r'^(?P<travel_id>\d+)/unlike$', views.remove_from_join, name='unjoin'),       
url(r'^destroy/(?P<travel_id>\d+)$', views.delete, name='delete'), 

]
