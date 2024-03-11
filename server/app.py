from flask import Flask, request
import json
import os

port = os.environ.get("PORT", 8080)

class settings:
    status = True
    words = ["tiktok", "roblox"]

app = Flask(__name__)

@app.route('/')
def get():
    return str(settings.status)

@app.route('/on')
def on():
    settings.status = True
    return "ok"

@app.route('/off')
def off():
    settings.status = False
    return "ok"

@app.route('/add', methods=['GET'])
def add():
    settings.words.append(request.args.get('word'))
    return "ok"

@app.route('/check', methods=['GET'])
def check():
    if request.args.get('word') in settings.words and settings.status == True:
        return "True"
    return "False"

@app.route('/all', methods=['GET'])
def all():
    return json.dumps(settings.words)

@app.route('/del', methods=['GET'])
def delt():
    settings.words.remove(request.args.get('word'))
    return "ok"

if __name__ == '__main__':
    app.run(host="0.0.0.0", port=int(port))