import cv2
import os
from matplotlib import pyplot as plt

img_test = cv2.imread("./3/entrada/50km.jpg", cv2.IMREAD_GRAYSCALE)
sift = cv2.SIFT_create()
surf = cv2.xfeatures2d.SURF_create()
orb = cv2.ORB_create()
kp1, des1 = sift.detectAndCompute(img_test, None)

for file in os.listdir('./3/dataset/50km'):
    img = cv2.imread(f"./3/dataset/50km/{file}", cv2.IMREAD_GRAYSCALE)
    kp2, des2 = sift.detectAndCompute(img, None)
    bf = cv2.BFMatcher()
    sift_matches = bf.knnMatch(des1, des2, k=2)
    good = [m for m, n in sift_matches if m.distance < 0.75 * n.distance]
    print(f"Quantidade de matches SIFT para imagem {file}: {len(good)}")


