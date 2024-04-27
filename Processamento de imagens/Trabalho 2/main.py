import cv2

img = cv2.imread('mama.png')
se = cv2.getStructuringElement(cv2.MORPH_ELLIPSE, (10, 10))
img_dilatada = cv2.dilate(img, se)
tophat_abertura = cv2.morphologyEx(img, cv2.MORPH_TOPHAT, se)
tophat_fechamento = cv2.morphologyEx(img, cv2.MORPH_BLACKHAT, se)

soma = cv2.add(img, tophat_abertura)

resultado = cv2.subtract(img, tophat_fechamento)
resultado = cv2.subtract(img_dilatada, resultado)
limiar, img_limiarizada = cv2.threshold(
    resultado, 50, 255, cv2.THRESH_BINARY)

cv2.imshow('Imagem Original', img)
cv2.imshow('Imagem Limiarizada', img_limiarizada)
cv2.waitKey(0)
cv2.destroyAllWindows()
