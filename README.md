# 🏥 Pharmacy Project .NET

> Sistema de pedidos de medicamentos para farmacia desarrollado en C# con Windows Forms

## 📋 Descripción

**Pharmacy Project .NET** es una aplicación de escritorio desarrollada en C# que simula un sistema de pedidos de medicamentos para farmacias. La aplicación permite a los usuarios crear, validar y gestionar pedidos de medicamentos a diferentes distribuidores, seleccionando sucursales específicas para la entrega.

Este proyecto es parte de la **Actividad 2** del curso "Plataformas de Desarrollo de Software" y representa la migración de una aplicación Java original al ecosistema .NET.

- 📦 **Gestión de pedidos** completa (crear, validar, confirmar, enviar)

## 🚀 Tecnologías utilizadas

- **Lenguaje:** C# (.NET Framework 4.7.2+)
- **Framework GUI:** Windows Forms
- **IDE:** Visual Studio 2022
- **Arquitectura:** Programación Orientada a Objetos

## 📁 Estructura del proyecto

```
PharmacyProject/
├── 📁 Models/
│   └── Order.cs                    # Modelo de datos del pedido
├── 📁 Services/
│   └── OrderService.cs             # Lógica de negocio
├── 📁 Exceptions/
│   └── OrderException.cs           # Excepciones personalizadas
├── 📁 Forms/
│   ├── OrderForm.cs                # Formulario principal
│   └── ConfirmationWindow.cs       # Ventana de confirmación
├── Program.cs                      # Punto de entrada
├── README.md                       # Este archivo
└── PharmacyProject.sln            # Solución de Visual Studio
```

## 🛠️ Instalación y configuración

### Prerrequisitos

- 🖥️ Windows 10/11
- 🔧 Visual Studio 2019 o superior
- 📦 .NET Framework 4.7.2 o superior

### Pasos de instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/LIZETHESTRADA94/PharmacyProjectDotNet.git
   cd pharmacy-project-net
   ```

2. **Abrir en Visual Studio**
   Desde Visual Studio: `File > Open > Project/Solution`

3. **Restaurar dependencias**
   - Visual Studio restaurará automáticamente las referencias necesarias

4. **Compilar y ejecutar**
   - Presionar `F5` o `Ctrl+F5` para ejecutar
   - O usar `Build > Build Solution` seguido de `Debug > Start Debugging`

## 🎮 Uso de la aplicación

### 1. Crear un nuevo pedido

1. **Llenar el formulario principal:**
   - 💊 **Nombre del medicamento:** Texto alfanumérico
   - 🏷️ **Tipo de medicamento:** Seleccionar del dropdown
   - 🔢 **Cantidad:** Número entero positivo
   - 🚚 **Distribuidor:** Cofarma, Empsephar o Cemefar
   - 🏪 **Sucursales:** Principal y/o Secundaria

2. **Validar datos:**
   - Hacer clic en **"Confirmar"**
   - La aplicación validará automáticamente todos los campos

3. **Confirmar pedido:**
   - Revisar el resumen en la ventana de confirmación
   - Hacer clic en **"Enviar Pedido"** para completar

### 2. Gestión de errores

La aplicación valida:
- ❌ Nombre de medicamento vacío o con caracteres especiales
- ❌ Tipo de medicamento no seleccionado
- ❌ Cantidad no numérica o negativa
- ❌ Distribuidor no seleccionado
- ❌ Ninguna sucursal seleccionada

### 3. Limpiar formulario

- Usar el botón **"Limpiar"** para resetear todos los campos

## 👥 Autor

**Irma Lizeth Estrada Tobar**
- 🎓 Especialización en Ingeniería de Desarrollo de Software
- 🏫 Fundación Universitaria Internacional De La Rioja (UNIR)

*Desarrollado con ❤️ para el aprendizaje de plataformas de desarrollo de software*
