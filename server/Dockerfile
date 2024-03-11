FROM ubuntu:latest
EXPOSE 8080
RUN apt-get update -qy
RUN apt-get install -qy python3 python3-pip
COPY . /app
WORKDIR /app
RUN pip install -r requirements.txt
CMD ["python3","app.py"]
