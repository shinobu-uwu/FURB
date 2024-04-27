import cv2
import numpy as np

# Carregar a imagem
imagem = cv2.imread('./neutrofilo03.png')

# Converter a imagem para escala de cinza
imagem_cinza = cv2.cvtColor(imagem, cv2.COLOR_BGR2GRAY)

# Aplicar limiarização para binarizar a imagem
_, imagem_binaria = cv2.threshold(imagem_cinza, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)

# Encontrar os contornos na imagem binária
contornos, _ = cv2.findContours(imagem_binaria, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

# Criar uma máscara para os contornos encontrados
mascara = np.zeros_like(imagem_cinza)

# Desenhar os contornos na máscara
cv2.drawContours(mascara, contornos, -1, (255), thickness=cv2.FILLED)

# Aplicar a máscara na imagem original
imagem_segmentada = cv2.bitwise_and(imagem, imagem, mask=mascara)

# Mostrar a imagem segmentada
cv2.imshow('Imagem Segmentada', imagem_segmentada)
cv2.waitKey(0)
cv2.destroyAllWindows()
