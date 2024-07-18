# JuegoPooTTTAim
# AimpeCausa

## Descripción
"AimpeCausa" es una aplicación de escritorio desarrollada en C# que combina dos juegos clásicos en una única interfaz gráfica: Tic Tac Toe (Tres en línea) y un juego de puntería (Aim). La aplicación está diseñada para proporcionar entretenimiento y práctica de habilidades de estrategia y puntería.

## Funcionamiento del Programa

### Interfaz Gráfica
El programa muestra una ventana principal (`MainForm`) con dos secciones principales:

- **Tic Tac Toe**: Un área de juego donde el jugador puede competir contra la computadora en el clásico juego de Tres en línea.
- **Aim**: Una cuadrícula más grande donde el jugador puede practicar su puntería. Algunos botones se marcan como objetivos (`Red`) y el objetivo es hacer clic en ellos antes de que se marquen incorrectamente (`Black`), lo que termina el juego de puntería.

### Funcionalidades de los Juegos

- **Tic Tac Toe**:
  - El jugador hace clic en los botones del tablero para colocar su marca ("X").
  - La computadora realiza automáticamente su movimiento (marca "O").
  - El juego verifica si hay un ganador después de cada movimiento.
  - Cuando el jugador gana, se muestra una imagen de "Ganador".
  - Si el jugador pierde, se muestra una imagen de "Flecha" señalando el botón de cierre en la esquina superior derecha de la ventana.

- **Aim**:
  - Se genera aleatoriamente un botón marcado como objetivo ("Red") en la cuadrícula.
  - El jugador debe hacer clic en este botón antes de que cambie o se marque incorrectamente ("Black").
  - Si se marca incorrectamente, se termina el juego de puntería y se activa el juego de Tic Tac Toe.

### Funcionalidades Adicionales

- **Botón de Reinicio**: Permite al usuario reiniciar ambos juegos desde cero.
- **Imágenes Visuales**: Utiliza imágenes (como "Ganador" y "Flecha") para comunicar visualmente el resultado del juego y las acciones disponibles para el usuario.

## Instalación y Uso

Para usar "AimpeCausa", sigue estos pasos:

1. Clona el repositorio desde GitHub:
   ```bash
   git clone https://github.com/tu_usuario/aimpecausa.git

![image](https://github.com/user-attachments/assets/41cdaae1-bd48-4c79-968a-c43557f0552b)
