import cv2
import numpy as np
from matplotlib import pyplot as plt

def segmentacao_por_limiarizacao(path: str):
    imagem = cv2.cvtColor(cv2.imread(path), cv2.COLOR_BGR2GRAY)
    # Defocando a imagem para remover ruídos e facilitar a segmentação
    imagem_desfocada = cv2.GaussianBlur(imagem, (5, 5), 0)
    # Aqui calculamos o limiar T, utilizando a média, ignorando o fundo preto da imagem
    T = np.mean(imagem_desfocada[imagem_desfocada > 0])
    # Aplicamos a limiarização, gerando uma imagem binária, utilizando o modo cv2.THRESH_BINARY_INV
    # conseguimos filtrar a imagem desfocada mantendo apenas os núcleos da célula
    _, imagem_binaria = cv2.threshold(imagem_desfocada,T, 255, cv2.THRESH_BINARY_INV)
    imagem_limiarizada = cv2.bitwise_and(imagem_desfocada, imagem_binaria)
    # Calculamos quantas componentes conexas existem na imagem
    num_labels, _ = cv2.connectedComponents(imagem_limiarizada)
    print(f'Número de componentes conexas: {num_labels - 1}')

    return imagem, imagem_limiarizada

img, img_limiarizada = segmentacao_por_limiarizacao('./neutrofilo03.png')

# Mostrar a imagem segmentada
plt.subplot(2, 3, 1)
plt.imshow(img, cmap='gray', vmin=0, vmax=255)
plt.subplot(2, 3, 2)
plt.imshow(img_limiarizada, cmap='gray', vmin=0, vmax=255)
plt.xticks([])
plt.yticks([])
plt.show()
