import requests

r=requests.get("https://raw.githubusercontent.com/carteras/IT-CBR/main/learning_briefs/python/files/practice.challenge.download.me.txt")
print(r.text)