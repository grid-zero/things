C=input
print({"+":lambda A,B:A+B,"-":lambda A,B:A-B,"*":lambda A,B:A*B,"/":lambda A,B:A/B}[int(C(''))](int(C('')),int(C(''))))