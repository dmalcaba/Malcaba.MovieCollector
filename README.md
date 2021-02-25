# Malcaba.MovieCollector
Web app for storing owned movies

## Running in a container

To create an image

`$ docker build -t malcaba-mdb -f Docker/dockerfile .`

To run the image

`$ docker run -p 5000:80 --name movie-collector malcaba-mdb:latest`

Go to the browser and access the page http://localhost:5000
