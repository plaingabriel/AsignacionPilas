# Convertir una expresión infija a postfija

## Asignacion en el tema de pilas de la materia Taller de Estructura de Datos en la Universidad de Oriente.

### Criterios

‌* Evaluar una expresión infija
* **Usar pilas**
* Usar POO (Atributos, métodos, clases)
* Hacer menú de opciones
* Main cargado = Puntos menos
* Utilizar todo los métodos de las pilas además de:
‌  * Convertir
‌  * Evaluar
* Defender el proyecto

> **Expresión Infija:** Expresión excesivamente parentizada. Por ejemplo: ((A + B) / (C - D)) ó ((4 + 5) / (5 - 2))
> **Expresión Postfija:** LOs operadores de postfijo siguen una expresión primaria. Por ejemplo: AB+CD-/ ó 45+52-/

* **Validar formato correcto:** 
  * Misma cantidad de paréntesis que igual a la cantidad de paréntesis que cierra
  * La cantidad de operandos debe ser mayor en 1 a la cantidad de operadores
  * Evaluar letras mayúsculas, letras minúsculas

* **Opcion Convertir:**
  * Operandos A ... Z, a ... Z
  * Operadores +, -, *, /, ^, %
  * Agrupación (, )
  * Concatenar caracteres
  * Si hay un caracter diferente a ellos, rebotar por expresión inválida
    **Ejemplo:**
    *Entrada:*  ((A + B) / (C - D))
    *Salida:* AB+CD-/
  
* **Opcion Evaluar:**
  * Operandos 0, ... 9
  * Operador +, -, *, /, ^, %
  * Agrupación (, )
  * Hacer las operaciones algebraicas correspondientes
  * Si hay un caracter diferente a ellos, rebotar por expresión inválida
  * Si hay un caso de division entre 0, rebotar
    **Ejemplo:**
    *Entrada:*  ((4 + 5) / (5 - 2))
    *Salida:* 3

### Pendiente

- [ ] Aplicar herencia y poilimorfismo en la clase ConvertirInfija para un codigo más eficiente
- [ ] Desarrollar la opción de evaluar
- [ ] Desarrollar el menú de opciones
- [ ] Defender el proyecto
- [ ] \(**Opcional**) Matarme si todo sale mal
