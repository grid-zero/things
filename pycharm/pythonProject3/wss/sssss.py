import cv2 as cv
import numpy as np
import matplotlib.pyplot as plt
import tensorflow as tf
#Load hand writen digits to me
mnist = tf.keras.datasets.mnist

#load data, and it splits into train and test
(x_train, y_train), (x_test, y_test) = mnist.load_data()

#x data is the rbg grey scale value of 0-2050 something, convert that into between 0-1,
# for network use and easy computation
x_train = tf.keras.utils.normalize(x_train, axis=1)
x_test = tf.keras.utils.normalize(x_test, axis=1)

model = tf.keras.models.Sequential()
#flattent the 28*28 pixel grid into one line of 784, the input layer
model.add(tf.keras.layers.Flatten(input_shape=(28, 28)))
#adds the first hidden layer with 128 nurons,
#dense just means that every nueron is conected to every nueron beofre and after it, like normal
model.add(tf.keras.layers.Dense(units=128, activation=tf.nn.relu))
#again, i draw another hidden layer
model.add(tf.keras.layers.Dense(units=128, activation=tf.nn.relu))
#the final layer the out put, 10 is the number of digits
model.add(tf.keras.layers.Dense(units=10, activation=tf.nn.softmax))

#loss is how wrong it is, if out put is 0.2 and we want 1 the loss is 0.8, very wrong
model.compile(optimizer='adam', loss='sparse_categorical_crossentropy', metrics=['accuracy'])
#train model with train data x and train data y
model.fit(x_train, y_train, epochs=100, steps_per_epoch=1500)

loss, accuracy = model.evaluate(x_test, y_test)
print(accuracy)
print(loss)

model.save('digits.model')

img =  cv.imread(f'{1}.png')[:,:,0]
img = np.invert(np.array([img]))
prediction =model.predict(img)
print(f'The result is probably: {np.argmax(prediction)}')
plt.imshow(img[0], cmap=plt.cm.binary)
plt.show()
