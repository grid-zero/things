import numpy as np
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split



time_studied = np.array([20,50,13,27,30,67,40,28,49,28]).reshape(-1,1)
scores = np.array([74,28,38,97,52,15,52,34,24,87]).reshape(-1,1)

time_train, time_test, score_train, score_test = train_test_split(time_studied, scores, test_size=0.2)

model = LinearRegression()
model.fit(time_train, score_train)

print(model.score(time_test, score_test))

plt.scatter(time_train, score_train)
plt.plot(np.linspace(0,70,100).reshape(-1,1), model.predict(np.linspace(0,70,100).reshape(-1,1)))
plt.show()