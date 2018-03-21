SELECT countries.name,  languages.language, languages.percentage
FROM countries
LEFT JOIN languages ON countries.id = languages.country_id
WHERE languages.language = 'Slovene'
ORDER BY languages.percentage DESC;

SELECT countries.name, COUNT(cities.name)
FROM countries
LEFT JOIN cities ON countries.id = cities.country_id
GROUP BY countries.id
ORDER BY cities.name DESC;

SELECT countries.name, cities.name, cities.population
FROM countries
LEFT JOIN cities ON countries.id = cities.country_id
WHERE countries.name = 'mexico' AND cities.population >500000
ORDER BY cities.population DESC;

SELECT name, surface_area, population
FROM countries
WHERE surface_area < 501 AND population > 100000;

SELECT name, government_form, capital, life_expectancy
FROM countries
WHERE government_form = 'constitutional monarchy' AND capital > 200 AND life_expectancy > 75;

SELECT countries.name, cities.name, cities.district, cities.population
FROM countries
LEFT JOIN cities ON countries.id = cities.country_id
WHERE countries.name = 'argentina' AND cities.district = 'buenos aires' AND cities.population > 500000;

SELECT region, COUNT(name)
FROM countries
GROUP BY region
ORDER BY COUNT(name) DESC;
