import numpy as np
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression



time_studied = np.array([20,50,13,27,30,67,40,28,49,28]).reshape(-1,1)
scores = np.array([74,28,38,47,52,15,52,34,24,37]).reshape(-1,1)

time_train, time_test, score_train, score_test = train_test_split(time_studied, scores, test_size=0.2)

model = LinearRegression()
model.fit(time_studied,scores)

print(model.predict(np.array([56]).reshape(-1,1)))

plt.scatter(time_studied,scores)
plt.plot(np.linspace(0,70,100).reshape(-1,1), model.predict(np.linspace(0,10,100).reshape(-1,1)), 'r')
plt.ylim(0,100)
plt.show()