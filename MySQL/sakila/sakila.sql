SELECT city.city_id, city.city, customer.first_name, customer.last_name, customer.email, address.address
FROM  customer
JOIN address ON customer.address_id = address.address_id
JOIN city ON address.city_id = city.city_id
WHERE city.city_id = 312;

SELECT film.title, film.description, film.release_year, film.rating, film.special_features,  category.name AS genre
FROM film
LEFT JOIN film_category ON film.film_id = film_category.film_id
LEFT JOIN category ON film_category.category_id = category.category_id
WHERE category.name = 'comedy';

SELECT actor.actor_id, actor.first_name, actor.last_name, film.title, film.description, film.release_year
FROM actor
JOIN film_actor ON actor.actor_id = film_actor.actor_id
JOIN film ON film_actor.film_id = film.film_id
WHERE actor.actor_id = 5;

SELECT customer.store_id, city.city_id, city.city, customer.first_name, customer.last_name, customer.email, address.address
FROM  customer
JOIN address ON customer.address_id = address.address_id
JOIN city ON address.city_id = city.city_id
WHERE customer.store_id = 1 AND city.city_id IN (1, 42, 312, 459);



