import numpy as np
import matplotlib.pyplot as plt
input = np.array(
    [
        [3, 1.5],
        [2, 1],
        [4, 1.5],
        [3, 4],
        [3.5, 0.5],
        [2, 0.5],
        [5.5, 1],
        [1, 1],
    ]
)
weight_1 = np.array([-1, 2, -0.5])
weight_2 = np.array([3, -3, 1])
bias = 2
targets = np.array([0, 1, 0, 1, 0, 1, 1, 0])
weight_3 = np.array([0.5, -1, 0.67])
neuron_1 = input[0,0] * weight_1[0] + input[0,1] * weight_2[0]
neuron_2 = input[0,0] * weight_1[1] + input[0,1] * weight_2[1]
neuron_3 = input[0,0] * weight_1[2] + input[0,1] * weight_2[2]
print(f"neuron_1: {neuron_1}")

def predict(self, input):
    neuron_1 = input[0, 0] * weight_1[0] + input[0, 1] * weight_2[0]
    neuron_2 = input[0, 0] * weight_1[1] + input[0, 1] * weight_2[1]
    neuron_3 = input[0, 0] * weight_1[2] + input[0, 1] * weight_2[2]
    output = neuron_1 * weight_3[0] + neuron_2 * weight_3[1] + neuron_3 * weight_3[2] + bias
    prediction = sigmoid(output)
    return predidction


for data_instance_index in range(len(input)):
                    data_point = input[data_instance_index]
                    target = targets[data_instance_index]

                    prediction = predict(data_point)
                    error = np.square(prediction - target)

                    cumulative_error = cumulative_error + error
cumulative_errors.append(cumulative_error)

output = neuron_1*weight_3[0] + neuron_2*weight_3[1] + neuron_3*weight_3[2] +bias
def sigmoid(x):
    return 1 / (1 + np.exp(-x))

outputfinal = sigmoid(output)

print(outputfinal)

'''