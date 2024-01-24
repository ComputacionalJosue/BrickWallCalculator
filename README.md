# BrickWallCalculation
![Portada Readme](https://github.com/ComputacionalJosue/BrickWallCalculator/blob/master/Docs/Cover%20image.jpg)
<div align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
  <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" alt="Visual Studio badge">
  <img src="https://img.shields.io/badge/GIT-E44C30?style=for-the-badge&logo=git&logoColor=white">
  <img src="https://img.shields.io/github/license/ComputacionalJosue/BrickWallCalculator.svg" alt="License">
</div>


Aplicación de consola, escrita en su totalidad con [C#](https://dotnet.microsoft.com/es-es/languages/csharp) en [Visual Studio IDE](https://visualstudio.microsoft.com/es/vs/). Calcula las cantidades de todos los materiales para la contrucción de un muro de ladrillo, tomando en cuenta todas las variables, desde las dimensiones del muro hasta el porcentaje de perdidad del ladrillo. Dependiendo de ciertos datos ingresados nos generará un gráfico de la representación del muro con arte ASCII, salvo ciertas excepciones.

## Funcionamiento de la aplicación ⚙️
Esta es una breve descripción de como funciona la aplicación, la cronología de los pasos esta dada por como esta escrito el código.
- **1ra Parte / Entrada de datos(longitudes):**
   - El primer dato ingresado será el `system of units`, que determianará si las entradas de datos y los resultados deben estar en sistema `Metric System` o `Imperial System`.
   - Se determinan las dimensiones del muro.
   - Se realizará la `Verification of windows`, que consiste en confirmar si cuentas con ventanas y sus medidas, en caso de tenerlas.
   - Se realizará la `Door verification`, que consiste en confirmar si cuentas con puertas y sus medidas, en caso de tenerlas.
- **2da Parte / Cálculo de m2:**
   - Se realiza el cálculo del área de la o las puertas y ventanas y esto se resta con área del muro, obteniendo así `areaTotal` del muro.
- **3ra Parte / Cálculo de ladrillos:**
   - Se recibe las entradas de nombre (opcional), largo, ancho y alto del ladrillo.
   - A estas alturas, la aplicación  mostrará una lista de opciones de aparejo de ladrillo, donde seleccionamos una.
   - Aquí ya tendremos `bricksU2` (numero de piezas / unidad²).
   - Se debe ingresar el % de pérdida de ladrillo que nostros consideremos.
   - Aquí ya tendremos `totalPcs` (el número de ladrillos total utilizado en todo nuestro muro).
- **4ta Parte / Volumenes:**
   - Se obtiene el `totalVolume` (volumen total en unidad³) de mortero teniendo en cuanta el % de pérdida.
- **5ta Parte / Entrada de materiales:**
   -  Aquí la aplicación  mostrará una lista de Dosificaciones para el mortero.
   -  Con la selección que hagamos, obtendremos la masa y el volumen de `cement` y `sand` respectivamente.
- **6ta Parte / Arte ASCII:**
   -  La primer posibilidad de impresion de caracteres será la que no contiene aberturas y solo está formada por columnas y filas de caracteres.
   -  La segunda posibilidad de impresion de caracteres será la que contiene aberturas ya sea por puertas o ventanas.
   -  El arte ASCCI generado solo es un aproximado; sin emabrgo, utilíza datos que fuimos ingresando desde la abertura de la aplicación hasta este momento y genera unos nuevos con estos. NO todas las combinaciones generararn arte ASCII, ya sea por dimensiones de muro demasiado grandes o el uso de algún tipo de aparejo no contemplado aún.
 
## Instrucciones para Usuarios Finales 📁

Si solo quieres probar o utilizar  la aplicación, ve a la pestaña "Releases" en [la página de Releases de nuestro repositorio en GitHub](https://github.com/ComputacionalJosue/BrickWallCalculator/releases), donde encontraras los archivo que necesitas y las intrucciones de acceso y descarga de la Aplicación de Consola.

## Instrucciones para Desarrolladores 🛠️
Si eres un desarrollador y deseas contribuir al proyecto, ve a la pestaña de "Releases" en [la página de Releases de nuestro repositorio en GitHub](https://github.com/ComputacionalJosue/BrickWallCalculator/releases), donde encontraras los archivo que necesitas y las intrucciones de acceso y descarga de la Aplicación de Consola.

##Documentation and Reference 📖


