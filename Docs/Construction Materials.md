# Construction Materials Library

Esta biblioteca de C#, denominada `ConstructionMaterials`, proporciona una clase `Ladrillo` que representa un tipo de ladrillo con sus tres dimensiones. La biblioteca también incluye métodos para manipular y calcular cantidades basadas en las dimensiones del ladrillo y los tamaños de las juntas.

## Instalación
Para utilizar esta biblioteca, sigue estos pasos:


## Tabla de Contenidos
- [Instalación](#instalación)
- [Uso](#uso)
- [Funcionalidad](#funcionalidad)
  - [Clase `Ladrillo`](#clase-ladrillo)
  - [Métodos](#métodos)
  - [Métodos Estáticos](#métodos-estáticos)
- [Ejemplos](#ejemplos)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)

## Installation
To use this library, follow these steps:
1. Clone the repository to your local machine.
   ```bash
   git clone https://github.com/your-username/ConstructionMaterials.git
2. Abre la solución en Visual Studio.
3. Compila la solución para generar la biblioteca.
4. Haz referencia a la biblioteca compilada en tu proyecto C#.

## Uso
Una vez que la biblioteca esté instalada, puedes utilizar la clase Ladrillo en tu proyecto C#.
   ```bash
   using ConstructionMaterials;

   // Create a brick
   Ladrillo myBrick = new Ladrillo("Standard", 10.0, 5.0, 20.0);

   // Manipulate brick dimensions
   myBrick.AddJointHeight(0.5);
   myBrick.AddJointWidth(0.25);

   // Calculate quantity in meters or feet
   double quantityInMeters = Ladrillo.QuantityInMeter(l => l.Lenght, myBrick, 0.1);
   double quantityInFeet = Ladrillo.QuantityInFeets(l => l.Width, myBrick, 0.05);

   // Print brick details
   Console.WriteLine(myBrick.ToString());









