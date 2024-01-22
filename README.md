# BrickWallCalculation
![Portada Readme](https://github.com/ComputacionalJosue/BrickWallCalculator/blob/master/Docs/Cover%20image.jpg)
<div align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
  <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" alt="Visual Studio badge">
  <img src="https://img.shields.io/badge/GIT-E44C30?style=for-the-badge&logo=git&logoColor=white">
  <img src="https://img.shields.io/github/license/ComputacionalJosue/BrickWallCalculator.svg" alt="License">
</div>


Calcule las cantidades de todos los materiales para la contrucción de un muro de ladrillo, tomando en cuenta todas las variables, desde las dimensiones del muro hasta el porcentaje de perdidad del ladrillo. Dependiendo de ciertos datos ingresados nos generará un gráfico de la representación del muro con arte ASCII, salvo ciertas excepciones.

## Funcionamiento de la aplicación

1. **1ra Parte/Entarda de datos(longitudes):**
   - El primer dato ingresado será el `system of units`, que determianará si las entradas de datos y los resultados deben estar en sistema `Metric System` o `Imperial System`.
   - Se determina las dimensiones del muro.
   - Se hará la `Verification of windows` que consta de confirmar si cuentas con ventanas y sus medidas si es que cuenta con ellas.
   - Se hará la `Door verification` que consta de confirmar si cuentas con puertas y sus medidas si es que cuenta con ellas.
2. **2da Parte/Cálculo de m2:**
   - Se hace el cálculo del área de la o las puertas y ventanas y esto se resta con área del muro, obteniendo así `areaTotal` del muro.
3. **3ra Parte/Cálculo de ladrillos:**
   - Se recibe las entradas de nombre (opcional), largo, ancho y alto del ladrillo.
   - A estas alturas la aplicación nos mostrará una lista de opciones de aparejo de ladrillo, donde seleccionamos una.
   - Aquí ya tendremos `bricksU2` (numero de piezas / unidad²).
   - Tendremos que ingresar el % de perdida de ladrillo que nostros consideremos.
   - Aquí ya tendriamos `totalPcs` (el número de ladrillos total utilizado en todo nuetsro muro.
4.

