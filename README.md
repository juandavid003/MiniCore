# Proyecto MVC en ASP.NET - Gestión de Empleados, Departamentos y Gastos

## Descripción del Proyecto

Este proyecto es una aplicación web desarrollada utilizando el patrón de diseño Modelo-Vista-Controlador (MVC) en ASP.NET. La aplicación permite gestionar información relacionada con empleados, departamentos y gastos de una organización. Además, incluye funcionalidades para consultar los gastos registrados en un rango de fechas especificado.

## Características

1. **Gestión de Empleados**:
   - Crear nuevos empleados.
   - Eliminar empleados existentes.
   - Relacionar empleados con un departamento.

2. **Gestión de Departamentos**:
   - Crear nuevos departamentos.
   - Eliminar departamentos existentes.

3. **Gestión de Gastos**:
   - Registrar nuevos gastos.
   - Eliminar gastos existentes.
   - Consultar los gastos en un rango de fechas específico.

4. **Consultas**:
   - Filtrar los gastos registrados en la base de datos según una fecha de inicio y una fecha de fin.

## Estructura de Tablas en la Base de Datos

### 1. **Empleado**
- **EmpleadoId**: Identificador único del empleado (int).
- **Nombre**: Nombre completo del empleado (nvarchar(100)).
- **Email**: Dirección de correo electrónico del empleado (nvarchar(100)).
- **DepartamentoId**: Llave foránea que relaciona al empleado con un departamento (int).

### 2. **Departamento**
- **DepartamentoId**: Identificador único del departamento (int).
- **Nombre**: Nombre del departamento (nvarchar(100)).

### 3. **Gastos**
- **GastoId**: Identificador único del gasto (int).
- **Monto**: Monto del gasto (decimal(10,2)).
- **Fecha**: Fecha en que se realizó el gasto (datetime).
- **Descripcion**: Descripción del gasto (nvarchar(255)).
- **EmpleadoId**: Llave foránea que relaciona el gasto con un empleado (int).

## Funcionalidades Detalladas

### Crear y Eliminar Datos
- **Empleados**:
  - Crear un empleado con nombre, correo electrónico y asignación de departamento.
  - Eliminar un empleado por su identificador.
  
- **Departamentos**:
  - Crear un nuevo departamento con un nombre único.
  - Eliminar un departamento por su identificador.

- **Gastos**:
  - Registrar un gasto con monto, descripción, fecha, y el empleado relacionado.
  - Eliminar un gasto por su identificador.

### Consulta de Gastos
- Seleccionar un rango de fechas (fecha de inicio y fecha de fin).
- Filtrar y mostrar los gastos realizados en ese período.
- Mostrar el total acumulado de los gastos para el rango especificado.

## Tecnologías Utilizadas

1. **Backend**:
   - ASP.NET MVC Framework.
   - Entity Framework para ORM.
   - C# como lenguaje principal.

2. **Base de Datos**:
   - SQL Server.

3. **Frontend**:
   - Razor Pages.
   - HTML5, CSS3, Bootstrap para diseño responsivo.
   - JavaScript y jQuery para funcionalidades interactivas.

## Requisitos Previos

- Visual Studio 2022 o superior.
- .NET Framework 6.0 o superior.
- SQL Server (cualquier edición).
- Paquetes de NuGet:
  - Microsoft.EntityFrameworkCore.
  - Microsoft.EntityFrameworkCore.SqlServer.
  - Microsoft.EntityFrameworkCore.Tools.

## Configuración del Proyecto

### Paso 1: Clonar el Repositorio
```bash
git clone https://github.com/tu_usuario/nombre_del_proyecto.git
cd nombre_del_proyecto
```

### Paso 2: Configurar la Cadena de Conexión
1. Abre el archivo `appsettings.json`.
2. Reemplaza el valor de `DefaultConnection` con tu cadena de conexión a SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;Trusted_Connection=True;"
}
```

### Paso 3: Crear la Base de Datos
1. Abre la Consola del Administrador de Paquetes en Visual Studio.
2. Ejecuta el comando para aplicar las migraciones:
```bash
Update-Database
```

### Paso 4: Ejecutar la Aplicación
1. Presiona `Ctrl + F5` para iniciar la aplicación en el navegador.
2. Navega por las secciones de Empleados, Departamentos y Gastos para interactuar con el sistema.

## Rutas Principales

- Inicio: `/`
- Gestión de Empleados: `/Empleado`
- Gestión de Departamentos: `/Departamento`
- Gestión de Gastos: `/Gasto`
- Consulta de Gastos por Fechas: `/Gasto/Consulta`

## Ejemplo de Uso

### 1. Crear un Empleado
1. Navega a `/Empleado/Create`.
2. Ingresa los datos del empleado y selecciona un departamento.
3. Haz clic en **Guardar**.

### 2. Registrar un Gasto
1. Navega a `/Gasto/Create`.
2. Ingresa el monto, descripción, fecha y selecciona el empleado que realizó el gasto.
3. Haz clic en **Guardar**.

### 3. Consultar Gastos por Rango de Fechas
1. Navega a `/Gasto/Consulta`.
2. Selecciona las fechas de inicio y fin.
3. Haz clic en **Buscar** para ver los gastos dentro del rango.

## Futuras Mejoras

- Agregar autenticación y autorización para usuarios.
- Implementar exportación de datos en formatos PDF y Excel.
- Incluir gráficos para análisis visual de los gastos.

## Contribuciones

Si deseas contribuir, abre un *pull request* o reporta un problema en el repositorio.

## Contacto

**Autor**: Juan David Ramirez  
**Correo Electrónico**: rjuandavid2002@gmail.com  
