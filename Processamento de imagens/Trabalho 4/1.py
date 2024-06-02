import cv2
import numpy as np
import os
import matplotlib.pyplot as plt

# Questão 1
def crop_img(img, scale=1.0):
    height, width = img.shape[:2]
    new_width = int(width * scale)
    new_height = int(height * scale)

    start_x = (width - new_width) // 2
    start_y = (height - new_height) // 2
    end_x = start_x + new_width
    end_y = start_y + new_height

    return img[start_y:end_y, start_x:end_x]

def isolate_pupil(img):
    gray_eye_image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    blurred = cv2.GaussianBlur(gray_eye_image, (5, 5), 1.4)
    # Aumentamos o contraste para melhorar a limiarização
    eq = cv2.equalizeHist(blurred)
    # pupilas são pretas, então podemos usar um threshold bem baixo, mesmo com o flash da câmera
    _, thresh = cv2.threshold(eq, 25, 255, cv2.THRESH_BINARY) 
    circles = cv2.HoughCircles(thresh, cv2.HOUGH_GRADIENT, dp=1.2, minDist=200,
                           param1=100, param2=20, minRadius=20, maxRadius=45)

    if circles is not None:
        for l in circles:
            for circle in l:
                center = (int(circle[0]), int(circle[1]))
                radius = int(circle[2])
                # Removemos a pupila (círculo encontrado) da imagem
                mask = np.ones((img.shape[0], img.shape[1], 1), np.uint8)
                cv2.circle(mask, center, radius, (0, 0, 0), thickness = -1)
                return cv2.bitwise_and(img, img, mask=mask)
    return img

def isolate_iris(img):
    gray_eye_image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    # iris não são bem definidas como pupilas, então vamos precisar detectar bordas primeiro para facilitar HoughCrircles
    eq = cv2.equalizeHist(gray_eye_image)
    blurred = cv2.GaussianBlur(eq, (7, 7), 7)
    canny = cv2.Canny(blurred, 50, 100)
    cv2.imshow("canny", canny)
    circles = cv2.HoughCircles(canny, cv2.HOUGH_GRADIENT, dp=2, minDist=650, param1=100, param2=140, minRadius=50, maxRadius=200)

    if circles is not None:
        if len(circles) > 1:
            # Pegamos o maior círculo, que deve ser a íris
            circles = [max(circles, key=lambda x: x[0][2])]
        else:
            circles = circles[0]

        for l in circles:
            for circle in l:
                center = (int(circle[0]), int(circle[1]))
                radius = int(circle[2])
                # Removemos a pupila (círculo encontrado) da imagem
                mask = np.zeros((img.shape[0], img.shape[1], 1), np.uint8)
                cv2.circle(mask, center, radius, (255, 255, 255), thickness = -1)
                return cv2.bitwise_and(img, img, mask=mask)

    return img

img = cv2.imread("./1/008_R_03.JPG")
# Como em todas as imagens o olhos está no centro, primeiro damos um zoom de 50% no centro da image
img = crop_img(img, 0.5)
img = isolate_pupil(img)
img = isolate_iris(img)
cv2.imshow("img", img)
cv2.waitKey(0)
cv2.destroyAllWindows()
